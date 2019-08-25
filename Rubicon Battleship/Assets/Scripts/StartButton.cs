using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    float OriginalY;

    // Start is called before the first frame update
    void Start()
    {
        OriginalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (ReadyToStart())
            transform.position = new Vector3(transform.position.x, OriginalY, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, OriginalY + 1000, transform.position.z);

    }

    public bool ReadyToStart()
    {
        var moveQueques = Component.FindObjectsOfType<MoveQueque>();

        var foo = moveQueques.Select(q => new { MoveQueque = q, PawnState = q.GetComponent<PawnState>() });

        return foo.All(x => x.MoveQueque.MoveCountSum() == x.PawnState.GetMaxMoves() || (x.PawnState.veteran && x.MoveQueque.MoveCountSum() == x.PawnState.GetMaxMoves() - 1));
    }

    [ContextMenu("Start")]
    public void StartGame()
    {
        Debug.Log("TODO: The rest of the game");
    }
}
