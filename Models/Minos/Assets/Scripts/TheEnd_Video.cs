using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TheEnd_Video : MonoBehaviour
{
    public MovieTexture movieText;
    RawImage imageComp;
    AudioSource source;

    // Use this for initialization
    void Start ()
    {
        imageComp = GetComponent<RawImage>();
        source = this.GetComponent<AudioSource>();
        PlayVideo();
        StartCoroutine(loadScene());

    }
    void PlayVideo()
    {
        imageComp.texture = movieText;
        movieText.Play();
        source.clip = movieText.audioClip;
        source.Play();
    }
    private IEnumerator loadScene()
    {
        yield return new WaitForSeconds(25f);
        SceneManager.LoadScene("Start");
    }
}
