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
        if (player.GetComponent<Player_Controller>().shouldICloseTheFirstDoor)
        {
            if (this.transform.position.y > doorLimit)
            {
                transform.Translate(0, -speed, 0);
            }
        }

    }
}
