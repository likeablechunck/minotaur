using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Minotaur_disappears : MonoBehaviour {
    public GameObject minotaur;
    public Image pressEText;
    public bool shouldIDisplayPickupText;
    float timer;
    public bool approach;
    public GameObject spotlight;
    public GameObject shadow;
    public GameObject cam;
    public bool vignette=false;
   
   

	// Use this for initialization
	void Start ()
    {
        shouldIDisplayPickupText = false;
        pressEText.enabled = false;
        approach = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(shouldIDisplayPickupText)
        {
            pressEText.enabled = true;
        }

        if ((approach == true) && Input.GetKeyDown(KeyCode.E))
                // if player collided and vignetting hasn't started and pressed E
        {
            cam.GetComponent<VignetteAndChromaticAberration>().intensity += Time.deltaTime;

            if (cam.GetComponent<VignetteAndChromaticAberration>().intensity >= 1)
            { // if screen is black
                cam.GetComponent<VignetteAndChromaticAberration>().intensity -= Time.deltaTime;
                minotaur.gameObject.SetActive(false); //disable minotaur
                spotlight.gameObject.SetActive(false); // disable spotlight
                shadow.gameObject.SetActive(true); // enable shadow
                StartCoroutine(loadScene());


                //vignette = true; //   
            }

            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    cam.GetComponent<VignetteAndChromaticAberration>().intensity += Time.deltaTime;
            //    if (cam.GetComponent<VignetteAndChromaticAberration>().intensity >= 1)
            //    { // if screen is black
            //        cam.GetComponent<VignetteAndChromaticAberration>().intensity -= Time.deltaTime;
            //        minotaur.gameObject.SetActive(false); //disable minotaur
            //        spotlight.gameObject.SetActive(false); // disable spotlight
            //        shadow.gameObject.SetActive(true); // enable shadow
            //        StartCoroutine(loadScene());


            //        //vignette = true; //   
            //    }
            //}
                            
              //increase vignetting effect         
            //if (cam.GetComponent<VignetteAndChromaticAberration>().intensity >= 1) { // if screen is black

                
            //    vignette = true; //   
            //}
        }
        //if (vignette==true){
        //    cam.GetComponent<VignetteAndChromaticAberration>().intensity -= Time.deltaTime;
        //    minotaur.gameObject.SetActive(false); //disable minotaur
        //    spotlight.gameObject.SetActive(false); // disable spotlight
        //    shadow.gameObject.SetActive(true); // enable shadow
        //    StartCoroutine(loadScene());
        //}
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
            shouldIDisplayPickupText = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            approach = false;
            shouldIDisplayPickupText = false;
        }
    }
}
