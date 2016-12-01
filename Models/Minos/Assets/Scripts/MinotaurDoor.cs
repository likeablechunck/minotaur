using UnityEngine;
using System.Collections;

public class MinotaurDoor : MonoBehaviour
{
    public Vector3 initialLocation;
    public float doorLimit;
    public float speed;

	// Use this for initialization
	void Start ()
    {
        this.transform.position = initialLocation;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.Find("FPSController");
        if (this.transform.position.x > doorLimit &&
            player.GetComponent<Player_Controller>().shouldIOpenTheMinotaurDoor)
        {
            this.transform.Translate(-speed, 0, 0);
        }
        else
        {
            transform.position = initialLocation;
        }

    }
}
