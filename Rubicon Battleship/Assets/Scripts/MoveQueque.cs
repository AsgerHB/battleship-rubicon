using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Direction { Up, Down, Left, Right}

[System.Serializable]
public class Move {
    public Direction Direction;
    public int Count;
}

[RequireComponent(typeof(PawnState))]
public class MoveQueque : MonoBehaviour
{
    public List<Move> Queque = new List<Move>();
    public TextMesh TextTarget;

    PawnState PawnState;

    public void AddMove(Direction direction){
        if (MoveCountSum() == PawnState.GetMaxMoves())
        {
            Debug.Log("Move count exceeded");
            return;
        }

        PawnState = transform.GetComponent<PawnState>();

        if(Queque.Count() != 0 && Queque.Last().Direction == direction){
            Queque.Last().Count++;
        }
        else
        {
            Queque.Add(new Move { Count = 1, Direction = direction});
        }

        if (TextTarget != null)
            TextTarget.text = ToString();

    }

    public int MoveCountSum()
    {
        var count = 0;
        foreach (var move in Queque)
        {
            count += move.Count;
        }

        return count;
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        Queque.Clear();

        if (TextTarget != null)
            TextTarget.text = ToString();
    }

    [ContextMenu("North")]
    public void North(){
        AddMove(Direction.Up);
    }

    
    [ContextMenu("South")]
    public void South(){
        AddMove(Direction.Down);
    }

    
    [ContextMenu("West")]
    public void West(){
        AddMove(Direction.Left);
    }
    
    
    [ContextMenu("East")]
    public void East(){
        AddMove(Direction.Right);
    }

    // Start is called before the first frame update
    void Start()
    {
        PawnState = gameObject.GetComponent<PawnState>();
        if (TextTarget != null)
            TextTarget.text = ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string ToString()
    {
        var result = "";

        if (PawnState.veteran)
            result = result + "♦ ";
        else
            result = result + "● ";
 
        foreach(var move in Queque)
        {
            result = result + move.Count.ToString();

            if (move.Direction == Direction.Up)
                result = result + "↑";
            if (move.Direction == Direction.Down)
                result = result + "↓";
            if (move.Direction == Direction.Left)
                result = result + "←";
            if (move.Direction == Direction.Right)
                result = result + "→";

            if (Queque.Last() != move)
                result = result + "│  ";
        }
        return result; 
    }
}
