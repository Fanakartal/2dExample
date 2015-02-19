using UnityEngine;
using System.Collections;

[System.Serializable]
public class _Game
{ //don't need ": Monobehaviour" because we are not attaching it to a game object

    public static _Game current;
    public _Character postman;

    public _Game()
    {
        postman = new _Character();
    }

}
