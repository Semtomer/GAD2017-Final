using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class savesystem
{
    // karakterkontrol olan
    public static void saveplayer(karakterkontrol player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.Save";
        FileStream stream = new FileStream(path, FileMode.Create);
        Data datas = new Data(player);
        formatter.Serialize(stream, datas);
        stream.Close();
    }
    // sellersystem olan
    public static void saveplayer1(sellersystem seller)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.Save";
        FileStream stream = new FileStream(path, FileMode.Create);
        Data datas = new Data(seller);
        formatter.Serialize(stream, datas);
        stream.Close();
    }
    // numberofbullet olan
    public static void saveplayer2(numberofbullet bullets)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.Save";
        FileStream stream = new FileStream(path, FileMode.Create);
        Data datas = new Data(bullets);
        formatter.Serialize(stream, datas);
        stream.Close();
    }

    public static Data loadplayer()
    {
        string path = Application.persistentDataPath + "/Player.Save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data datas = formatter.Deserialize(stream) as Data;
            stream.Close();

            return datas;
        }
        else
        {
            Debug.LogError("save couldn't found" + path);
            return null;
        }
    }
   
    /*
    public static Data loadplayer2()
    {
        string path = Application.persistentDataPath + "/Player.Save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data datas = formatter.Deserialize(stream) as Data;
            stream.Close();

            return datas;
        }
        else
        {
            Debug.LogError("save couldn't found" + path);
            return null;
        }
    }
    */
}
