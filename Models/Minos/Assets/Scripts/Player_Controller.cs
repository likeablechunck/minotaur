using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class Player_Controller : MonoBehaviour
{
    //public AudioSource source;
    //public AudioClip minotarRoarClip;
    public GameObject normalSword;
    public GameObject brokenSword;
    public GameObject trimerTrigger;
    public GameObject camera;
    public GameObject normalCane;
    public GameObject flatCane;
    public Light minotaurLight;
    public Image pressE;
    public Image pressQ;
    public Image pressEToPickUpSwordCane;
    public Camera cam;
    public Camera cam2;
    public float musicTimer;
    public float minBloomIntensity;
    public float maxBloomIntensity;
    public float timerForBloom;
    public float slopeForIncreaseBloom;
    public float slopeForDecreaseBloom;
    public bool shouldIChangeBloomIntensity;
    public float minAlpha;
    public float maxAlpha;
    public float alphaTimer;
    public float shorterMusicTimer;
    public bool shouldIChangeTheAlpha;
    public bool turnOnTheSwordLight;
    public bool turnOnTheCaneLight;
    public bool shouldICloseTheFirstDoor;
    public bool shouldIOpenTheFirstHiddenDoor;
    public bool shouldIStopTheTimer;
    public bool shouldITurnOnTheBrokenSword;
    public bool shouldIDisplayEText;
    public bool shouldIDisplayQText;
    public bool shouldIOpenTheAtriumDoor;
    public bool shouldIStartTheTimer;
    public bool ShouldICloseTheDoorToTheSafeRoom;
    public bool shouldIOpenTheDoorToSafePassage;
    public bool shouldIOpenTheMinotaurDoor;
    public bool shouldICloseTheHiddenWall;
    public bool shouldIOpenTheLastDoor;
    public bool shouldIBlockTheHallway;
    public bool shouldIHideTheTimerTrigger;
    public bool isItCane;
    public bool isItSword;
    public bool shouldIFadeInTheCamera;
    public bool shouldIFadeOutTheCamera;
    public float timer;
    public bool cutSceneStart;
    public bool neverDisplayTheEText;
    public bool shouldIPlayTheMusic;
    public float cutSceneTimer;
    // Use this for initialization
    void Start ()
    {
        //minotaurLight.enabled = false;
        GameObject fpc = GameObject.Find("FirstPersonCharacter");
        GameObject minotaurCamera = GameObject.Find("Minotaur_Door_Camera");
        //Alpha Variables
        minAlpha = 0;
        maxAlpha = 1;
        alphaTimer = 0;
        shorterMusicTimer = 8.63f;
        shouldIChangeTheAlpha = false;
        //Bloom variables
        musicTimer = 10.63f;
        minBloomIntensity = 0.71f;
        maxBloomIntensity = 2.76f;
        timerForBloom = 0;
        fpc.GetComponent<Bloom>().enabled = false;
        minotaurCamera.GetComponent<Bloom>().enabled = false;
        shouldIChangeBloomIntensity = false;
        cam.enabled = true;
        cam2.enabled = false;
        isItCane = false;
        fpc.GetComponent<Bloom>().bloomIntensity = minBloomIntensity;
        minotaurCamera.GetComponent<Bloom>().bloomIntensity = minBloomIntensity;
        pressEToPickUpSwordCane.enabled = false;
        flatCane.SetActive(false);
        normalCane.SetActive(true);
        brokenSword.SetActive(false);
        isItSword = false;
        normalSword.SetActive(true);
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
        shouldIOpenTheAtriumDoor = false;
        shouldIStartTheTimer = false;
        ShouldICloseTheDoorToTheSafeRoom = false;
        shouldIOpenTheDoorToSafePassage = false;
        shouldIOpenTheMinotaurDoor = false;
        shouldICloseTheHiddenWall = false;
        shouldIOpenTheLastDoor = false;
        shouldIBlockTheHallway = false;
        shouldIHideTheTimerTrigger = false;
        shouldIFadeInTheCamera = false;
        shouldIFadeOutTheCamera = false;
        neverDisplayTheEText = false;
        shouldIPlayTheMusic = false;
        timer = 0;
        cutSceneTimer = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {
        GameObject fpc = GameObject.Find("FirstPersonCharacter");
        GameObject minotaurCamera = GameObject.Find("Minotaur_Door_Camera");
        if (shouldIPlayTheMusic)
        {
            print("I am about to change the play the OLD LADY music");
            fpc.GetComponent<GameMusic>().changeState("safeRoom");

        }
        if ( isItCane && Input.GetKeyDown(KeyCode.E))
        {
            isItCane = false;
            cutSceneTimer = 0;
            cutSceneStart = true;
            flatCane.SetActive(true);
            //normalCane.SetActive(false);
            Destroy(normalCane, 0.2f);
            turnOnTheCaneLight = true;
            shouldIOpenTheDoorToSafePassage = true;
            shouldIOpenTheMinotaurDoor = true;
            //cutSceneStart = true;
            neverDisplayTheEText = true;
            
        }
        if (isItSword && Input.GetKeyDown(KeyCode.E))
        {
            shouldIChangeBloomIntensity = true;
            GameObject fade = GameObject.Find("Fade");
            print("sword detected and I pressed E");
            isItSword = false;
            GameObject swrodTrigger = GameObject.Find("Sword-Music-Trigger");
            Destroy(swrodTrigger, 0.2f);
            cutSceneTimer = 0;
            pressEToPickUpSwordCane.enabled = false;
            cutSceneStart = true;
            turnOnTheSwordLight = true;
            normalSword.SetActive(false);
            //Destroy(normalSword, 0.2f);
            brokenSword.SetActive(true);
            //neverDisplayTheEText = true;
        }
        if (shouldIChangeBloomIntensity)
        {
            //fpc.GetComponent<Bloom>().bloomIntensity = minBloomIntensity;
            print("Bloom intensity is at : " + fpc.GetComponent<Bloom>().bloomIntensity);
            if (timerForBloom <= musicTimer)
            {
                timerForBloom += Time.deltaTime;
                if (timerForBloom >= 0 && timerForBloom < (musicTimer / 2))
                {
                    bloomIncreaseIntensity();
                }

                else if (timerForBloom >= (musicTimer / 2) && timerForBloom <= musicTimer)
                {
                    bloomDecrease();
                    if (fpc.GetComponent<Bloom>().bloomIntensity <= minBloomIntensity)
                    {
                        shouldIChangeBloomIntensity = false;
                    }
                }
            }
            else
            {
                fpc.GetComponent<Bloom>().enabled = false;
                minotaurCamera.GetComponent<Bloom>().enabled = false;
            }
        }       
       
        if(neverDisplayTheEText)
        {
            pressEToPickUpSwordCane.enabled = false;
        }
        if(cutSceneStart)
        {
            cutSceneTimer += Time.deltaTime;
            if(cutSceneTimer <= 8.63f)
            {
                cam2.enabled = true;
                cam.enabled = false;
            }
            else
            {
                cutSceneStart = false;
                cam.enabled = true;
                cam2.enabled = false;
                //cutSceneTimer = 0;
            }        
        }
        if (shouldIFadeInTheCamera)
        {
            if (camera.GetComponent<VignetteAndChromaticAberration>().intensity <= 1)
            {
                camera.GetComponent<VignetteAndChromaticAberration>().intensity += Time.deltaTime;
            } else
            {
                shouldIFadeOutTheCamera = true;
                shouldIFadeInTheCamera = false;
            }

        }
        if(shouldIFadeOutTheCamera)
        {
            if (camera.GetComponent<VignetteAndChromaticAberration>().intensity >= 0.036f)
            {
                camera.GetComponent<VignetteAndChromaticAberration>().intensity -= Time.deltaTime;
            } else
            {
               // minotaurLight.enabled = true;
                shouldIFadeInTheCamera = false;
                shouldIFadeOutTheCamera = false;
            }
        }
        if(shouldIHideTheTimerTrigger)
        {
            trimerTrigger.SetActive(false);
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
    //functions for increasing and decreasing the bloom intensity when player touches the Sword
    public void bloomIncreaseIntensity()
    {
        GameObject fpc = GameObject.Find("FirstPersonCharacter");
        GameObject minotaurCamera = GameObject.Find("Minotaur_Door_Camera");
        fpc.GetComponent<Bloom>().enabled = true;
        minotaurCamera.GetComponent<Bloom>().enabled = true;
        slopeForIncreaseBloom = (maxBloomIntensity - minBloomIntensity) / ((musicTimer/2)- 0);
        fpc.GetComponent<Bloom>().bloomIntensity = (slopeForIncreaseBloom * timerForBloom) - (slopeForIncreaseBloom * 0) + minBloomIntensity;
        minotaurCamera.GetComponent<Bloom>().bloomIntensity = (slopeForIncreaseBloom * timerForBloom) - (slopeForIncreaseBloom * 0) + minBloomIntensity;
    }
    private IEnumerator bloomDecreaseIntensity()
    {
        GameObject fpc = GameObject.Find("FirstPersonCharacter");
        fpc.GetComponent<Bloom>().bloomIntensity = maxBloomIntensity;
        print("I am calling the coroutine");
        print("Timer during decreasing is : " + timerForBloom);
        float waitTime = 2f;
        yield return new WaitForSeconds(waitTime);
        slopeForDecreaseBloom = (minBloomIntensity - maxBloomIntensity) / ( musicTimer - ((musicTimer / 2) + waitTime));
        //fpc.GetComponent<Bloom>().bloomIntensity = slopeForDecreaseBloom * (timerForBloom - ((musicTimer / 2) + waitTime)) + maxBloomIntensity;
        fpc.GetComponent<Bloom>().bloomIntensity = slopeForDecreaseBloom * (timerForBloom) - slopeForDecreaseBloom *((musicTimer / 2) + waitTime) +maxBloomIntensity;
        //fpc.GetComponent<Bloom>().bloomIntensity = (slopeForDecreaseBloom * timerForBloom) - (slopeForDecreaseBloom *maxBloomIntensity) + ((musicTimer / 2) +waitTime);
        print("I calculated the decrease bloom formula");
        if(fpc.GetComponent<Bloom>().bloomIntensity <= minBloomIntensity)
        {
            fpc.GetComponent<Bloom>().enabled = false;
        }      
    }
    public void bloomDecrease()
    {
        GameObject fpc = GameObject.Find("FirstPersonCharacter");
        GameObject minotaurCamera = GameObject.Find("Minotaur_Door_Camera");
        //fpc.GetComponent<Bloom>().bloomIntensity = maxBloomIntensity;
        float waitTime = 0f;
        new WaitForSeconds(waitTime);
        slopeForDecreaseBloom = (minBloomIntensity - maxBloomIntensity) / (musicTimer - ((musicTimer / 2) + waitTime));
        //fpc.GetComponent<Bloom>().bloomIntensity = slopeForDecreaseBloom * (timerForBloom - ((musicTimer / 2) + waitTime)) + maxBloomIntensity;
        fpc.GetComponent<Bloom>().bloomIntensity = slopeForDecreaseBloom * (timerForBloom) - slopeForDecreaseBloom * ((musicTimer / 2) + waitTime) + maxBloomIntensity;
        minotaurCamera.GetComponent<Bloom>().bloomIntensity = slopeForDecreaseBloom * (timerForBloom) - slopeForDecreaseBloom * ((musicTimer / 2) + waitTime) + maxBloomIntensity;
        //fpc.GetComponent<Bloom>().bloomIntensity = (slopeForDecreaseBloom * timerForBloom) - (slopeForDecreaseBloom *maxBloomIntensity) + ((musicTimer / 2) +waitTime);
        print("I calculated the decrease bloom formula");
    }
    void OnTriggerEnter(Collider col)
    {
        print("Name of the item I collide : " + col.gameObject);

        Vector3 torchPosition = col.transform.position;
        Vector3 playerPosition = this.transform.position;
        //When player gets to the end of the Old Lady's room, timer should stop
        /*if(col.gameObject.tag == "Minotaur")
        {
           // shouldIFadeInTheCamera = true;
        }*/
        if(col.gameObject.tag == "Timer_End")
        {
            shouldIStopTheTimer = true;
        }
        if(col.gameObject.tag == "Red_Flame_Brazier")
        {
            if (!col.gameObject.GetComponent<BrazierBehaviour>().alreadyPickedUp)
            {
                shouldIDisplayEText = true;
            }
        }
        //if (col.gameObject.tag == "Empty_Red_Brazier")
        //{
        //    if (!col.gameObject.GetComponent<BrazierBehaviour>().alreadyDroppedOff)
        //    {
        //        shouldIDisplayQText = true;
        //    }
        //}
        if(col.gameObject.tag == "Open_Atrium_Door")
        {
            shouldIOpenTheAtriumDoor = true;
        }
        if(col.gameObject.tag == "Enterance_To_Saferoom")
        {
            ShouldICloseTheDoorToTheSafeRoom = true;
            //shouldIPlayTheMusic = true;
        }
        if(col.gameObject.tag == "Last_Doors_Trigger")
        {
            //open the last door in safe passage
            //block the old lady hallway so player doesn't go back to the old lady room
            //timer should not start
            //door to atrium should open
            shouldIOpenTheLastDoor = true;
            shouldIBlockTheHallway = true;
            shouldICloseTheFirstDoor = false;
            shouldIStartTheTimer = false;
            shouldIHideTheTimerTrigger = true;
        }

        if (col.gameObject.tag == "Torch")
        {
            Light light = Instantiate(Resources.Load("point_light", typeof(Light)),
               torchPosition, Quaternion.identity) as Light;
        }
        //if(col.gameObject.tag == "Sword_Music")
        //{
        //    Destroy(col.gameObject, 0.2f);
        //}
        if(col.gameObject.tag == "Sword")
        {
            //it needs to destroy the normal sword
            //Then turn on the broken sword
            //turnOnTheSwordLight = true;
            //shouldITurnOnTheBrokenSword = true;
            //Destroy(col.gameObject, 0.2f);
            //shouldITurnOnTheBrokenSword = true;
            pressEToPickUpSwordCane.enabled = true;
            isItSword = true;
        }
        if(col.gameObject.tag == "Cane")
        {
            print("I collided into Cane");
            shouldIOpenTheFirstHiddenDoor = true;
            pressEToPickUpSwordCane.enabled = true;
            isItCane = true;
          
        }
        if(col.gameObject.tag == "Hidden_Wall")
        {
            shouldICloseTheHiddenWall = true;
        }
        if(col.gameObject.tag == "Room1-Door")
        {
            //close the door behind the player
            //then timer should start
            shouldICloseTheFirstDoor = true;
            shouldIStartTheTimer = true;
        }
        if(col.gameObject.tag == "Room1-LoadLevel")
        {
            //SceneManager.LoadScene("old_lady");
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
        if (col.gameObject.tag == "Cane")
        {
            shouldIOpenTheFirstHiddenDoor = false;
            pressEToPickUpSwordCane.enabled = false;
            isItCane = false;
        }
        if (col.gameObject.tag == "Sword")
        {
            pressEToPickUpSwordCane.enabled = false;
            isItSword = false;
        }
    }
}
