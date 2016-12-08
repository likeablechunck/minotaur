using UnityEngine;
using System.Collections;

public class Red_Flame_Relocation : MonoBehaviour
{
    public bool canPickUpRedFlame;
    public bool canDropOffRedFlame;
    public bool alreadyHasRedFlame;
    public bool lightInstantiated;
    public bool canIOpenTheDoor;
    public GameObject dropOffLightHolder;
    public GameObject doorToOpen;
    public string collidedRedFlameName;
    public string collidedEmptyFlameName;
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
        
        GameObject smallRedFlame = GameObject.Find("fire_octagonal_hand");
        if (canPickUpRedFlame)
        {
            GameObject redFlameInBrazier = GameObject.Find(collidedRedFlameName);
            
            if (Input.GetKeyUp(KeyCode.E))
            {
                print("I pressed E");
                GameObject fireOctagonal = GameObject.Find(collidedRedFlameName + "_fire_octagonal1");
                
                // pick up if redFlame.BB.forPickup is true
                smallRedFlame.GetComponent<ParticleSystem>().enableEmission = true;
                // we should remember who the lightholder can be
                dropOffLightHolder = redFlameInBrazier.GetComponent<BrazierBehaviour>().lightHolder;
                doorToOpen = redFlameInBrazier.GetComponent<BrazierBehaviour>().door;
                //for reset, next line should be put back to false
                redFlameInBrazier.GetComponent<BrazierBehaviour>().alreadyPickedUp = true;
                //for reset,RedFlame state should be "normal"
                smallRedFlame.GetComponent<RedFlame>().changeState("pickedUp");
                //for reset, canPickUpRedFlame = true;
                canPickUpRedFlame = false;
                //for reset, instead of destroying maybe we can enable and then disable
                fireOctagonal.SetActive(false);
                //Destroy(fireOctagonal);
            }
        }
        if (canDropOffRedFlame)
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                print("I pressed Q");
                // if it is for drop off
                // we need to instantiate a new fire_octagonal with some random name
                smallRedFlame.GetComponent<RedFlame>().changeState("dropOff");
                GameObject fireOctagonal = Instantiate(Resources.Load("fire_octagonal")) as GameObject;
                fireOctagonal.name = collidedRedFlameName + "_drop_" + "fire_octagonal";
                fireOctagonal.transform.position = dropOffLightHolder.transform.position;
                fireOctagonal.transform.parent = dropOffLightHolder.transform;
                GameObject emptyFlameInBrazier = GameObject.Find(collidedEmptyFlameName);
                emptyFlameInBrazier.GetComponent<BrazierBehaviour>().alreadyDroppedOff = true;
                canDropOffRedFlame = false;
                canIOpenTheDoor = true;
                dropOffLightHolder = null;
            }

        }
        if (canIOpenTheDoor)
        {
            if(doorToOpen != null)
            {
                doorToOpen.GetComponent<PassageDoor>().openTheDoor = true;
                canIOpenTheDoor = false;
                doorToOpen = null;
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
            collidedRedFlameName = col.gameObject.name;
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
            collidedEmptyFlameName = col.gameObject.name;
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
