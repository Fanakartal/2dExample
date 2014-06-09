using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	Color initialColor;
    
    // Use this for initialization
    void Start () 
    {
        initialColor = renderer.material.color;
	}
	
    void OnMouseDown()
    {

        if (collider2D.gameObject.tag == "Turkey")
            Application.LoadLevel(Application.loadedLevel + 1);
        else if (collider2D.gameObject.tag == "Exit")
            Application.Quit();
        else if (Application.loadedLevel == 1)
        {

            if (collider2D.gameObject.tag == "Ankara")
                Application.LoadLevel(2);
            if (collider2D.gameObject.tag == "Izmir")
                Application.LoadLevel(3);
            if (collider2D.gameObject.tag == "Istanbul")
                Application.LoadLevel(4);
            if (collider2D.gameObject.tag == "Back")
                Application.LoadLevel(0);
        }
    }

    void OnMouseOver()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(initialColor, Color.cyan, 0.5f);
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = initialColor;
    }
}