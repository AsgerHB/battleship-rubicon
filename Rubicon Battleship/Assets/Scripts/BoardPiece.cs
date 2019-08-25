using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPiece : MonoBehaviour
{
    public int Row;
    public int Column;


    Board Board;
    
    // Start is called before the first frame update
    void Start()
    {
        Board = Component.FindObjectOfType<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = (Board.Width / Board.Columns) * Column;
        var z = (Board.Height / Board.Rows) * Row;

        transform.position = new Vector3(x, 0, z);

    }

    [ContextMenu("Update")]
    public void EditorUpdate(){
        Board = Component.FindObjectOfType<Board>();
        var x = (Board.Width / Board.Columns) * Column;
        var z = (Board.Height / Board.Rows) * Row;

        transform.position = new Vector3(x, 0, z);

    }
}
