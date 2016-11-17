using UnityEngine;
using System.Collections;

public class Lighten_Brazier : MonoBehaviour {

    public bool canPickUp;
    public bool alreadyHasLight;
    public bool lightInstantiated;
    public GameObject flame;
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

        //GameObject flame = GameObject.Find("Fire-1");
        if (flame != null && flame.GetComponent<RedFlame>() != null)
        {
            if (canPickUp && Input.GetKeyUp(KeyCode.Q))
            {
                flame.GetComponent<RedFlame>().changeState("pickedUp");
                //PickUp();
            }
            
        }
        else
        {
            //print(GameObject.Find("Fire-1"));
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
}
