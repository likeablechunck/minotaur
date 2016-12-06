using UnityEngine;
using System.Collections;

public class Right_Minotaur_Door : MonoBehaviour {
  
    public float doorLimit;
    public float speed;
    float timer;

    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("FPSController");
        if (this.transform.position.x > doorLimit &&
            player.GetComponent<Player_Controller>().shouldIOpenTheMinotaurDoor)
        {
            timer += Time.deltaTime;
            if (timer > 1.0f)
            {
                this.transform.Translate(-speed, 0, 0);
            }
        }
    }
}
