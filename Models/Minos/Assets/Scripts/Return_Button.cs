using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Return_Button : MonoBehaviour
{

	// Update is called once per frame
	public void onClick()
    {

        SceneManager.LoadScene("Start");
    }
}
