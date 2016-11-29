using UnityEngine;
using System.Collections;

public class Red_Flame_Relocation : MonoBehaviour
{
    public bool canPickUpRedFlame;
    public bool canDropOffRedFlame;
    public bool alreadyHasRedFlame;
    public bool lightInstantiated;
    public bool canIOpenTheDoor;
    //public GameObject redFlame;
    public GameObject rHandSocket;

    // Use this for initialization
    void Start ()
    {
        //In Inspector, assign the red flame associated with this brazier
        rHandSocket = GameObject.Find("RHandSocket");
        canIOpenTheDoor = false;
        canDropOffRedFlame = false;
        canPickUpRedFlame = false;
        alreadyHasRedFlame = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        GameObject redFlameInBrazier = GameObject.Find("fire_octagonal1");
        GameObject smallRedFlame = GameObject.Find("fire_octagonal_hand");
        if (canPickUpRedFlame)
        {       
            if (Input.GetKeyUp(KeyCode.E))
            {
                print("I pressed Q");
                smallRedFlame.GetComponent<ParticleSystem>().enableEmission = true;
                Destroy(redFlameInBrazier);

                smallRedFlame.GetComponent<RedFlame>().changeState("pickedUp");
            }
        }
        if (canDropOffRedFlame)
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                print("I pressed Z");

                smallRedFlame.GetComponent<RedFlame>().changeState("dropOff");
                GameObject redFlameInEmptyBrazier = Instantiate(Resources.Load("fire_octagonal")) as GameObject;
                GameObject currentLightHolder = GameObject.Find("Light_Holder1").gameObject;
                redFlameInEmptyBrazier.transform.position = currentLightHolder.transform.position;
                //redFlameInEmptyBrazier.transform.rotation = currentLightHolder.transform.rotation;
                redFlameInEmptyBrazier.transform.parent = currentLightHolder.transform;
                canIOpenTheDoor = true;
            }


        }
        //if (canPickUpRedFlame && Input.GetKeyUp(KeyCode.Q))
        //{
        //    redFlame.GetComponent<RedFlame>().changeState("pickedUp");
        //}
        //I Don't need to tell the empty brazier what to do. Let it handle the instantiation

        //if (redFlame != null && redFlame.GetComponent<RedFlame>() != null)
        //{
        //    if (canPickUpRedFlame && Input.GetKeyUp(KeyCode.Q))
        //    {
        //        redFlame.GetComponent<RedFlame>().changeState("pickedUp");
        //    }
        //}

    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Red_Flame_Brazier")
        {

            canPickUpRedFlame = true;
            ////GameObject redFlameInBrazier = col.transform.FindChild("fire_octagonal").gameObject;
            //GameObject redFlameInBrazier = GameObject.Find("fire_octagonal");
            ////GameObject player = GameObject.Find("FPSController");
            ////GameObject smallRedFlame = player.transform.FindChild("fire_octagonal_hand").gameObject;
            //GameObject smallRedFlame = GameObject.Find("fire_octagonal_hand");
            //if (Input.GetKeyUp(KeyCode.Q))
            //{
            //    print("I pressed Q");
            //    smallRedFlame.GetComponent<ParticleSystem>().enableEmission = true;
            //    Destroy(redFlameInBrazier);

            //    smallRedFlame.GetComponent<RedFlame>().changeState("pickedUp");
            //}


        }
        if (col.gameObject.tag == "Empty_Red_Brazier")
        {
            canDropOffRedFlame = true;
            //if(Input.GetKeyUp(KeyCode.Z))
            //{
            //    print("I pressed Z");
            //    GameObject smallRedFlame = GameObject.Find("fire_octagonal_hand");
            //    smallRedFlame.GetComponent<RedFlame>().changeState("dropOff");
            //    GameObject redFlameInBrazier = Instantiate(Resources.Load("fire_octagonal")) as GameObject;
            //    GameObject currentLightHolder = col.transform.FindChild("Light_Holder").gameObject;
            //    redFlameInBrazier.transform.position = currentLightHolder.transform.position;
            //    redFlameInBrazier.transform.rotation = currentLightHolder.transform.rotation;
            //    redFlameInBrazier.transform.parent = currentLightHolder.transform;

            //}

        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Red_Flame_Brazier")
        {
            canPickUpRedFlame = false;

        }
        if (col.gameObject.tag == "Empty_Red_Brazier")
        {
            canDropOffRedFlame = false;

        }
    }
}
