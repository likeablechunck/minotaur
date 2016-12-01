using UnityEngine;
using System.Collections;

public class SafeRoomDoor : MonoBehaviour
{
    public float doorLimit;
    public float speed;

	// Use this for initialization
	void Start ()
    {
        this.transform.position = new Vector3(49.4f, 2f, -90.42f);
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.Find("FPSController");
        if (this.transform.position.z < doorLimit &&
            player.GetComponent<Player_Controller>().ShouldICloseTheDoorToTheSafeRoom)
        {
            this.transform.Translate(0, 0, speed);
        }
	
	}
}
