using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class _SaveLoad
{

    public static List<_Game> savedGames = new List<_Game>();

    //it's static so we can call it from anywhere
    public static void Save()
    {
        _SaveLoad.savedGames.Add(_Game.current);

        BinaryFormatter bf = new BinaryFormatter();

        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        Debug.Log(Application.persistentDataPath);
        //you can call it anything you want

        bf.Serialize(file, _SaveLoad.savedGames);

        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);

            _SaveLoad.savedGames = (List<_Game>)bf.Deserialize(file);

            file.Close();
        }
    }
}
 