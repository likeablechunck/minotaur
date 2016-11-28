using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class Old_Lady_Controller : MonoBehaviour
{
    //private FMOD.Studio.EventInstance musicEvent;
    //private FMOD.Studio.ParameterInstance minotaurBreath;
    private FMODUnity.StudioEventEmitter heartBeat_emitter;
    public float emitterInitialValue;
    public float emitterValueOverTime;
    public float gameTimer;
    public float initialGameTimer;
    public float timeInterval;
    //public float cameraVignetteIntensity;

	// Use this for initialization
	void Start ()
    {
        //Make sure to set the Game Timer in the inspector
        heartBeat_emitter = this.GetComponent<FMODUnity.StudioEventEmitter>();
        emitterInitialValue = 0.5f;
        heartBeat_emitter.SetParameter("Heart Beat", emitterInitialValue);
        emitterValueOverTime = emitterInitialValue;
        initialGameTimer = gameTimer;
        timeInterval = gameTimer / 3;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //emitter.SetParameter("Intensity", emitterInitialValue);
        print("Vignetting intensity : " + this.GetComponent<VignetteAndChromaticAberration>().intensity);
        GameObject player = GameObject.Find("FPSController");
        print("Game time is at : " + gameTimer);
        if(gameTimer >0)
        {
            if (player.GetComponent<Player_Controller>().shouldIStopTheTimer == false)
            {
                gameTimer -= Time.deltaTime;
                if(initialGameTimer - gameTimer >= timeInterval)
                {
                    print("Difference is now set");
                    if(emitterValueOverTime <=3)
                    {
                        print("I am about to increase the parameter value");
                        emitterValueOverTime = increaseFMODParameter(emitterValueOverTime);
                        heartBeat_emitter.SetParameter("Heart Beat", emitterValueOverTime);
                        print("I added and now parameter val is : " + emitterValueOverTime);
                    }
                    else
                    {
                        emitterValueOverTime = 2.9f;
                    }
                    initialGameTimer -= timeInterval;
                    print("Initial Game Time is : " + initialGameTimer);
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
    //Increase the parameter value by one
    public float increaseFMODParameter(float currentParameterValue)
    {
        return currentParameterValue + 1;
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

    //If you wish to trigger parameter changes from code set the option to None.Then in a script attached to the same Game Object add the line
    //GetComponent<FMODUnity.StudioParameterTrigger>().TriggerParameters();
}
