using UnityEngine;
using System.Collections;

public class Light_Relocation : MonoBehaviour {

    public bool canPickUp;
    public bool alreadyHasLight;

    // Use this for initialization
    void Start()
    {
        canPickUp = false;
        alreadyHasLight = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!alreadyHasLight)
        {
            if (canPickUp && Input.GetKeyUp(KeyCode.Space))
            {
                PickUp();
            }
        }

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            canPickUp = true;

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canPickUp = false;

        }
    }
    void PickUp()
    {

    }
}
