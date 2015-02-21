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

        /* SaveLoad */
        if (collider2D.gameObject.tag == "Load")
        {
            _SaveLoad.Load();
            Application.LoadLevel(_Game.current.currScene);
            //_Game.current = _SaveLoad.savedGames.;
            //Application.LoadLevel();

            /*foreach (_Game g in _SaveLoad.savedGames)
            {
                _Game.current = g;
                //Move on to game...
                Application.LoadLevel(_Game.current.currScene);
            }*/
        }

        if (collider2D.gameObject.tag == "NewGame")
        {
            _Game.current = new _Game();
            Application.LoadLevel(0);
        }
        
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
            if (collider2D.gameObject.tag == "Secret")
            {
                Debug.Log("Secret level tıklandı.");
                Application.LoadLevel(6);
            }
            if (collider2D.gameObject.tag == "Back")
                Application.LoadLevel(0);
        }
    }

    void OnMouseOver()
    {
        if (collider2D.gameObject.tag == "Secret")
        {
            //Do nothing
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(initialColor, Color.cyan, 0.5f);
        }
    }

    void OnMouseExit()
    {
        if (collider2D.gameObject.tag == "Secret")
        {
            //Do nothing
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = initialColor;
        }
    }
}