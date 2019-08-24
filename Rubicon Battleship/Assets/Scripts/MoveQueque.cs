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
    PawnState PawnState;

    public void AddMove(Direction direction){
        Debug.Log(Queque.Count());
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
        PawnState = gameObject.GetComponent<PawnState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
