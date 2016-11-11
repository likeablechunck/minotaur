using UnityEngine;
using System.Collections;

public class SwordActivate : MonoBehaviour {
    public bool isClicked;
    //public bool turnOnTheLight;
    //private FMODUnity.StudioParameterTrigger swordEvent;
    //public FMODUnity.StudioEventEmitter swordMusicEmitter;

    // Use this for initialization
    void Start ()
    {
        //turnOnTheLight = false;
        //isClicked = false;

    }

    // Update is called once per frame
    void Update()
    {



    }
    void OnTriggerEnter(Collider col)
    {
        print("I collided into sword XD");
        //if(col.gameObject.tag == "Player")
        //{
        //    //turnOnTheLight = true;
        //    Destroy(this.gameObject);
        //}
    }
}
