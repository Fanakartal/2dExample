using UnityEngine;
using System.Collections;

public class MagneticBarController : MonoBehaviour 
{
    public Texture2D image;

    float timePassedMag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        //GetComponent<CharController>()
	
	}

    void OnGUI()
    {
        GUI.Box(new Rect(1520, 0, 50, 50), image);
        GUI.Box(new Rect(1480, 0, 50, 50), image);
        GUI.Box(new Rect(1440, 0, 50, 50), image);
    }
}
