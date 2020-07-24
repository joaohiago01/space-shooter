using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SavePlayer(PlayerInfo playerInfo, ShipInfo shipInfo)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/GameData.data";
        FileStream stream = File.Create(path);

        PlayerData playerData = new PlayerData(playerInfo);

        ShipData shipData = new ShipData(shipInfo);
        ShipsData shipsData = new ShipsData(shipData);

        GameData data = new GameData(playerData, shipsData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/GameData.data";
        if (File.Exists(path))
        {
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
    public static void SaveShip(ShipInfo shipInfo)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Ship.data";
        FileStream stream = File.Create(path);

        ShipData data = new ShipData(shipInfo);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static ShipData LoadShip()
    {
        string path = Application.persistentDataPath + "/Ship.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.Open(path, FileMode.Open);

            ShipData data = formatter.Deserialize(stream) as ShipData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
