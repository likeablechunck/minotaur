using UnityEngine;
using System.Collections;

public class fadeIn : MonoBehaviour {

	public float fadeInDelay;
	float fadeInTime = 4f;
	float alphaValue = 0f;
	float fadeInFactor = 0f;
	Color alphaColor;
	int breakVal;

	// Use this for initialization
	void Start () {
		alphaColor = new Vector4 (1f, 1f, 1f, 0f);
		GetComponent<MeshRenderer>().material.color = alphaColor;
		StartCoroutine (fadeInFunc ());
		StartCoroutine (breakValFunc ());
	}
	
	// Update is called once per frame
	void Update () {

		alphaColor.a = alphaValue;
		GetComponent<MeshRenderer>().material.color = alphaColor;
	
	}

	IEnumerator fadeInFunc ()
	{
		yield return new WaitForSeconds (fadeInDelay);

		while (alphaValue < 1) 
		{
			fadeInFactor += Time.deltaTime * fadeInTime;
			alphaValue = Mathf.Lerp (0f, 1f, fadeInFactor);
			yield return new WaitForEndOfFrame();
		}

	}

	IEnumerator breakValFunc()
	{

		yield return new WaitForSeconds (1f);
		breakVal = 1;


	}
}
