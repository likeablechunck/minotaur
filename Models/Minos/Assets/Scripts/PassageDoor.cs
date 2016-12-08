using UnityEngine;
using System.Collections;

public class PassageDoor : MonoBehaviour
{
  
    public float doorLimit;
    public float speed;
    public bool openTheDoor;

    // Use this for initialization
    void Start ()
    {
        
        openTheDoor = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.Find("FPSController");
        GameObject gameMusicController = GameObject.Find("FirstPersonCharacter");
        if (openTheDoor)
        {
            gameMusicController.GetComponent<GameMusic>().changeState("OpenDoor");
            print("I changed the GameMusic state");
            if (this.transform.position.y < doorLimit)
            {
                //door_emitter.SetParameter("Play", 1);
                transform.Translate(0, speed, 0);
                    
            }
            else
                {
                    openTheDoor = false;
                }
        }

    }
}
