using UnityEngine;
using System.Collections;

public class SwordActivate : MonoBehaviour {
    public bool isClicked;
    //private FMODUnity.StudioParameterTrigger swordEvent;
    //public FMODUnity.StudioEventEmitter swordMusicEmitter;

    // Use this for initialization
    void Start ()
    {
        //isClicked = false;
	
	}

    // Update is called once per frame
    void Update()
    {



    }
    void OnTriggerEnter(Collider col)
    {
        print("I collided into sword XD");
        if(col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        
        //swordEvent = this.GetComponent<FMODUnity.StudioParameterTrigger>();
        //swordMusicEmitter.SetParameter("Intensity", 1f);


    }
}
