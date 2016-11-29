using UnityEngine;
using System.Collections;

public class Minotaur_Breathing_Instantiation : MonoBehaviour
{
    private FMODUnity.StudioEventEmitter minotaurBreathing_emitter;
    public float timeInterval;
    public GameObject player;
    int randomParameter;
    int bufferAmount;
    float initialGameTimer;


    // Use this for initialization
    void Start ()
    {
        //make sure to set up the time interval inside the inspector
        initialGameTimer = player.GetComponent<Old_Lady_Controller>().gameTimer;
        minotaurBreathing_emitter = this.gameObject.GetComponent<FMODUnity.StudioEventEmitter>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(player.GetComponent<Old_Lady_Controller>().gameTimer >=0)
        {
            print("Player's timer is at : " + player.GetComponent<Old_Lady_Controller>().gameTimer);
            print("Minotaur's timer is at : " + initialGameTimer);
            if (initialGameTimer - player.GetComponent<Old_Lady_Controller>().gameTimer >= timeInterval)
            {
                bufferAmount = Random.Range(0, 10);
                print("buffer amount is : " + bufferAmount);
                randomParameter = Random.Range(0, 4);
                print("FMOD random parameter is : " + randomParameter);
                this.transform.position = new Vector3(player.transform.position.x ,(player.transform.position.y) + bufferAmount, player.transform.position.z);
                print("empty GO location is at : " + this.transform.position);
                //why emitter doesn't work?
                //this.gameObject.GetComponent<FMODUnity.StudioParameterTrigger>().TriggerParameters();
                minotaurBreathing_emitter.SetParameter("Intensity", randomParameter);
                //if(!minotaurBreathing_emitter.IsPlaying())
                //{
                //    minotaurBreathing_emitter.Play();
                //}
                print("I did the emitter thingie");
                initialGameTimer -= timeInterval;
            }
            
        }	
	}
}
