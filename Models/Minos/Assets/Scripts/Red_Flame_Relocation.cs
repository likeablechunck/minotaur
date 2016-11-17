using UnityEngine;
using System.Collections;

public class Red_Flame_Relocation : MonoBehaviour
{
    public bool canPickUpRedFlame;
    public bool canDropOffRedFlame;
    public bool alreadyHasRedFlame;
    public bool lightInstantiated;
    public GameObject redFlame;
    public GameObject rHandSocket;

    // Use this for initialization
    void Start ()
    {
        //In Inspector, assign the red flame associated with this brazier
        rHandSocket = GameObject.Find("RHandSocket");

        canDropOffRedFlame = false;
        canPickUpRedFlame = false;
        alreadyHasRedFlame = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (canPickUpRedFlame && Input.GetKeyUp(KeyCode.Q))
        {
            redFlame.GetComponent<RedFlame>().changeState("pickedUp");
        }
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

        }
        if (col.gameObject.tag == "Empty_Red_Brazier")
        {
            canDropOffRedFlame = true;
            if(Input.GetKeyUp(KeyCode.Z))
            {

                redFlame.GetComponent<RedFlame>().changeState("dropOff");
                GameObject redFlameInBrazier = Instantiate(Resources.Load("fire_octagonal")) as GameObject;
                GameObject currentLightHolder = col.transform.FindChild("Light_Holder").gameObject;
                redFlameInBrazier.transform.position = currentLightHolder.transform.position;
                redFlameInBrazier.transform.rotation = currentLightHolder.transform.rotation;
                redFlameInBrazier.transform.parent = currentLightHolder.transform;

            }

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
