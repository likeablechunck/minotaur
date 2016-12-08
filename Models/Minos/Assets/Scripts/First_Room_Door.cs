using UnityEngine;
using System.Collections;

public class First_Room_Door : MonoBehaviour
{
    public float doorLimit;
    public float speed;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.Find("FPSController");
        GameObject gameMusicController = GameObject.Find("FirstPersonCharacter");
        if (player.GetComponent<Player_Controller>().shouldICloseTheFirstDoor)
        {
            gameMusicController.GetComponent<GameMusic>().changeState("CloseDoor");
            if (this.transform.position.y > doorLimit)
            {
                transform.Translate(0, -speed, 0);
            }
        }
        else
        {
            this.transform.position = new Vector3(24.8f, 7f, 0.67f);
        }
        if(player.GetComponent<Player_Controller>().shouldIOpenTheAtriumDoor &&
            this.transform.position.y <= doorLimit)
        {
            transform.Translate(0, speed, 0);

        }

    }
}
