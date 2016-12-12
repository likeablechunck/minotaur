using UnityEngine;
using System.Collections;

public class Quit_Button : MonoBehaviour
{


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void OnClick()
    {
        Application.Quit();
    }
}
