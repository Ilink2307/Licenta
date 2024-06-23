using System;
using TMPro;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [Serializable]
    public class WinPositions
    {
        public int line, column;
    }

    public enum Direction
    {
        Up, Down, Left, Right
    }

    public int gridLenght;
    public int gridWidth;

    public string[][] matrix;
    string[][] initialMatrix;

    public Direction aUpEntanglement;
    public Direction aDownEntanglement;
    public Direction aLeftEntanglement;
    public Direction aRightEntanglement;

    public Color aColor;

    public Direction bUpEntanglement;
    public Direction bDownEntanglement;
    public Direction bLeftEntanglement;
    public Direction bRightEntanglement;

    public Color bColor;

    Tuple<int, int> a1;
    Tuple<int, int> a2;
    Tuple<int, int> b1;
    Tuple<int, int> b2;

    Tuple<int, int> a1Initial;
    Tuple<int, int> a2Initial;
    Tuple<int, int> b1Initial;
    Tuple<int, int> b2Initial;

    public WinPositions a1WinPos;
    public WinPositions a2WinPos;
    public WinPositions b1WinPos;
    public WinPositions b2WinPos;

    public GameObject[] objectsToChangeColor;
    public Color winColor;

    public Canvas gameCanvas;
    public OpenMinigame openMinigame;
    // Start is called before the first frame update
    void Start()
    {
        //init matrix
        matrix = new string[gridLenght][];
        initialMatrix = new string[gridLenght][];
        for (int i = 0; i < gridLenght; i++)
        {
            matrix[i] = new string[gridWidth];
            initialMatrix[i] = new string[gridWidth];
        }

        //adding values to matrix
        int index = 0;
        for (int i = 0; i < gridLenght; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                Transform cell = transform.GetChild(index);
                if (cell.childCount == 0)
                {
                    matrix[i][j] = " ";
                    initialMatrix[i][j] = " ";
                }
                else
                {
                    Transform cellChild = cell.GetChild(0);
                    string name = cellChild.GetComponent<TMP_Text>().text;
                    matrix[i][j] = name;
                    initialMatrix[i][j] = name;
                    if (name == "A1")
                    {
                        a1 = new Tuple<int, int>(i, j);
                        a1Initial = new Tuple<int, int>(i, j);
                        cellChild.GetComponent<TMP_Text>().color = aColor;
                    }
                    else if (name == "A2")
                    {
                        a2 = new Tuple<int, int>(i, j);
                        a2Initial = new Tuple<int, int>(i, j);
                        cellChild.GetComponent<TMP_Text>().color = aColor;
                    }
                    else if (name == "B1")
                    {
                        b1 = new Tuple<int, int>(i, j);
                        b1Initial = new Tuple<int, int>(i, j);
                        cellChild.GetComponent<TMP_Text>().color = bColor;
                    }
                    else if (name == "B2")
                    {
                        b2 = new Tuple<int, int>(i, j);
                        b2Initial = new Tuple<int, int>(i, j);
                        cellChild.GetComponent<TMP_Text>().color = bColor;
                    }
                }
                index++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Check win condition
        if (CheckWinCondition())
        {
            WinAction();
        }

        //A1 => A2 - Movement

        if (Input.GetKeyDown(KeyCode.W))
        {
            var potentialPos = new Tuple<int, int>(Modulo(a1.Item1 - 1, gridLenght), a1.Item2);
            if (MovePiece(a1, potentialPos))
            {
                a1 = potentialPos;
            }

            potentialPos = GetEntanglementPos(a2, aUpEntanglement.ToString());
            if (MovePiece(a2, potentialPos))
            {
                a2 = potentialPos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            var potentialPos = new Tuple<int, int>(a1.Item1, Modulo(a1.Item2 - 1, gridWidth));
            if (MovePiece(a1, potentialPos))
            {
                a1 = potentialPos;
            }

            potentialPos = GetEntanglementPos(a2, aLeftEntanglement.ToString());
            if (MovePiece(a2, potentialPos))
            {
                a2 = potentialPos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            var potentialPos = new Tuple<int, int>(Modulo(a1.Item1 + 1, gridLenght), a1.Item2);
            if (MovePiece(a1, potentialPos))
            {
                a1 = potentialPos;
            }

            potentialPos = GetEntanglementPos(a2, aDownEntanglement.ToString());
            if (MovePiece(a2, potentialPos))
            {
                a2 = potentialPos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            var potentialPos = new Tuple<int, int>(a1.Item1, Modulo(a1.Item2 + 1, gridWidth));
            if (MovePiece(a1, potentialPos))
            {
                a1 = potentialPos;
            }

            potentialPos = GetEntanglementPos(a2, aRightEntanglement.ToString());
            if (MovePiece(a2, potentialPos))
            {
                a2 = potentialPos;
            }
        }

        //B1 => B2 - Movement

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var potentialPos = new Tuple<int, int>(Modulo(b1.Item1 - 1, gridLenght), b1.Item2);
            if (MovePiece(b1, potentialPos))
            {
                b1 = potentialPos;
            }

            potentialPos = GetEntanglementPos(b2, bUpEntanglement.ToString());
            if (MovePiece(b2, potentialPos))
            {
                b2 = potentialPos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var potentialPos = new Tuple<int, int>(b1.Item1, Modulo(b1.Item2 - 1, gridWidth));
            if (MovePiece(b1, potentialPos))
            {
                b1 = potentialPos;
            }

            potentialPos = GetEntanglementPos(b2, bLeftEntanglement.ToString());
            if (MovePiece(b2, potentialPos))
            {
                b2 = potentialPos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var potentialPos = new Tuple<int, int>(Modulo(b1.Item1 + 1, gridLenght), b1.Item2);
            if (MovePiece(b1, potentialPos))
            {
                b1 = potentialPos;
            }

            potentialPos = GetEntanglementPos(b2, bDownEntanglement.ToString());
            if (MovePiece(b2, potentialPos))
            {
                b2 = potentialPos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var potentialPos = new Tuple<int, int>(b1.Item1, Modulo(b1.Item2 + 1, gridWidth));
            if (MovePiece(b1, potentialPos))
            {
                b1 = potentialPos;
            }

            potentialPos = GetEntanglementPos(b2, bRightEntanglement.ToString());
            if (MovePiece(b2, potentialPos))
            {
                b2 = potentialPos;
            }
        }
    }

    bool MovePiece(Tuple<int, int> currentPos,  Tuple<int, int> newPos)
    {
        //check available space
        if (matrix[newPos.Item1][newPos.Item2] != " ")
        {
            return false;
        }

        //change matrix values
        matrix[newPos.Item1][newPos.Item2] = matrix[currentPos.Item1][currentPos.Item2];
        matrix[currentPos.Item1][currentPos.Item2] = " ";

        //update visual matrix
        int currestCell = currentPos.Item1 * gridWidth + currentPos.Item2;
        int newCell = newPos.Item1 * gridWidth + newPos.Item2;

        transform.GetChild(currestCell).GetChild(0).SetParent(transform.GetChild(newCell));

        return true;
    }

    Tuple<int, int> GetEntanglementPos(Tuple<int, int> currentPos, string direction)
    {
        if(direction == "Up")
        {
            return new Tuple<int, int>(Modulo(currentPos.Item1 - 1, gridLenght), currentPos.Item2);
        }
        else if(direction == "Down")
        {
            return new Tuple<int, int>(Modulo(currentPos.Item1 + 1, gridLenght), currentPos.Item2);
        }
        else if(direction == "Left")
        {
            return new Tuple<int, int>(currentPos.Item1, Modulo(currentPos.Item2 - 1, gridWidth));
        }
        else if(direction == "Right")
        {
            return new Tuple<int, int>(currentPos.Item1, Modulo(currentPos.Item2 + 1, gridWidth));
        }
        else
        {
            return currentPos;
        }
    }

    int Modulo(int a, int b)
    {
        if(a >= 0)
        {
            return a % b;
        }
        else
        {
            return b - ((a * -1) % b);
        }
    }

    bool CheckWinCondition()
    {
        int tests = 0;

        if(a1.Item1 == a1WinPos.line && a1.Item2  == a1WinPos.column)
        {
            tests++;
        }

        if (a2.Item1 == a2WinPos.line && a2.Item2 == a2WinPos.column)
        {
            tests++;
        }

        if (b1.Item1 == b1WinPos.line && b1.Item2 == b1WinPos.column)
        {
            tests++;
        }

        if (b2.Item1 == b2WinPos.line && b2.Item2 == b2WinPos.column)
        {
            tests++;
        }

        if(tests >= 4)
        {
            return true;
        }
        return false;
    }

    void WinAction()
    {
        Debug.Log("YOU WON!!!");

        foreach (var obj in objectsToChangeColor)
        {
            var textComponent = obj.GetComponent<TMP_Text>();
            if (textComponent != null)
            {
                textComponent.color = winColor;
            }
        }
        CloseCanvas();
    }

    public void Reset()
    {
        //Move letters to end of matrix
        int currestCell = a1.Item1 * gridWidth + a1.Item2;
        transform.GetChild(currestCell).GetChild(0).SetParent(transform.GetChild(gridLenght * gridWidth));

        currestCell = a2.Item1 * gridWidth + a2.Item2;
        transform.GetChild(currestCell).GetChild(0).SetParent(transform.GetChild(gridLenght * gridWidth + 1));

        currestCell = b1.Item1 * gridWidth + b1.Item2;
        transform.GetChild(currestCell).GetChild(0).SetParent(transform.GetChild(gridLenght * gridWidth + 2));

        currestCell = b2.Item1 * gridWidth + b2.Item2;
        transform.GetChild(currestCell).GetChild(0).SetParent(transform.GetChild(gridLenght * gridWidth + 3));

        //Reset matrix
        for(int i = 0; i < gridLenght; i++)
        {
            for(int j = 0;  j < gridWidth; j++)
            {
                matrix[i][j] = initialMatrix[i][j];
            }
        }

        //Reset letters posistions
        a1 = a1Initial;
        a2 = a2Initial;
        b1 = b1Initial;
        b2 = b2Initial;

        //Move letters to initial positions
        int newCell = a1.Item1 * gridWidth + a1.Item2;
        transform.GetChild(gridLenght * gridWidth).GetChild(0).SetParent(transform.GetChild(newCell));

        newCell = a2.Item1 * gridWidth + a2.Item2;
        transform.GetChild(gridLenght * gridWidth + 1).GetChild(0).SetParent(transform.GetChild(newCell));

        newCell = b1.Item1 * gridWidth + b1.Item2;
        transform.GetChild(gridLenght * gridWidth + 2).GetChild(0).SetParent(transform.GetChild(newCell));

        newCell = b2.Item1 * gridWidth + b2.Item2;
        transform.GetChild(gridLenght * gridWidth + 3).GetChild(0).SetParent(transform.GetChild(newCell));
    }

    private void CloseCanvas()
    {
        gameCanvas.gameObject.SetActive(false);

        if (openMinigame != null)
        {
            openMinigame.CloseCanvas();
        }
        else
        {
            Debug.LogWarning("OpenMinigame reference is not assigned.");
        }
    }
}
