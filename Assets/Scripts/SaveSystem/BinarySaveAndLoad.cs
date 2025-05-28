using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class BinarySaveAndLoad 
{

    
   public static void  SaveData(SaveObject saveObject)
   {
    
        BinaryFormatter formatter=new BinaryFormatter();
        string path=Application.dataPath+"/player/data.txt";

        //open a filestream
        FileStream stream=new FileStream(path,FileMode.Create);

        SaveObject data=new SaveObject(saveObject);
        formatter.Serialize(stream,data); //write data using file stream and Serialize it using Formatter

        stream.Close();
   }


   public static SaveObject LoadData()
   {
        string path=Application.dataPath+"/player.zigzag";
        //check if the file exists?
        if(File.Exists(path))
        {
            BinaryFormatter formatter=new BinaryFormatter();
            FileStream stream=new FileStream(path,FileMode.Open);

            SaveObject data=(SaveObject)formatter.Deserialize(stream) ;

            stream.Close();
            //return the Deserialied data
            return data;

        }else{
            Debug.Log("Not Found : " +path);
            SaveObject data=new SaveObject(0,0);
            return data;
        }
   }
}
