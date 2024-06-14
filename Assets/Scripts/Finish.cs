using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Finish : MonoBehaviour
{

    public Animator finishAnim;
    public FirstPersonMobileTools.DynamicFirstPerson.MovementController player;
    public FirstPersonMobileTools.DynamicFirstPerson.nonMobileInput cam;
    public FirstPersonMobileTools.DynamicFirstPerson.CameraLook cam2;
    public keyPickup1 keyScript;
    public Transform Camera;
    public bool finish;
    public Transform finishCamera;
    public float ElapsedTime;
    public float finishTime;
    public GameObject music;


    // Update is called once per frame
    void Update()
    {
        if(finish)
        {
            player.enabled = false;
            cam.enabled = false;
            cam2.enabled = false;
            ElapsedTime += Time.deltaTime;
            Camera.position = Vector3.Lerp(Camera.position, finishCamera.position, ElapsedTime / finishTime);
            Camera.rotation = Quaternion.Lerp(Camera.rotation, finishCamera.rotation, ElapsedTime / finishTime);
        }
        if(Vector3.Distance(Camera.position, finishCamera.position) < 0.001 && Quaternion.Angle(Camera.rotation, finishCamera.rotation) < 0.001 && finish)
        {
            StartCoroutine(Restart());
            finish = false;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "finishDoor")
        {
            if(keyScript.HasKey == true)
            {
                finish = true;
            }
        }
    }

    IEnumerator Restart()
    {
        finishAnim.gameObject.SetActive(true);
        DontDestroyOnLoad(music);
        yield return new WaitForSeconds(25f);
        SceneManager.LoadScene("MainMenu");
    }
}
