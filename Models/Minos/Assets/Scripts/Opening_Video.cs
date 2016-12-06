using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//[RequireComponent (typeof (AudioSource))]

public class Opening_Video : MonoBehaviour
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
        //this.GetComponent<Renderer>().material.mainTexture = movieText as MovieTexture;
        //movieText.Play();
	
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
        yield return new WaitForSeconds(35f);
        SceneManager.LoadScene("Main_Complete");
    }
	
}
