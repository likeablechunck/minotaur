using UnityEngine;
using System.Collections;

public class Empty_Brazier : MonoBehaviour
{
    public bool canDropOff;

    // Use this for initialization
    void Start ()
    {
        canDropOff = false;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(canDropOff && Input.GetKeyUp(KeyCode.Z))
        {
            GameObject.Find("Fire (Complex)(Clone)").GetComponent<RedFlame>().changeState("dropOff");
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
