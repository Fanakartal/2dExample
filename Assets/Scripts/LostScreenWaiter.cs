using UnityEngine;
using System.Collections;

public class LostScreenWaiter : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
    {
        StartCoroutine(WaitAndLoadLevel(3.0f));
	}

    IEnumerator WaitAndLoadLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Application.LoadLevel(0);
    }
}
