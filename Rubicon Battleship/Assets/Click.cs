using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Click : MonoBehaviour

{
    public UnityEvent Clicked;
    public Collider coll;

    void Start()
    {
        if (Clicked == null)
            Clicked = new UnityEvent();

        Clicked.AddListener(Pawn);
        coll = GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Clicked != null)
        {
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (coll.Raycast(ray, out hit, 100.0f))
            {
                Clicked.Invoke();
            } 
        }
    }

    void Pawn()
    {
        Debug.Log("ClickSelect");
    }
}
