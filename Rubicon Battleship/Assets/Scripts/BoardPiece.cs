using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPiece : MonoBehaviour
{
    public int Row;
    public int Column;


    public Board Board;

    public Vector2 PlaceAt(int row, int column){
        Row = row;
        Column = column;
        var x = (Board.Width / Board.Columns) * column;
        var z = (Board.Height / Board.Rows) * row;

        return transform.position = new Vector3(x, 0, z);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
