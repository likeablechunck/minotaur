using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class Minotaur_disappears : MonoBehaviour {
    public GameObject minotaur;
    float timer;
    public bool approach=false;
    public GameObject spotlight;
    public GameObject shadow;
    public GameObject cam;
    public bool vignette=false;
   
   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if ((approach == true) && (vignette==false)) // if player collided and vignetting hasn't started
        {
                            
            cam.GetComponent<VignetteAndChromaticAberration>().intensity += Time.deltaTime;   //increase vignetting effect         
            if (cam.GetComponent<VignetteAndChromaticAberration>().intensity >= 1) { // if screen is black

                
                vignette = true; //   
            }
        }
        if (vignette==true){
            cam.GetComponent<VignetteAndChromaticAberration>().intensity -= Time.deltaTime;
            minotaur.gameObject.SetActive(false); //disable minotaur
            spotlight.gameObject.SetActive(false); // disable spotlight
            shadow.gameObject.SetActive(true); // enable shadow
            StartCoroutine(loadScene());
        }
       

    }
    private IEnumerator loadScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("The_End");

    }
    void OnTriggerEnter(Collider col)
    {
       // print("");

        if (col.gameObject.tag == "Player") 
        {
            approach = true;


        }
    }
}
