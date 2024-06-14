using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource music;
    public float transitionDuration;
    public Animator fadeAnimator;
    public string sceneToGoName;
    // Start is called before the first frame update
    void Start()
    {
        music.time = 25f;
        music.Play();
    }

    // Update is called once per frame
    public void ChangeScene()
    {
        StartCoroutine(change());
    }

    public IEnumerator change()
    {
        fadeAnimator.SetTrigger("end");
        yield return new WaitForSeconds(transitionDuration);
        SceneManager.LoadScene(sceneToGoName);

    }
}
