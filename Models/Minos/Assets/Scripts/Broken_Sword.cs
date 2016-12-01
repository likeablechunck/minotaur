using UnityEngine;
using System.Collections;

public class Broken_Sword : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        //this.gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.Find("FPSController");
        //if(player.GetComponent<Player_Controller>().shouldITurnOnTheBrokenSword)
        //{
        //    print("Player collided into sword and need to enable the broken one");
        //    //this.gameObject.GetComponent<Renderer>().enabled = true;
        //    //this.gameObject.SetActive(true);
        //}

    }
}
