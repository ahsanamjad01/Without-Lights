using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightPickup : MonoBehaviour
{
    public GameObject FlashLight;    
    public GameObject PlayerSpotLight;
    public bool canEnableLight = false;
    public bool LightEnabled = false;
    public GameObject Trigger;
    public Vector3 TriggerPos;
    public keyPickup1 keyScript;

    void Update()
    {
        if(canEnableLight && Input.GetKeyDown("e"))
        {
            PlayerSpotLight.SetActive(true);
            FlashLight.SetActive(false);
            LightEnabled = true;
            Trigger.transform.position = TriggerPos;
            keyScript.enabled = true;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "RayCast")
        {
            canEnableLight = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "RayCast")
        {
            canEnableLight = false;
        }
    }
}
