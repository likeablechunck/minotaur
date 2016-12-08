using UnityEngine;
using System.Collections;

public class Reset_Braziers : MonoBehaviour
{


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.Find("FirstPersonCharacter");
        if(player.GetComponent<Old_Lady_Controller>().gameTimer <=0)
        {
            Reset();
        }
	
	}

    public void Reset()
    {

    }
}
