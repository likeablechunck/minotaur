using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public float sceneSwitchDelay = 2.0f;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (sceneSwitchDelay);

		SceneManager.LoadScene (1);
	}
}
