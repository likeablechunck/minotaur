using UnityEngine;
using System.Collections;

public class Fading_Light : MonoBehaviour
{
    public string state;
    public Light pointLight;
    public float fadingSpeed;
    public float maxIntensity;
    public Vector3 offset;

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
        //light must make what is infron't of the player, lighter
        transform.position = Player.transform.position;
        print("Light Intensity is : " + pointLight.intensity);
        print("State is : " + state);

        if(state == "lightUp")
        {
            lightUp();
            
        }
        if(state == "Fading")
        {
            Fading();
        }
        

    }
    public void changeState(string stateName)
    {
        state = stateName;
        print("current Light state is :" + stateName);
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
