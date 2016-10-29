using UnityEngine;
using System.Collections;

public class Fading_Light : MonoBehaviour
{
    public string state;
    public Light pointLight;
    public float fadingSpeed;
    public float maxIntensity;
    public Vector3 offset;
    //public Transform target;

	// Use this for initialization
	void Start ()
    {
        pointLight.intensity = 1;
        state = "lightUp";
    }
	
	// Update is called once per frame
	void Update ()
    {

        GameObject Player = GameObject.Find("FPSController");
        //light must mat of the player
        //transform.position = Player.transform.position;      
        

        //if (Player != null)
        //{
        //    this.transform.LookAt(Player.transform);
        //}

        if (state == "lightUp")
        {
            lightUp();
            
        }
        if(state == "Fading")
        {
            Fading();
        }
        //check to see where is the light transform position & player's position.
        print("Light position is at : " + this.transform.position + "Player's position is at : " + Player.transform.position);


    }
    public void changeState(string stateName)
    {
        state = stateName;
        
    }

    public void lightUp()
    {
        pointLight.intensity += fadingSpeed;
        if (pointLight.intensity >= maxIntensity)
        {
            changeState("Fading");
        }

    }
    public void Fading()
    {
        pointLight.intensity -= fadingSpeed;
        if(pointLight.intensity == 0)
        {
            Destroy(this.gameObject);

        }
    }
}
