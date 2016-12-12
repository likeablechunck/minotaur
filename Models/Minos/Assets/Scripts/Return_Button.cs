using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Return_Button : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clickClip;

    // Update is called once per frame
    public void onClick()
    {
        source.clip = clickClip;
        source.Play();
        StartCoroutine(loadScene());

        //SceneManager.LoadScene("Start");
    }
    private IEnumerator loadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Start");
    }
}
