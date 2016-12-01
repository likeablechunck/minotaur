using UnityEngine;
using System.Collections;

public class SafeRoomDoor : MonoBehaviour
{
    public float doorLimit;
    public float speed;

	// Use this for initialization
	void Start ()
    {
        this.transform.position = new Vector3(115.4f, 2.8f, -34.8f);
        //this.transform.position = new Vector3(0 , 0, 0);

    }
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.Find("FPSController");
        if (this.transform.position.z < doorLimit &&
            player.GetComponent<Player_Controller>().ShouldICloseTheDoorToTheSafeRoom)
        {
            this.transform.Translate(0, 0,-speed);
        }
	
	}
}
