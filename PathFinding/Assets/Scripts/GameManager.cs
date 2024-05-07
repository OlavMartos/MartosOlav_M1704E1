using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player, target, path, correctPath;
    private int[,] GameMatrix;                              // 0 not chosen, 1 player, 2 objective
    private int[] startPos = new int[2];
    private int[] objectivePos = new int[2];

    private void Awake()
    {
        Instance = this;
        GameMatrix = new int[Calculator.length, Calculator.length];

        for (int i = 0; i < Calculator.length; i++) //fila
            for (int j = 0; j < Calculator.length; j++) //columna
                GameMatrix[i, j] = 0;

        //randomitzar pos final i inicial;
        var rand1 = Random.Range(0, Calculator.length);
        var rand2 = Random.Range(0, Calculator.length);
        startPos[0] = rand1;
        startPos[1] = rand2;
        SetObjectivePoint(startPos);

        GameMatrix[startPos[0], startPos[1]] = 1;
        GameMatrix[objectivePos[0], objectivePos[1]] = 2;

        InstantiateToken(player, startPos);
        InstantiateToken(target, objectivePos);
        InstantiateToken(path, startPos);
        NodePath.FindSelectableNode();
        ShowMatrix();
    }


    /// <summary>
    /// Instantiate the object in the random position generedated before
    /// </summary>
    /// <param name="token">The game object to instantiate</param>
    /// <param name="position">The position of the GameObject inside the game</param>
    public void InstantiateToken(GameObject token, int[] position)
    {
        var obj = Instantiate(token, Calculator.GetPositionFromMatrix(position),
            Quaternion.identity);
        if (obj.GetComponent<Node>() != null)
        {

            Node node = obj.GetComponent<Node>();
            node.position = position;
            node.distance = Calculator.CheckDistanceToObj(position, objectivePos);
            node.alredyChecked = false;
            NodePath.nodes.Add(node);
        }
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
    private void ShowMatrix() //fa un debug log de la matriu
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

        }
    }

    private bool EvaluateWin()
    {
        return false;
    }
}
