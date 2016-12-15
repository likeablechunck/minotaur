using UnityEngine;
using System.Collections;

public class lightOnDoor : MonoBehaviour
{
    public Light swordSpotLight1;
    public Light swordSpotLight2;
    public Light caneSpotLight1;
    public Light caneSpotLight2;
    float timer;
    bool swordlight;
    bool canelight;

    // Use this for initialization
    void Start ()
    {
        swordSpotLight1.enabled = false;
        swordSpotLight2.enabled = false;
        caneSpotLight1.enabled = false;
        caneSpotLight2.enabled = false;

}

    // Update is called once per frame
    void Update()
    {
        if ((swordlight || canelight) == true) { 
        timer = 0.0f;
    }
        GameObject player = GameObject.Find("FPSController");
        if (player.GetComponent<Player_Controller>().turnOnTheSwordLight)
        {
            timer += Time.deltaTime;
            if (timer > 1.0f)
            {
                //how much delay to turn on the light is same as the one in Player Controller for cutscene
                StartCoroutine(swordLight(8f));
                //swordSpotLight1.enabled = true;
                //swordSpotLight2.enabled = true;
                //swordlight = true;
            }
        }
        if(player.GetComponent<Player_Controller>().turnOnTheCaneLight)
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                caneSpotLight1.enabled = true;
                caneSpotLight2.enabled = true;
                canelight = true;
            }
        }
	
	}
    private IEnumerator swordLight(float lightTimer)
    {
        yield return new WaitForSeconds(lightTimer);
        swordSpotLight1.enabled = true;
        swordSpotLight2.enabled = true;
        swordlight = true;
    }
}
