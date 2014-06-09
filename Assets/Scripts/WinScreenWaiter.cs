using UnityEngine;
using System.Collections;

public class WinScreenWaiter : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(WaitAndLoadLevel(3.0f));
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    IEnumerator WaitAndLoadLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //print("WaitAndPrint " + Time.time);
        Application.LoadLevel(0);
    }
}
