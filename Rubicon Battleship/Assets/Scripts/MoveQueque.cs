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

public class MoveQueque : MonoBehaviour
{
    public List<Move> Queque = new List<Move>();
    public PawnState State;

    public void AddMove(Direction direction){
        Debug.Log(Queque.Count());
        if (MoveCountSum() == State.GetMaxMoves())
        {
            Debug.Log("Move count exceeded");
            return;
        }

        State = transform.GetComponent<PawnState>();

        if(Queque.Count() != 0 && Queque.Last().Direction == direction){
            Queque.Last().Count++;
        }
        else
        {
            Queque.Add(new Move { Count = 1, Direction = direction});
        }

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

    [ContextMenu("Up")]
    public void Up(){
        AddMove(Direction.Up);
    }

    
    [ContextMenu("Down")]
    public void Down(){
        AddMove(Direction.Down);
    }

    
    [ContextMenu("Left")]
    public void Left(){
        AddMove(Direction.Left);
    }
    
    
    [ContextMenu("Right")]
    public void Right(){
        AddMove(Direction.Right);
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
