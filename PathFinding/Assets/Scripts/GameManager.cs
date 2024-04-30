using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player, target, path, correctPath;
    private int[,] GameMatrix;                              // 0 not chosen, 1 player, 2 objective
    private int[] startPos = new int[2];
    private int[] objectivePos = new int[2];

    [Header("A*")]
    public bool win;
    public List<Node> openList = new List<Node>();
    public List<Node> closedList = new List<Node>();
    public Node startNode;
    public Node endNode;

    private void Awake()
    {
        GameMatrix = new int[Calculator.length, Calculator.length];

        for (int i = 0; i < Calculator.length; i++)         // Row
            for (int j = 0; j < Calculator.length; j++)     // Column
                GameMatrix[i, j] = 0;

        // Randomize startPos & finalPos
        var rand1 = Random.Range(0, Calculator.length);
        var rand2 = Random.Range(0, Calculator.length);
        startPos[0] = rand1;
        startPos[1] = rand2;
        SetObjectivePoint(startPos);

        // Insert the elements in the Game Matrix
        GameMatrix[startPos[0], startPos[1]] = 1;
        GameMatrix[objectivePos[0], objectivePos[1]] = 2;


        // Instantiate elements in screen
        InstantiateToken(player, startPos);
        InstantiateToken(target, objectivePos);
        ShowMatrix();

        // Create nodes
        startNode = new Node(startPos, objectivePos, null);
        endNode = new Node(objectivePos, objectivePos, null);
        openList.Add(startNode);
    }

    /// <summary>
    /// Instantiate the object in the random position generedated before
    /// </summary>
    /// <param name="token">The game object to instantiate</param>
    /// <param name="position">The position of the GameObject inside the game</param>
    private void InstantiateToken(GameObject token, int[] position)
    {
        Instantiate(token, Calculator.GetPositionFromMatrix(position), Quaternion.identity);
    }

    /// <summary>
    /// Generate the objective position
    /// </summary>
    /// <param name="startPos">Position of the start point</param>
    private void SetObjectivePoint(int[] startPos) 
    {
        var rand1 = Random.Range(0, Calculator.length);
        var rand2 = Random.Range(0, Calculator.length);
        if (rand1 != startPos[0] || rand2 != startPos[1])
        {
            objectivePos[0] = rand1;
            objectivePos[1] = rand2;
        }
    }

    /// <summary>
    /// Show the matrix
    /// </summary>
    private void ShowMatrix()
    {
        string matrix = "";
        for (int i = 0; i < Calculator.length; i++)
        {
            for (int j = 0; j < Calculator.length; j++)
            {
                matrix += GameMatrix[i, j] + " ";
            }
            matrix += "\n";
        }
        Debug.Log(matrix);
    }

    // EL VOSTRE EXERCICI COMENÇA AQUI
    private void Update()
    {
        if(!EvaluateWin())
        {
            if(openList.Count > 0) { }
        }
    }

    private bool EvaluateWin()
    {
        return win;
    }
}
