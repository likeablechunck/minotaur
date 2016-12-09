using UnityEngine;
using System.Collections;

public class logo : MonoBehaviour {

	public float startScale;
	public float[] scales;
	public float[] scaleSpeed;
	int scaleIndex;
	Vector3 scaleXfer;
	int startAnimFlag = 0;
	int waitFlag = 0;

	// Use this for initialization
	void Start () {

		GetComponent<MeshRenderer> ().enabled = false;
		StartCoroutine (startBlinkIn ());
	}
	
	// Update is called once per frame
	void Update () {

		//transform.localScale = scaleXfer;

		if ((scaleIndex < scales.Length) && (startAnimFlag == 1))
		{
			if (waitFlag == 0)
			{
				waitFlag = 1;
				StartCoroutine(logoScale(scales[scaleIndex], scaleSpeed[scaleIndex]));
			}
		



		}
	
	}

	IEnumerator startBlinkIn()
	{
		yield return new WaitForSeconds (.66f);
		scaleXfer = new Vector3 (startScale, startScale, startScale);
		GetComponent<MeshRenderer> ().enabled = true;
		transform.localScale = scaleXfer;

		startAnimFlag = 1;
	}

	IEnumerator logoScale(float targetScale, float speed)
	{

		float scaleFactor = 0f;
		Vector3 currentScale = transform.localScale;
		scaleXfer = new Vector3(targetScale, targetScale, targetScale);

		while (transform.localScale != scaleXfer) 
		{
			scaleFactor += Time.deltaTime * speed;
			transform.localScale = Vector3.Lerp (currentScale, scaleXfer, scaleFactor);
			yield return new WaitForEndOfFrame();

		}

		scaleIndex++;
		waitFlag = 0;



	}
}
