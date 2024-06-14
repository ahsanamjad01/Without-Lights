using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSoundRigidbody : MonoBehaviour
{

    public AudioClip impact;

    void OnCollisionEnter(Collision col)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(impact, col.relativeVelocity.magnitude);
    }
}
