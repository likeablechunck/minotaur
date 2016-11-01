using UnityEngine;
using System.Collections;

public class RedFlame : MonoBehaviour
{
    public GameObject rHandSocket;

    // Use this for initialization
    void Start ()
    {
        rHandSocket = GameObject.Find("RHandSocket");

    }
	
	// Update is called once per frame
	void Update ()
    {
        RedFlameLocation();

        if(Input.GetKeyUp(KeyCode.E))
        {
            Destroy(this.gameObject);

        }
	
	}
    void RedFlameLocation()
    {
        this.transform.position = rHandSocket.transform.position;
        this.transform.rotation = rHandSocket.transform.rotation;
        this.transform.parent = rHandSocket.transform;
    }
}
