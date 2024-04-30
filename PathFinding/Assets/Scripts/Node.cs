using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class Node
{
    public int[] position;
    public float heuristic;
    public float gCost;
    public float fCost;
    public List<Node> neighbors;
    public Node parentNode;

    public Node(int[] pos, int[] target, Node root)
    {
        position = pos;
        heuristic = Calculator.CheckDistanceToObj(pos, target);
        if(root != null) gCost = Calculator.CheckDistanceToObj(pos, root.position);
    }

    public void AddNeighbour(List<Node> neighbors)
    {
        this.neighbors = neighbors;
    }

    public int ComparateTo(Node nodeToCompare)
    {
        int compare = fCost.CompareTo(nodeToCompare.fCost);
        if(compare == 0) compare = heuristic.CompareTo(nodeToCompare.heuristic);
        return compare;
    }
}
