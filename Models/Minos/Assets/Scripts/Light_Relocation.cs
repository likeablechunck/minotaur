using UnityEngine;
using System.Collections;

public class Light_Relocation : MonoBehaviour {

    public bool canPickUp;
    public bool alreadyHasLight;

    public GameObject rHandSocket;

    // Use this for initialization
    void Start()
    {
        rHandSocket = GameObject.Find("RHandSocket");
        canPickUp = false;
        alreadyHasLight = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!alreadyHasLight)
        {
            if (canPickUp && Input.GetKeyUp(KeyCode.Space))
            {
                CreateAFlame();
            }
        }

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            canPickUp = true;

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canPickUp = false;

        }
    }
    void CreateAFlame()
    {
        //when it picks up, it should get stuck to RHandSocket
        //Therefore, this transform position changes to RHandSocket's position
        //Vector3 flamePosition = rHandSocket.transform.position;
        GameObject redFlame = Instantiate(Resources.Load("Fire (Complex)")) as GameObject;
        redFlame.transform.position = rHandSocket.transform.position;
        //redFlame.transform.rotation = rHandSocket.transform.rotation;
        //redFlame.transform.parent = rHandSocket.transform;
    }
}
