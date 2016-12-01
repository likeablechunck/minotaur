using UnityEngine;
using System.Collections;

public class lightOnDoor : MonoBehaviour
{
    public Light swordSpotLight1;
    public Light swordSpotLight2;
    public Light caneSpotLight1;
    public Light caneSpotLight2;

    // Use this for initialization
    void Start ()
    {
        swordSpotLight1.enabled = false;
        swordSpotLight2.enabled = false;
        caneSpotLight1.enabled = false;
        caneSpotLight2.enabled = false;

}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.Find("FPSController");
        if (player.GetComponent<Player_Controller>().turnOnTheSwordLight)
        {
            swordSpotLight1.enabled = true;
            swordSpotLight2.enabled = true;

        }
        if(player.GetComponent<Player_Controller>().turnOnTheCaneLight)
        {
            caneSpotLight1.enabled = true;
            caneSpotLight2.enabled = true;
        }
	
	}
}
