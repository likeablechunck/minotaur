using UnityEngine;
using System.Collections;
[RequireComponent (typeof (AudioSource))]

public class Opening_Video : MonoBehaviour
{
    public MovieTexture movieText;
	// Use this for initialization
	void Start ()
    {
        this.GetComponent<Renderer>().material.mainTexture = movieText as MovieTexture;
        movieText.Play();
	
	}
	
	
}
