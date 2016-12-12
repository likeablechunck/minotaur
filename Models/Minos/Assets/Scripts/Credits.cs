using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clickClip;

	public void onClick()
    {
        source.clip = clickClip;
        source.Play();
        StartCoroutine(loadScene());
        //SceneManager.LoadScene("Credits");
    }
    private IEnumerator loadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Credits");
    }
}
