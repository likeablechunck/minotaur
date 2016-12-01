﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public GameObject brokenSword;
    //public TextMesh pressE;
    public Image pressE;
    public Image pressQ;
    public bool turnOnTheSwordLight;
    public bool turnOnTheCaneLight;
    public bool shouldICloseTheFirstDoor;
    public bool shouldIOpenTheFirstHiddenDoor;
    public bool shouldIStopTheTimer;
    public bool shouldITurnOnTheBrokenSword;
    public bool shouldIDisplayEText;
    public bool shouldIDisplayQText;
    public float timer;

    // Use this for initialization
    void Start ()
    {
        pressE.enabled = false;
        pressQ.enabled = false;
        turnOnTheSwordLight = false;
        turnOnTheCaneLight = false;
        shouldICloseTheFirstDoor = false;
        shouldIOpenTheFirstHiddenDoor = false;
        shouldIStopTheTimer = false;
        shouldITurnOnTheBrokenSword = false;
        shouldIDisplayEText = false;
        shouldIDisplayQText = false;
        timer = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(shouldITurnOnTheBrokenSword)
        {
           brokenSword.SetActive(true);
        } 
          
        if(shouldIDisplayEText)
        {
            print("I want to display the text");
            pressE.enabled = true;
        }  
        else
        {
            pressE.enabled = false;
        }
        if (shouldIDisplayQText)
        {
            print("I want to display the Q text");
            pressQ.enabled = true;
        }
        else
        {
            pressQ.enabled = false;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        print("Name of the item I collide : " + col.gameObject);

        Vector3 torchPosition = col.transform.position;
        Vector3 playerPosition = this.transform.position;
        //When player gets to the end of the Old Lady's room, timer should stop
        if(col.gameObject.tag == "Timer_End")
        {
            shouldIStopTheTimer = true;
        }
        if(col.gameObject.tag == "Red_Flame_Brazier")
        {
            shouldIDisplayEText = true;
        }
        if (col.gameObject.tag == "Empty_Red_Brazier")
        {
            shouldIDisplayQText = true;
        }

        if (col.gameObject.tag == "Torch")
        {
            
            //Pickup (destroiy the torch and then instantiate the light
            //Destroy(col.gameObject);

            //Instantiate the light where the player is 
            //Light light = Instantiate(Resources.Load("point_light", typeof(Light)),
            //    playerPosition, Quaternion.identity) as Light;

            //Instantiate the light in where the torch is
            Light light = Instantiate(Resources.Load("point_light", typeof(Light)),
               torchPosition, Quaternion.identity) as Light;
        }
        if(col.gameObject.tag == "Sword")
        {
            //it needs to destroy the normal sword
            //Then turn on the broken sword
            turnOnTheSwordLight = true;
            Destroy(col.gameObject, 0.1f);
            shouldITurnOnTheBrokenSword = true;
        }
        if(col.gameObject.tag == "Cane")
        {
            turnOnTheCaneLight = true;
        }
        if(col.gameObject.tag == "Room1-Door")
        {
            shouldICloseTheFirstDoor = true;
        }
        if(col.gameObject.tag == "Room1-LoadLevel")
        {
            SceneManager.LoadScene("old_lady");
        }
        if(col.gameObject.tag == "Cane")
        {
            shouldIOpenTheFirstHiddenDoor = true;

        }
        if(col.gameObject.tag == "Load-Atrium")
        {
            SceneManager.LoadScene("Main");
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Red_Flame_Brazier")
        {
            shouldIDisplayEText = false;
        }
        if (col.gameObject.tag == "Empty_Red_Brazier")
        {
            shouldIDisplayQText = false;
        }

    }
}
