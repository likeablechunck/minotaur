using UnityEngine;
using System.Collections;

public class PassageDoor : MonoBehaviour
{
  
    public float doorLimit;
    public float speed;
    public bool openTheDoor;
    public Vector3 initialLocation;

    // Use this for initialization
    void Start ()
    {
        initialLocation = this.transform.position;
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
                
                transform.Translate(0, speed, 0);
                    
            }
            else
                {
                    openTheDoor = false;
                }
        }

    }
}
