using UnityEngine;
using System.Collections;

public class LastDoor_InSafePassage : MonoBehaviour
{
    public float doorLimit;
    public float speed;
    public Vector3 initialDoorLocation;

    // Use this for initialization
    void Start ()
    {
        this.transform.position = initialDoorLocation;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.Find("FPSController");
        if (this.transform.position.x < doorLimit &&
            player.GetComponent<Player_Controller>().shouldIOpenTheLastDoor)
        {
            this.transform.Translate(speed, 0, 0);
        }

    }
}
