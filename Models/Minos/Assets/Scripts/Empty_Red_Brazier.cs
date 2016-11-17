using UnityEngine;
using System.Collections;

public class Empty_Red_Brazier : MonoBehaviour
{
    public GameObject lightHolder;
    public bool canDropOff;

    // Use this for initialization
    void Start()
    {
        //make sure to assign what is lightHolder
        lightHolder = GameObject.Find("Light_Holder");
        canDropOff = false;

    }

    // Update is called once per frame
    void Update()
    {
        //if I am close to red flame
        if (canDropOff && Input.GetKeyUp(KeyCode.Z))
        {
            //Get the RED FLAME named "fire_octagonal" and put it in light holder.
            GameObject redFlame = Instantiate(Resources.Load("fire_octagonal")) as GameObject;
            redFlame.transform.position = lightHolder.transform.position;
            redFlame.transform.rotation = lightHolder.transform.rotation;
            redFlame.transform.parent = lightHolder.transform;

            //GameObject.Find("fire_octagonal").GetComponent<RedFlame>().changeState("dropOff");
        }

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            canDropOff = true;

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canDropOff = false;

        }
    }
}
