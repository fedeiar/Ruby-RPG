using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerData Data) {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/RubyData.binary";
        FileStream stream = new FileStream(path, FileMode.Create);

        

        formatter.Serialize(stream, Data);
        stream.Close();
    }

    public static PlayerData LoadPlayer() {

        string path = Application.persistentDataPath + "/RubyData.binary";

        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = (PlayerData) formatter.Deserialize(stream);

            stream.Close();

            return data;
        }
        else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }

    }

    

    public static bool FileExists() {
        string path = Application.persistentDataPath + "/RubyData.binary";
        return File.Exists(path);
    }

    public static void DeleteData() {
        string path = Application.persistentDataPath + "/RubyData.binary";
        File.Delete(path);
    }
}
