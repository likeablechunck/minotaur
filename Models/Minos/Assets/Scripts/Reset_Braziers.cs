using UnityEngine;
using System.Collections;

public class Reset_Braziers : MonoBehaviour
{
    public GameObject redFlameBrazier1;
    public GameObject redFlameBrazier2;
    public GameObject redFlameBrazier3;
    //public GameObject redFlameBrazier4;
    public GameObject emptyBrazier1;
    public GameObject emptyBrazier2;
    public GameObject emptyBrazier3;
   // public GameObject emptyBrazier4;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    //public GameObject door4;
    public GameObject redFlame1;
    public GameObject redFlame2;
    public GameObject redFlame3;
    //public GameObject redFlame4;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        // I need to access red flame relocation script to make changes
        // Script is under FPSController
        GameObject fpc = GameObject.Find("FPSController");
        //I need to access Old-Lady_Controller script to check the time
        //It is attached to FirstPersonCharacter
        GameObject player = GameObject.Find("FirstPersonCharacter");

        if(player.GetComponent<Old_Lady_Controller>().gameTimer <=0)
        {
            Reset();
        }
	
	}

    public void Reset()
    {
        print("Reset function called");

        GameObject fpc = GameObject.Find("FPSController");

        //RedFlmeBrazier :

        //Flame should be ON
        redFlame1.SetActive(true);
        redFlame2.SetActive(true);
        redFlame3.SetActive(true);
        //redFlame4.SetActive(true);
        fpc.GetComponent<Red_Flame_Relocation>().canPickUpRedFlame = false;
        fpc.GetComponent<Red_Flame_Relocation>().alreadyHasRedFlame = false;
        

        //SmallFlame state must change to Normal
        GameObject smallFlame = GameObject.Find("fire_octagonal_hand");
        smallFlame.GetComponent<RedFlame>().changeState("normal");
        //pickedUp = false
        redFlameBrazier1.GetComponent<BrazierBehaviour>().alreadyPickedUp = false;
        redFlameBrazier2.GetComponent<BrazierBehaviour>().alreadyPickedUp = false;
        redFlameBrazier3.GetComponent<BrazierBehaviour>().alreadyPickedUp = false;
        //redFlameBrazier4.GetComponent<BrazierBehaviour>().alreadyPickedUp = false;

        //Empty Brazier:

        //dropOff = false;
        fpc.GetComponent<Red_Flame_Relocation>().canDropOffRedFlame = false;
        emptyBrazier1.GetComponent<BrazierBehaviour>().alreadyDroppedOff = false;
        emptyBrazier2.GetComponent<BrazierBehaviour>().alreadyDroppedOff = false;
        emptyBrazier3.GetComponent<BrazierBehaviour>().alreadyDroppedOff = false;
        //emptyBrazier4.GetComponent<BrazierBehaviour>().alreadyDroppedOff = false;

        //Door:
        //Must set to initial position
        fpc.GetComponent<Red_Flame_Relocation>().canIOpenTheDoor = false;
        door1.transform.position = door1.GetComponent<PassageDoor>().initialLocation;
        door2.transform.position = door2.GetComponent<PassageDoor>().initialLocation;
        door3.transform.position = door3.GetComponent<PassageDoor>().initialLocation;
        //door4.transform.position = door4.GetComponent<PassageDoor>().initialLocation;

        GameObject r1DroppedFireOctagonal  = GameObject.Find(redFlameBrazier1.name + "_drop_" + "fire_octagonal");
        if(r1DroppedFireOctagonal != null)
        {
            print("destroyed r1");
            Destroy(r1DroppedFireOctagonal);
        }
        GameObject r2DroppedFireOctagonal = GameObject.Find(redFlameBrazier2.name + "_drop_" + "fire_octagonal");
        if (r2DroppedFireOctagonal != null)
        {
            print("destroyed r2");
            Destroy(r2DroppedFireOctagonal);
        }
        GameObject r3DroppedFireOctagonal = GameObject.Find(redFlameBrazier3.name + "_drop_" + "fire_octagonal");
        if (r3DroppedFireOctagonal != null)
        {
            print("destroyed r3");
            Destroy(r3DroppedFireOctagonal);
        }

    }
}
