using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Player1;
    public GameObject Player2;

    int CurrentPlayer = 1;

    // Start is called before the first frame update
    void Start()
    {
            CurrentPlayer = 1;
            Camera.transform.position = Player1.transform.position;
            Camera.transform.rotation = Player1.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [ContextMenu("Switch")]
    public void Switch(){
        if(CurrentPlayer == 1){
            CurrentPlayer = 2;
            Camera.transform.position = Player2.transform.position;
            Camera.transform.rotation = Player2.transform.rotation;
        }
        else
        {
            CurrentPlayer = 1;
            Camera.transform.position = Player1.transform.position;
            Camera.transform.rotation = Player1.transform.rotation;
        }
    }
}
