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
        if(canDropOffRedFlame && Input.GetKeyUp(KeyCode.Z))
        {
            redFlame.GetComponent<RedFlame>().changeState("dropOff");
        }

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
