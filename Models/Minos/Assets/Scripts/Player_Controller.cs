using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnTriggerEnter(Collider col)
    {
        Vector3 playerPosition = this.transform.position;
        if(col.gameObject.tag == "Torch")
        {
            print("Name of the item I collide : " + col.gameObject);
            //Pickup (destroiy the torch and then instantiate the light
            Destroy(col.gameObject);
            //Instantiate the light where the player is 
            Light light = Instantiate(Resources.Load("point_light", typeof(Light)),
                playerPosition, Quaternion.identity) as Light;
        }
    }
}
