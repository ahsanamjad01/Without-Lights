using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Death : MonoBehaviour
{

    public Animator _ghostAnim;
    public TMP_Text FirstTriggerQoute;
    public string[] Qoutes;
    public FirstPersonMobileTools.DynamicFirstPerson.MovementController player;
    public FirstPersonMobileTools.DynamicFirstPerson.nonMobileInput cam;
    public FirstPersonMobileTools.DynamicFirstPerson.CameraLook cam2;
    public AudioSource Scream;
    public AudioSource JumpScare;
    public FlashLightPickup TorchScript;
    public Transform Camera;
    public bool Dead;
    public Transform DeadCamera;
    public float ElapsedTime;
    public float FinishTime;


    // Update is called once per frame
    void Update()
    {
        if(Dead)
        {
            player.enabled = false;
            cam.enabled = false;
            cam2.enabled = false;
            ElapsedTime += Time.deltaTime;
            Camera.position = Vector3.Lerp(Camera.position, DeadCamera.position, ElapsedTime / FinishTime);
            Camera.rotation = Quaternion.Lerp(Camera.rotation, DeadCamera.rotation, ElapsedTime / FinishTime);
        }
        if(Vector3.Distance(Camera.position, DeadCamera.position) < 0.001 && Quaternion.Angle(Camera.rotation, DeadCamera.rotation) < 0.001 && Dead)
        {
            StartCoroutine(Restart());
            Dead = false;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Trigger1")
        {
            if(TorchScript.LightEnabled == false)
            {
                Dead = true;
            }
            else
            {
                _ghostAnim.SetTrigger("CrawlFast");
            }
        }
    }

    IEnumerator Restart()
    {
        _ghostAnim.SetTrigger("KillPlayer");
        JumpScare.Play();
        int RandomNo = Random.Range(0, Qoutes.Length - 1);
        FirstTriggerQoute.text = Qoutes[RandomNo];
        yield return new WaitForSeconds(1f);
        Scream.Play();
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
