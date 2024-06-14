using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyPickup1 : MonoBehaviour
{
    public GameObject key;    
    private bool CanPickKey = false;
    public bool HasKey = false;
    public GameObject Trigger;

    void Update()
    {
        if(CanPickKey && Input.GetKeyDown("e"))
        {
            key.SetActive(false);
            HasKey = true;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        CanPickKey = true;
    }
    void OnTriggerExit(Collider col)
    {
        CanPickKey = false;
    }
}
