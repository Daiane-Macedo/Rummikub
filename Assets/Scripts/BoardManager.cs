using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    List<Set> sets = new List<Set>();

    private void Start ()
    {

    }

    private void Update ()
    {
        DrawBoard();
    }

    private void DrawBoard ()
    {
        Vector2 widthLine = Vector2.right * 18;
        Vector2 heigthLine = Vector2.up * 12;

        for (int i = 0; i <= 8; i++)
        {
            Vector2 start = Vector2.up * i;
            Debug.DrawLine(start * 1.5f, (start *1.5f) + widthLine);
            for (int j = 0; j <= 18; j++)
            {
                start = Vector2.right * j;
                Debug.DrawLine(start, start + heigthLine);
            }
        }
    }

}
