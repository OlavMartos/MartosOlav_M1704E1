using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
            Queue<Node> listSort = Sort(openList);
            openList.Clear();
            openList = listSort;
            Node currentNode = openList.Dequeue();
            Queue<Node> list = FindAdjentNode(currentNode);

            CheckWin(currentNode, list, openList);
            if (end) break;
        }
    }

    public static void CheckWin(Node currentNode, Queue<Node> list, Queue<Node> openList)
    {
        foreach (Node node in list)
        {
            if (!node.alredyChecked)
            {
                node.nodeFather = currentNode;
                node.alredyChecked = true;
                openList.Enqueue(node);
                if (node.distance == 0)
                {
                    GameManager.Instance.StartCoroutine(Win(node));
                    end = true;
                    break;
                }
            }
        }
    }

    public static Queue<Node> FindAdjentNode(Node currentNode)
    {
        nodesLocal.Clear();

        int i = nodes.Count - 1;
        int sum = 1;
        CheckNeighbors(currentNode, i, sum);

        Queue<Node> nodesLocalOrden = Sort(nodesLocal);
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

    public static Queue<Node> Sort(Queue<Node> proses)
    {
        IEnumerable<Node> query = proses.OrderBy(node => node.distance);
        Queue<Node> prosesOrdn = new();

        foreach (Node node in query) prosesOrdn.Enqueue(node);
        return prosesOrdn;

    }
    public static IEnumerator Win(Node node)
    {
        GameManager.Instance.InstantiateToken(GameManager.Instance.correctPath, node.position);

        // If you want activated this extra, go to the GameManager in the Unity Inspector
        if (node.nodeFather == null && GameManager.Instance.screamerEnable) GameManager.Instance.Screamer();  
        yield return new WaitForSeconds(0.25f);
        if (node.nodeFather != null) GameManager.Instance.StartCoroutine(Win(node.nodeFather));
    }

    public static void CheckNeighbors(Node currentNode, int i, int sum)
    {
        sum = NodeNeighbour.CheckUp(currentNode, i, sum);
        sum = NodeNeighbour.CheckDown(currentNode, i, sum);
        sum = NodeNeighbour.CheckRight(currentNode, i, sum);
        NodeNeighbour.CheckLeft(currentNode, i, sum);
    }
}

