using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public bool turnOnTheSwordLight;
    public bool turnOnTheCaneLight;
    public bool shouldICloseTheFirstDoor;
    public bool shouldIOpenTheFirstHiddenDoor;
    public bool shouldIStopTheTimer;
    public float timer;

    // Use this for initialization
    void Start ()
    {
        turnOnTheSwordLight = false;
        turnOnTheCaneLight = false;
        shouldICloseTheFirstDoor = false;
        shouldIOpenTheFirstHiddenDoor = false;
        shouldIStopTheTimer = false;
        timer = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {
        //if(!shouldIStopTheTimer)
        //{
        //    timer += Time.deltaTime;
        //}
        //else
        //{
        //    print("timer is :" + timer);
        //    timer = timer + 0;
        //}
        
	
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
        if(col.gameObject.tag == "Torch")
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
            turnOnTheSwordLight = true;
            Destroy(col.gameObject, 1);
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
}
