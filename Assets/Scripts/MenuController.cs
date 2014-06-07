using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	Color initialColor;
    //SpriteRenderer spriteRenderer;
    
    // Use this for initialization
    void Start () 
    {
        initialColor = renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        
        if(Application.loadedLevel == 0)
            Application.LoadLevel(Application.loadedLevel + 1);
        else if (Application.loadedLevel == 1)
        {
            
            if(collider2D.gameObject.tag == "Ankara")
                Application.LoadLevel(2);
            if(collider2D.gameObject.tag == "Izmir")
                Application.LoadLevel(3);
            if (collider2D.gameObject.tag == "Istanbul")
                Application.LoadLevel(4);
            if (collider2D.gameObject.tag == "Back")
                Application.LoadLevel(0);

            /*if (GUI.Button(Rect(10, 10, 150, 100), "Load Scene"))
            {
                Application.LoadLevel(currentLevel - (Application.levelCount - 1));
            }*/
        }
    }

    void OnMouseOver()
    {
        //Debug.Log("Color changed");
        gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(initialColor, Color.cyan, 0.5f); //Color.red;
        //spriteRenderer.color = Color.red;
        //renderer.material.color = Color.white;//Color.Lerp(initialColor, Color.white, Time.time);
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = initialColor;
        //spriteRenderer.color = initialColor;
    }
}