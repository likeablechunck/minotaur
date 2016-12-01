using UnityEngine;
using System.Collections;

public class SafePassageDoor : MonoBehaviour
{
    public float doorLimit;
    public float speed;

    // Use this for initialization
    void Start ()
    {
        this.transform.position = new Vector3(115.4f, -9.76f, -28f);

    }
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.Find("FPSController");
        if (this.transform.position.z > doorLimit &&
            player.GetComponent<Player_Controller>().shouldIOpenTheDoorToSafePassage)
        {
            this.transform.Translate(0, 0, speed);
        }

    }
}
