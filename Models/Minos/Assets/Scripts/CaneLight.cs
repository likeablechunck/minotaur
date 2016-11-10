using UnityEngine;
using System.Collections;

public class CaneLight : MonoBehaviour {
    public Light spotLight;

    // Use this for initialization
    void Start()
    {
        spotLight.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("FPSController");
        if (player.GetComponent<Player_Controller>().turnOnTheCaneLight)
        {
            spotLight.enabled = true;

        }

    }
}
