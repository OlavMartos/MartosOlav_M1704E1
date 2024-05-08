public static class NodeNeighbour
{
    /// <summary>
    /// Check neighbour up
    /// </summary>
    public static int CheckUp(Node currentNode, int i, int sum)
    {
        if (currentNode.position[0] + 1 < Calculator.length)
        {
            int[] pos = new int[2];
            pos[0] = currentNode.position[0] + 1;
            pos[1] = currentNode.position[1];
            if (!NodePath.CheckIfPosExist(pos))
            {
                NodePath.InstanceToken(pos, i, sum);
                sum++;
            }
        }

        return sum;
    }

    /// <summary>
    /// Check neighbour down
    /// </summary>
    public static int CheckDown(Node currentNode, int i, int sum)
    {
        if (currentNode.position[0] - 1 >= 0)
        {
            int[] pos = new int[2];
            pos[0] = currentNode.position[0] - 1;
            pos[1] = currentNode.position[1];
            if (!NodePath.CheckIfPosExist(pos))
            {
                NodePath.InstanceToken(pos, i, sum);
                sum++;
            }
        }

        return sum;
    }

    /// <summary>
    /// Check neighbour right
    /// </summary>
    public static int CheckRight(Node currentNode, int i, int sum)
    {
        if (currentNode.position[1] + 1 < Calculator.length)
        {
            int[] pos = new int[2];
            pos[0] = currentNode.position[0];
            pos[1] = currentNode.position[1] + 1;
            if (!NodePath.CheckIfPosExist(pos))
            {
                NodePath.InstanceToken(pos, i, sum);
                sum++;
            }
        }

        return sum;
    }

    /// <summary>
    /// Check neighbour left
    /// </summary>
    public static void CheckLeft(Node currentNode, int i, int sum)
    {
        if (currentNode.position[1] - 1 >= 0)
        {
            int[] pos = new int[2];
            pos[0] = currentNode.position[0];
            pos[1] = currentNode.position[1] - 1;
            if (!NodePath.CheckIfPosExist(pos)) NodePath.InstanceToken(pos, i, sum);
        }
    }
}
