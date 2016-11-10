using UnityEngine;
using System.Collections;

public class RedFlame : MonoBehaviour
{
    public GameObject rHandSocket;
    public GameObject lightHolder;
    public string state;

    // Use this for initialization
    void Start ()
    {
        state = "normal";
        rHandSocket = GameObject.Find("RHandSocket");
        lightHolder = GameObject.Find("Light_Holder");

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(state == "normal")
        {
            normal();
        }
        if(state == "dropOff")
        {
            Drop_Off();
        }
        if (state == "pickedUp")
        {
            pickedUp();
        }
        //GameObject brazier = GameObject.Find("Lighten_Brazier");
        //brazier.GetComponent<Light_Relocation>().lightInstantiated = false;
        //RedFlameLocation();

        //if(Input.GetKeyUp(KeyCode.E))
        //{
        //    brazier.GetComponent<Light_Relocation>().lightInstantiated = false;
        //    Destroy(this.gameObject);

        //}

    }
    public void changeState(string newState)
    {
        state = newState;
    }
    void RedFlameLocation()
    {
        this.transform.position = rHandSocket.transform.position;
        this.transform.rotation = rHandSocket.transform.rotation;
        this.transform.parent = rHandSocket.transform;
    }
    public void normal()
    {
        
    }
    public void pickedUp()
    {
        RedFlameLocation();
    }
    public void Drop_Off()
    {
        print("I am about to drop it off");
        //GameObject player = GameObject.Find("FPSController");

        //GameObject child_light = player.transform.FindChild("Fire (Complex)(Clone)").gameObject;
        this.transform.position = lightHolder.transform.position;
        this.transform.parent = lightHolder.transform;

    }
}
