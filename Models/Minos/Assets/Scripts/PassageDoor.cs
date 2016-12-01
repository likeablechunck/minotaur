using UnityEngine;
using System.Collections;

public class PassageDoor : MonoBehaviour
{
    //private FMODUnity.StudioEventEmitter door_emitter;
    public float doorLimit;
    public float speed;
    public bool openTheDoor;

    // Use this for initialization
    void Start ()
    {
        //door_emitter = this.GetComponent<FMODUnity.StudioEventEmitter>();
        openTheDoor = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.Find("FPSController");
        if(openTheDoor)
        {
            if (this.transform.position.y < doorLimit)
            {
                //door_emitter.SetParameter("Play", 1);
                transform.Translate(0, speed, 0);
                    
            } else
                {
                    openTheDoor = false;
                }
        }

    }
}
