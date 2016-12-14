using UnityEngine;
using System.Collections;

public class Minotaur_Breathing_Instantiation : MonoBehaviour
{
    public AudioSource minotaurSource;
    public AudioClip minotaurBreathClip1;
    public AudioClip minotaurBreathClip2;
    public AudioClip minotaurBreathClip3;
    public AudioClip minotaurBreathClip4;
    private float timeInterval;
    public bool playedOnce;
    int bufferAmount;
    float initialGameTimer;
    int minotaurEmitterValueOverTime;



    // Use this for initialization
    void Start ()
    {
        playedOnce = false;
        GameObject player = GameObject.Find("FirstPersonCharacter");
        initialGameTimer = player.GetComponent<Old_Lady_Controller>().gameTimer;
        minotaurEmitterValueOverTime = 1;
        timeInterval = player.GetComponent<Old_Lady_Controller>().gameTimer / 4; //changed to 3 so it will be same as heartbeat
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject fpc = GameObject.Find("FPSController");
        GameObject player = GameObject.Find("FirstPersonCharacter");

        if(fpc.GetComponent<Player_Controller>().shouldIStartTheTimer)
        {
            if (!playedOnce)
            {
                minotaurSource.clip = minotaurBreathClip1;
                minotaurSource.Play();
                playedOnce = true;
            }


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
                        minotaurEmitterValueOverTime++;
                        
                        this.transform.position = player.transform.position;
                      
                        if (minotaurEmitterValueOverTime == 2)
                        {
                            minotaurSource.clip = minotaurBreathClip2;
                            minotaurSource.Play();
                        }
                        if (minotaurEmitterValueOverTime == 3)
                        {
                            minotaurSource.clip = minotaurBreathClip3;
                            minotaurSource.Play();
                       
                        }
                        if (minotaurEmitterValueOverTime == 4)
                        {
                            minotaurSource.clip = minotaurBreathClip4;
                            minotaurSource.Play();
                           
                        }

                        initialGameTimer -= timeInterval;
                    }
                }
                if (fpc.GetComponent<Player_Controller>().shouldIStopTheTimer)
                {
                    minotaurSource.Stop();
                }
            }
        }        
    }
    public void minotaurReset()
    {
        playedOnce = false;
        minotaurEmitterValueOverTime = 1;
    }
}
