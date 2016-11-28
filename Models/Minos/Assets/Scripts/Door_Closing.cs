using UnityEngine;
using System.Collections;

public class Door_Closing : MonoBehaviour
{
    private FMODUnity.StudioEventEmitter door_emitter;
    public float speed;
    public float doorLimit;

	// Use this for initialization
	void Start ()
    {
        door_emitter = this.GetComponent<FMODUnity.StudioEventEmitter>();

        //Then set the speed in inspector
        //set the Door Limit


    }
	
	// Update is called once per frame
	void Update ()
    {
        print("Door's Y transform position is at : " + transform.position.y);
        if(this.transform.position.y > doorLimit)
        {

            transform.Translate(0, -speed, 0);
        }
     
	
	}
}
