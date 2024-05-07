using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public static class NodePath
{
    public static List<Node> nodes = new();
    private static bool end = false;
    public static Queue<Node> nodesLocal = new();

    public static void FindSelectableNode()
    {
        Queue<Node> openList = new();
        openList.Enqueue(nodes[0]);
        nodes[0].alredyChecked = true;
        while (openList.Count > 0)
        {
            Queue<Node> oreden = Order(openList);
            openList.Clear();
            openList = oreden;
            Node nodeAct = openList.Dequeue();
            Queue<Node> list = FindAdjentNode(nodeAct);

            foreach (Node currentNode in list)
            {
                if (!currentNode.alredyChecked)
                {
                    currentNode.nodeFather = nodeAct;
                    currentNode.alredyChecked = true;
                    openList.Enqueue(currentNode);
                    if (currentNode.distance == 0)
                    {
                        Win(currentNode);
                        end = true;
                        break;
                    }
                }
            }
            if (end) break;
        }
    }
    public static Queue<Node> FindAdjentNode(Node currentNode)
    {
        nodesLocal.Clear();

        int i = nodes.Count - 1;
        int sum = 1;

        // Neighbour Up
        if (currentNode.position[0] + 1 < Calculator.length)
        {
            int[] pos = new int[2];
            pos[0] = currentNode.position[0] + 1;
            pos[1] = currentNode.position[1];
            if (!CheckIfPosExist(pos))
            {
                InstanceToken(pos, i, sum);
                sum++;
            }
        }

        // Neighbour Down
        if (currentNode.position[0] - 1 >= 0)
        {
            int[] pos = new int[2];
            pos[0] = currentNode.position[0] - 1;
            pos[1] = currentNode.position[1];
            if (!CheckIfPosExist(pos))
            {
                InstanceToken(pos, i, sum);
                sum++;
            }
        }

        // Neighbour Right
        if (currentNode.position[1] + 1 < Calculator.length)
        {
            int[] pos = new int[2];
            pos[0] = currentNode.position[0];
            pos[1] = currentNode.position[1] + 1;
            if (!CheckIfPosExist(pos))
            {
                InstanceToken(pos, i, sum);
                sum++;
            }
        }

        // Neighbour Left
        if (currentNode.position[1] - 1 >= 0)
        {
            int[] pos = new int[2];
            pos[0] = currentNode.position[0];
            pos[1] = currentNode.position[1] - 1;
            if (!CheckIfPosExist(pos))
            {
                InstanceToken(pos, i, sum);
            }
        }
        Queue<Node> nodesLocalOrden = Order(nodesLocal);
        return nodesLocalOrden;
    }

    public static void InstanceToken(int[] pos, int i, int sum)
    {
        GameManager.Instance.InstantiateToken(GameManager.Instance.path, pos);
        nodesLocal.Enqueue(nodes[i + sum]);
    }

    public static bool CheckIfPosExist(int[] pos)
    {
        bool exists = false;
        foreach (Node node in nodes)
        {
            if (node.position[0] == pos[0] && node.position[1] == pos[1]) exists = true;
        }
        return exists;
    }

    public static Queue<Node> Order(Queue<Node> proses)
    {
        IEnumerable<Node> query = proses.OrderBy(node => node.distance);
        Queue<Node> prosesOrdn = new();

        foreach (Node node in query) prosesOrdn.Enqueue(node);
        return prosesOrdn;

    }
    public static void Win(Node node)
    {
        GameManager.Instance.InstantiateToken(GameManager.Instance.correctPath, node.position);
        if (node.nodeFather != null) Win(node.nodeFather);
    }
}

