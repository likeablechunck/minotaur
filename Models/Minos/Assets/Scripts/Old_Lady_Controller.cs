using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class Old_Lady_Controller : MonoBehaviour
{
    public float gameTimer;
    //public float cameraVignetteIntensity;

	// Use this for initialization
	void Start ()
    {
        //Make sure to set the Game Timer in the inspector

    }
	
	// Update is called once per frame
	void Update ()
    {
        //float cameraVignetteIntensity = this.GetComponent<VignetteAndChromaticAberration>().intensity;
        print("Vignetting intensity : " + this.GetComponent<VignetteAndChromaticAberration>().intensity);
        GameObject player = GameObject.Find("FPSController");
        print("Game time is at : " + gameTimer);
        if(gameTimer >0)
        {
            if (player.GetComponent<Player_Controller>().shouldIStopTheTimer == false)
            {
                gameTimer -= Time.deltaTime;

            }
            else
            {
                gameTimer -= 0;
            }

        }
        else
        {
            //1)Music should stop
            player.GetComponent<AudioSource>().Stop();
            //2)Vignette effect
            this.GetComponent<VignetteAndChromaticAberration>().intensity += Time.deltaTime;
            //when camera completely faded
            //3)load the scene again
            if (this.GetComponent<VignetteAndChromaticAberration>().intensity >= 1)
            {
                LoadScene();
            }             
        }      	
	}
    public void LoadScene()
    {
        SceneManager.LoadScene("Old_Lady");
    }
}
