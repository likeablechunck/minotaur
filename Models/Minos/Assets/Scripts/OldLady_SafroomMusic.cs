using UnityEngine;
using System.Collections;

public class OldLady_SafroomMusic : MonoBehaviour
{
    public bool shouldIPlayTheMusic;
    public AudioSource source;
    public AudioClip safeRoomClip;
    public bool safeRoomPlayedOnce;


    // Use this for initialization
    void Start ()
    {
        safeRoomPlayedOnce = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        GameObject fpc = GameObject.Find("FirstPersonCharacter");
        if (shouldIPlayTheMusic)
        {
            print("I am about to change the play the OLD LADY music");
            source.clip = safeRoomClip;
            if(!safeRoomPlayedOnce)
            {
                source.Play();
                safeRoomPlayedOnce = true;
                shouldIPlayTheMusic = false;
            }
           

            //fpc.GetComponent<GameMusic>().changeState("safeRoom");
            //shouldIPlayTheMusic = false;

        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            shouldIPlayTheMusic = true;
        }
    }
}
