using UnityEngine;
using System.Collections;

public class Minotaur_roar_once : MonoBehaviour
{
    public AudioSource source;
    public AudioClip roarClip;
    public bool shouldIPlayRoarOnce;

    // Use this for initialization
    void Start ()
    {
        shouldIPlayRoarOnce = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(shouldIPlayRoarOnce)
        {
            source.clip = roarClip;
            source.Play();
            shouldIPlayRoarOnce = false;
        }
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            shouldIPlayRoarOnce = true;
        }
    }
    //public void OnTriggerEnter( Collide
    //{

    //}
}
