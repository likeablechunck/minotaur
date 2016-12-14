using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class Old_Lady_Controller : MonoBehaviour
{
    //public FMODUnity.StudioEventEmitter heartBeat_emitter;
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
    //public bool emitterIsResetToInitial;
    public Vector3 playerInitialPositionInOldLadyRoom;
    
    //public float cameraVignetteIntensity;

    // Use this for initialization
    void Start()
    {
        //Make sure to set the Game Timer in the inspector
        //heartBeat_emitter = this.GetComponent<FMODUnity.StudioEventEmitter>();
        playedOnce = false;
        counter = 1;
        playerInitialPositionInOldLadyRoom = new Vector3(17, 1.5f, 1.6f);
        emitterInitialValue = 0.5f;
       // heartBeat_emitter.SetParameter("Heart Beat", emitterInitialValue);
        emitterValueOverTime = emitterInitialValue;
        gameTimer = testingValue;
        initialGameTimer = gameTimer;
        timeInterval = gameTimer / 3;
        //emitterIsResetToInitial = false;
    }

    // Update is called once per frame
    void Update()
    {

        //emitter.SetParameter("Intensity", emitterInitialValue);
        print("Vignetting intensity : " + this.GetComponent<VignetteAndChromaticAberration>().intensity);
        GameObject player = GameObject.Find("FPSController");

        if (player.GetComponent<Player_Controller>().shouldIStartTheTimer)
        {
            if(!playedOnce)
            {
                source.clip = heartBeatClip1;
                source.Play();
                playedOnce = true;

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
                //FMOD codes that didn't work for resetting
                //if (heartBeat_emitter.IsPlaying())
                //{
                //    heartBeat_emitter.Stop();
                //}

                //2)Vignette effect
                this.GetComponent<VignetteAndChromaticAberration>().intensity += Time.deltaTime;
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
                //if (emitterValueOverTime <= 2 && !player.GetComponent<Player_Controller>().shouldIStopTheTimer)
                //{
                //    print("emittervalu is : " + emitterValueOverTime);
                //    print("!player.GetComponent<Player_Controller>().shouldIStopTheTimer " + !player.GetComponent<Player_Controller>().shouldIStopTheTimer);
                //    //gameTimer -= Time.deltaTime;
                //    // for every 5 seconds we should increment emiiterValuOverTime
                //    // and decrement initialGameTimer by timeInterval
                //    if (initialGameTimer - gameTimer >= timeInterval)
                //    {
                //        // increment the emiiterValuOverTime
                //        // decrement initialGameTimer by timeIn terval
                //        emitterValueOverTime++;
                //        heartBeat_emitter.SetParameter("Heart Beat", emitterValueOverTime);
                //        initialGameTimer -= timeInterval;
                //    }
                //}
                if (player.GetComponent<Player_Controller>().shouldIStopTheTimer)
                {
                    if(source.isPlaying)
                    {
                        source.Stop();
                    }
                    //  reset the emitterValueOverTime back to initial value only once
                    // so we need a variable
                    
                    //if (!emitterIsResetToInitial)
                    //{
                    //    heartBeat_emitter.SetParameter("Heart Beat", emitterInitialValue);
                    //    emitterIsResetToInitial = true;
                    //}
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
        this.GetComponent<VignetteAndChromaticAberration>().intensity = 0.036f;
        GameObject player = GameObject.Find("FPSController");
        player.transform.position = playerInitialPositionInOldLadyRoom;
        player.GetComponent<Player_Controller>().shouldIStartTheTimer = false;
        player.GetComponent<Player_Controller>().shouldICloseTheFirstDoor = false;
        playedOnce = false;
        counter = 1;
        //heartBeat_emitter = this.GetComponent<FMODUnity.StudioEventEmitter>();
        //this.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("Heart Beat", 0.5f);
        //heartBeat_emitter = this.GetComponent<FMODUnity.StudioEventEmitter>();
        gameTimer = testingValue;
        initialGameTimer = gameTimer;
        timeInterval = gameTimer / 3;
        //emitterIsResetToInitial = false;// 
        //emitterInitialValue = 0.5f;
        //heartBeat_emitter.SetParameter("Heart Beat", emitterInitialValue);
        //emitterValueOverTime = emitterInitialValue;
        player.GetComponent<Reset_Braziers>().Reset();
        GameObject minotaurBreathing = GameObject.Find("Minotaur_Breath_Controller");
        minotaurBreathing.GetComponent<Minotaur_Breathing_Instantiation>().minotaurReset();

    }
   
}
