using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightFollow : MonoBehaviour
{
    public GameObject goFollow;

    void Update()
    {
        transform.position = goFollow.transform.position;
        transform.rotation = goFollow.transform.rotation;
    }

}