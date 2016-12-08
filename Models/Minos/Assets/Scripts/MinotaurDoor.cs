using UnityEngine;
using System.Collections;

public class MinotaurDoor : MonoBehaviour
{
    public Vector3 initialLocation;
    public float doorLimit;
    public float speed;
    float timer;

	// Use this for initialization
	void Start ()
    {
        //this.transform.position = initialLocation;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.Find("FPSController");
        GameObject gameMusicController = GameObject.Find("FirstPersonCharacter");
        if (this.transform.position.x < doorLimit &&
            player.GetComponent<Player_Controller>().shouldIOpenTheMinotaurDoor)
        {
            gameMusicController.GetComponent<GameMusic>().changeState("OpenDoor");
            timer += Time.deltaTime;
            if (timer > 1.0f)
            {
                this.transform.Translate(-speed, 0, 0);
            }
        }
        //if(!player.GetComponent<Player_Controller>().shouldIOpenTheMinotaurDoor)
        //{
        //    transform.position = initialLocation;
        //}

    }
}
