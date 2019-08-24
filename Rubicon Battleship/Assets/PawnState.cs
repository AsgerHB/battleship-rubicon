using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnState : MonoBehaviour
{

    public int health;
    public bool veteran;
    
    public int GetMaxMoves()
    {
        if (veteran)
            return 5;
        else
            return 4;
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
