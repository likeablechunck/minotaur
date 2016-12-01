using UnityEngine;
using System.Collections;

public class Hallway_Blockage : MonoBehaviour {

    public float doorLimit;
    public float speed;
    public Vector3 initialDoorLocation;

    // Use this for initialization
    void Start()
    {
        this.transform.position = initialDoorLocation;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("FPSController");
        if (this.transform.position.z > doorLimit &&
            player.GetComponent<Player_Controller>().shouldIBlockTheHallway)
        {
            this.transform.Translate(0, 0, -speed);
        }

    }
}
