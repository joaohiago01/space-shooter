using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SavePlayer(PlayerInfo playerInfo, ShipsPlayerData shipsPlayerData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Game.data";

        FileStream stream;

        if (File.Exists(path))
        {
            Debug.Log("Saving...");
            File.Delete(path);
        }

        stream = File.Create(path);

        PlayerData playerData = new PlayerData(playerInfo);

        GameData data = new GameData(playerData, shipsPlayerData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Game.data";

        if (File.Exists(path))
        {
            Debug.Log("Loading...");
            Debug.Log(path);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.Open(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
