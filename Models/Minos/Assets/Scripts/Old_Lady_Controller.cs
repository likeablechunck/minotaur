using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class Old_Lady_Controller : MonoBehaviour
{
    private FMOD.Studio.EventInstance musicEvent;
    private FMOD.Studio.ParameterInstance minotaurBreath;
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
                if(gameTimer <=12 && gameTimer > 9 )
                {
                    
                }

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
    //private FMOD.Studio.EventInstance musicEvent;
    //The parameter in FMOD is called "Intensity"
    //to access the parameter of FMOD you can do this:
    //musiscEvent.setParameter("ParamName", float value);
    //musiscEvent.setParameter("minotaurBreath", float value);
}
