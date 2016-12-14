using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class Old_Lady_Controller : MonoBehaviour
{
   
    public AudioSource source;
    public AudioClip heartBeatClip1;
    public AudioClip heartBeatClip2;
    public AudioClip heartBeatClip3;
    public bool playedOnce;
    public int counter;
    public float emitterInitialValue;
    public float emitterValueOverTime;
    public float testingValue;
    public float gameTimer;
    public float initialGameTimer;
    public float timeInterval;
    public float minVignetterIntensity;
    public float maxVignetteIntensity;
    public float vingetteSlope;
    //public bool emitterIsResetToInitial;
    public Vector3 playerInitialPositionInOldLadyRoom;
    public float currentIntensity;

    // Use this for initialization
    void Start()
    {
        //Make sure to set the Game Timer in the inspector
        playedOnce = false;
        counter = 1;
        playerInitialPositionInOldLadyRoom = new Vector3(17, 1.5f, 1.6f);
        emitterInitialValue = 0.5f;     
        emitterValueOverTime = emitterInitialValue;
        gameTimer = testingValue;
        initialGameTimer = gameTimer;
        timeInterval = gameTimer / 3;
        minVignetterIntensity = 0.036f;
        maxVignetteIntensity = 1f;
        vingetteSlope = (maxVignetteIntensity - minVignetterIntensity) / (0- testingValue); //calculating the slope for the function to find the correct intensity over time (slope = intensity/time)

    }

    // Update is called once per frame
    void Update()
    {

        //emitter.SetParameter("Intensity", emitterInitialValue);
        print("Vignetting intensity : " + this.GetComponent<VignetteAndChromaticAberration>().intensity);
        GameObject player = GameObject.Find("FPSController");

        if (player.GetComponent<Player_Controller>().shouldIStartTheTimer)
        {
            //1)set the heart beat to start playing from the lowest 
            if(!playedOnce)
            {
                source.clip = heartBeatClip1;
                source.Play();
                playedOnce = true;

            }
            //2)Vignette effect
            if (this.GetComponent<VignetteAndChromaticAberration>().intensity < maxVignetteIntensity)
            {
                print("camera vignette intensity is at : " + this.GetComponent<VignetteAndChromaticAberration>().intensity);
                currentIntensity = (vingetteSlope * gameTimer) - (vingetteSlope * testingValue) + minVignetterIntensity;
                this.GetComponent<VignetteAndChromaticAberration>().intensity = currentIntensity;
                //this.GetComponent<VignetteAndChromaticAberration>().intensity += vingetteSlope;
            }
            print("Game time is at : " + gameTimer);
            if (gameTimer < 0)
            {
                //1)Music should stop
                player.GetComponent<AudioSource>().Stop();
                if(source.isPlaying)
                {
                    source.Stop();
                }

                
                //this.GetComponent<VignetteAndChromaticAberration>().intensity += Time.deltaTime;
                //when camera completely faded
                //3)load the scene again
                if (this.GetComponent<VignetteAndChromaticAberration>().intensity >= 1)
                {
                    ResetPlayerPosition();
                }

            }
            else
            {

                if (counter <=3 && !player.GetComponent<Player_Controller>().shouldIStopTheTimer)
                {
                    print("I am adding counter for heart beat");
                    if(initialGameTimer - gameTimer >= timeInterval)
                    {
                        counter++;

                        //if (counter == 1)
                        //{
                        //    source.clip = heartBeatClip1;
                        //    source.Play();
                        //}
                        if (counter == 2)
                        {
                            source.clip = heartBeatClip2;
                            source.Play();
                        }
                        if(counter == 3)
                        {
                            source.clip = heartBeatClip3;
                            source.Play();
                        }
                        initialGameTimer -= timeInterval;
                        //counter++;
                    }
                }
             
                if (player.GetComponent<Player_Controller>().shouldIStopTheTimer)
                {
                    this.GetComponent<VignetteAndChromaticAberration>().intensity = minVignetterIntensity;
                    if (source.isPlaying)
                    {
                        source.Stop();
                    }
                
                }
                else
                {
                    gameTimer -= Time.deltaTime;
                }
            }

        }

    }
    public void ResetPlayerPosition()
    {
        //this function should technically do same as what Start() function does
        //it also tells the Player_Controller to reset the door's position and doesn't start the timer

        //It must call the Reset() function inside the Reset_Braziers script
        
        GameObject player = GameObject.Find("FPSController");
        player.transform.position = playerInitialPositionInOldLadyRoom;
        player.GetComponent<Player_Controller>().shouldIStartTheTimer = false;
        player.GetComponent<Player_Controller>().shouldICloseTheFirstDoor = false;
        //resetting the heartbeat music variables
        playedOnce = false;
        counter = 1;
        //resetting the timer to all initial values
        gameTimer = testingValue;
        initialGameTimer = gameTimer;
        timeInterval = gameTimer / 3;
        //resetting the vignette intensity values to the original vals
        minVignetterIntensity = 0.036f;
        maxVignetteIntensity = 1f;
        vingetteSlope = (maxVignetteIntensity - minVignetterIntensity) / (0 - testingValue);
        this.GetComponent<VignetteAndChromaticAberration>().intensity = minVignetterIntensity;
        //resetting the behaviours for all braziers
        player.GetComponent<Reset_Braziers>().Reset();
        //call the Minotaur Breathing function to reset
        GameObject minotaurBreathing = GameObject.Find("Minotaur_Breath_Controller");
        minotaurBreathing.GetComponent<Minotaur_Breathing_Instantiation>().minotaurReset();

    }
   
}
