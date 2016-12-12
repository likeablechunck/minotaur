using UnityEngine;
using System.Collections;

public class Light_Relocation : MonoBehaviour {

    public bool canPickUp;
    public bool canDropOff;
    public bool alreadyHasLight;
    public bool lightInstantiated;
    public GameObject flame;
    public GameObject rHandSocket;
    public AudioSource source;
    public AudioClip pickUpFireClip;

    // Use this for initialization
    void Start()
    {
        rHandSocket = GameObject.Find("RHandSocket");
        canPickUp = false;
        canDropOff = false;
        alreadyHasLight = false;
        lightInstantiated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //GameObject flame = GameObject.Find("Fire-1");
        if (flame != null && flame.GetComponent<RedFlame>() != null )
        {
            if (canPickUp && Input.GetKeyUp(KeyCode.Q))
            {
                source.clip = pickUpFireClip;
                source.Play();
                flame.GetComponent<RedFlame>().changeState("pickedUp");
                //PickUp();
            }
            if (canPickUp && Input.GetKeyUp(KeyCode.Z))
            {
                flame.GetComponent<RedFlame>().changeState("dropOff");

            }
        } else
        {
            print(GameObject.Find("Fire-1"));
        }



        //if (!alreadyHasLight)
        //{
        //    //When you are close AND you press Q AND there is no light instantiated
        //    if (canPickUp && Input.GetKeyUp(KeyCode.Q) && !lightInstantiated)
        //    {
        //        PickUp();
        //    }
        //}

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
    void PickUp()
    {
        this.transform.position = rHandSocket.transform.position;
        this.transform.rotation = rHandSocket.transform.rotation;
        this.transform.parent = rHandSocket.transform;



        ////when it picks up, it should get stuck to RHandSocket
        ////Therefore, this transform position changes to RHandSocket's position
        ////Vector3 flamePosition = rHandSocket.transform.position;
        //GameObject redFlame = Instantiate(Resources.Load("Fire (Complex)")) as GameObject;
        //redFlame.transform.position = rHandSocket.transform.position;
        ////Try to instamtiate one light at a time
        //lightInstantiated = true;
        ////redFlame.transform.rotation = rHandSocket.transform.rotation;
        ////redFlame.transform.parent = rHandSocket.transform;
    }
}
