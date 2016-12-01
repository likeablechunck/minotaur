using UnityEngine;
using System.Collections;

public class HiddenWall : MonoBehaviour
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
            player.GetComponent<Player_Controller>().shouldICloseTheHiddenWall)
        {
            this.transform.Translate(-speed, 0, 0);
        }
        

    }
}
