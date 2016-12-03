using UnityEngine;
using System.Collections;

public class sword_cutscene : MonoBehaviour {
    public Camera cam;
    public Camera cam2;
    public bool cutscene;
    public bool cutscenedone;
    float timer;
    // Use this for initialization
    void Start () {

    
	}
	
	// Update is called once per frame
	void Update () {
        print("cutscene: "+ cutscene);
        print("cutscenedone: " + cutscenedone);


        if (cutscene == true) {
            timer += Time.deltaTime;
            print("timer" + timer);
            print("cutscene");

            if (timer < 5.0f)
            {
                // print("cutscene");

                cam2.enabled=true;
               cam.enabled=false;
                //cutscenedone = false;
                //cam.gameObject.active = false;
                //cam2.gameObject.active = true;
            }

            if (timer > 5.0f)
            {
                print("time is up");
                cutscene = false;
               cam.enabled= true;
                //cam.gameObject.active = true;
                // cam2.gameObject.active = false;
                 cam2.enabled = false;
               // cam.enabled = true;
                // cutscenedone = true;

            }

        }

        
    }
    void OnTriggerEnter(Collider col)
    {
        print("I collided into sword XD");
       
        if ((col.gameObject.tag == "Player") || (cutscenedone = false))
        {
            cutscene = true;
            
            
      
        }
    }
}
