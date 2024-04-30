using System.Collections.Generic;
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

    public Node(int[] pos, int[] target, Node parent)
    {
        position = pos;
        heuristic = Mathf.Round(Calculator.CheckDistanceToObj(pos, target));
        if(parent != null) gCost = Mathf.Round(Calculator.CheckDistanceToObj(pos, parent.position));
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
