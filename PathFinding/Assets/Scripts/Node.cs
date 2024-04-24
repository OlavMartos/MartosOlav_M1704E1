using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class Node
{
    public int[] position;
    public float heuristic;
    public float cost;
    public List<Node> neighbourNodes;

    public Node(int[] pos, int[] target, Node root)
    {
        position = pos;
        heuristic = Calculator.CheckDistanceToObj(pos, target);
        if(root != null) cost = Calculator.CheckDistanceToObj(pos, root.position);
    }
}
