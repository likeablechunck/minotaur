using UnityEngine;
using System.Collections;

public class Minotaur_Breathing_Instantiation : MonoBehaviour
{
    private FMODUnity.StudioEventEmitter minotaurBreathing_emitter;
    public AudioSource minotaurSource;
    private float timeInterval;
    //private GameObject player;
    //int randomParameter;
    int bufferAmount;
    float initialGameTimer;
    int minotaurEmitterValueOverTime;



    // Use this for initialization
    void Start ()
    {
        GameObject player = GameObject.Find("FirstPersonCharacter");
        initialGameTimer = player.GetComponent<Old_Lady_Controller>().gameTimer;
        minotaurBreathing_emitter = this.gameObject.GetComponent<FMODUnity.StudioEventEmitter>();
        minotaurEmitterValueOverTime = 1;
        timeInterval = player.GetComponent<Old_Lady_Controller>().gameTimer / 4; //changed to 3 so it will be same as heartbeat
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject fpc = GameObject.Find("FPSController");
        GameObject player = GameObject.Find("FirstPersonCharacter");

        if (player.GetComponent<Old_Lady_Controller>().gameTimer < 0)
        {
            minotaurSource.Stop();
        }
        else
        {
            if (minotaurEmitterValueOverTime <= 3 && !fpc.GetComponent<Player_Controller>().shouldIStopTheTimer)
            {

                if (initialGameTimer - player.GetComponent<Old_Lady_Controller>().gameTimer >= timeInterval)
                {
                    // increment the emiiterValuOverTime
                    // decrement initialGameTimer by timeIn terval
                    //change the location of the emitter and place it on top of the player
                    bufferAmount = Random.Range(0, 10);
                    this.transform.position = new Vector3(player.transform.position.x, (player.transform.position.y) + bufferAmount, player.transform.position.z);
                    if(minotaurEmitterValueOverTime ==1)
                    {
                        player.GetComponent<GameMusic>().changeState("minotaur1");

                    }
                    if(minotaurEmitterValueOverTime ==2)
                    {
                        player.GetComponent<GameMusic>().changeState("minotaur2");
                    }
                    if(minotaurEmitterValueOverTime == 3)
                    {
                        player.GetComponent<GameMusic>().changeState("minotaur3");

                    }
                    if(minotaurEmitterValueOverTime == 4)
                    {
                        player.GetComponent<GameMusic>().changeState("minotaur4");

                    }
                    minotaurEmitterValueOverTime++;
                    //minotaurBreathing_emitter.SetParameter("Intensity", minotaurEmitterValueOverTime);
                    //print("I passed this stupid parameter" + minotaurEmitterValueOverTime);
                    //if(!minotaurBreathing_emitter.IsPlaying())
                    //{
                    //    minotaurBreathing_emitter.Play();
                    //    print("parameter val that now I am using is : " + minotaurEmitterValueOverTime);
                    //}
                    //minotaurBreathing_emitter.Play();
                    initialGameTimer -= timeInterval;
                }
            }
            if (fpc.GetComponent<Player_Controller>().shouldIStopTheTimer)
            {
                minotaurSource.Stop();
            }
        }
    }
    //OLD CODE ASSUMING MINOTAUR'S BREATHING INTENSITY SHOULD BE RANDOM
    //if(player.GetComponent<Old_Lady_Controller>().gameTimer >=0)
    //{
    //    print("Player's timer is at : " + player.GetComponent<Old_Lady_Controller>().gameTimer);
    //    print("Minotaur's timer is at : " + initialGameTimer);
    //    if (initialGameTimer - player.GetComponent<Old_Lady_Controller>().gameTimer >= timeInterval)
    //    {
    //        bufferAmount = Random.Range(0, 10);
    //        print("buffer amount is : " + bufferAmount);
    //        this.transform.position = new Vector3(player.transform.position.x ,(player.transform.position.y) + bufferAmount, player.transform.position.z);
    //        print("empty GO location is at : " + this.transform.position);
    //        //why emitter doesn't work?
    //        //this.gameObject.GetComponent<FMODUnity.StudioParameterTrigger>().TriggerParameters();
    //        minotaurBreathing_emitter.SetParameter("Intensity", randomParameter);
    //        minotaurBreathing_emitter.Play();
    //        //randomParameter = Random.Range(0, 4);
    //        //print("FMOD random parameter is : " + randomParameter);

    //        print("I did the emitter thingie");
    //        initialGameTimer -= timeInterval;
    //    }

    //}	
}
