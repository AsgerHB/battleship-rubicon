using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour

{
    public void foo()
    {
        Debug.Log("start");
        if (Active == true)
        {
            Active = false;
        }
        else
        {
            Active = true;
        }
        
        
    }

    public GameObject ArrowN;
    public GameObject ArrowS;
    public GameObject ArrowE;
    public GameObject ArrowW;

    public bool Active;

    void Update()
    {
        ArrowN.SetActive(Active);
        ArrowS.SetActive(Active);
        ArrowE.SetActive(Active);
        ArrowW.SetActive(Active);
    }
}