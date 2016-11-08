using UnityEngine;
using System.Collections;

public class Light_Relocation : MonoBehaviour {

    public bool canPickUp;
    public bool alreadyHasLight;
    public bool lightInstantiated;

    public GameObject rHandSocket;

    // Use this for initialization
    void Start()
    {
        rHandSocket = GameObject.Find("RHandSocket");
        canPickUp = false;
        alreadyHasLight = false;
        lightInstantiated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!alreadyHasLight)
        {
            //When you are close AND you press Q AND there is no light instantiated
            if (canPickUp && Input.GetKeyUp(KeyCode.Q) && !lightInstantiated)
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
        //Try to instamtiate one light at a time
        lightInstantiated = true;
        //redFlame.transform.rotation = rHandSocket.transform.rotation;
        //redFlame.transform.parent = rHandSocket.transform;
    }
}
