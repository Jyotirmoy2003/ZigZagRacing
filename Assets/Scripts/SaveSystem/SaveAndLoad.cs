using UnityEngine;
using System.IO;

public class SaveAndLoad : MonoBehaviour
{
    public static SaveAndLoad instance;

    private static  string SAVE_FOLDER;
    SaveObject saveObject=new SaveObject();
    SaveObject lodedSavobject=new SaveObject();
    string json;

   



    void Awake()
    {
        if(instance==null) instance=this;
        else{
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);


       
        SAVE_FOLDER=Application.persistentDataPath + "/Saves/";
        
        //Test if Save Folder Exists
        if(!Directory.Exists(SAVE_FOLDER))
        {
            //create Folder
            Directory.CreateDirectory(SAVE_FOLDER);
            print("Create Directory");
        }
    }
    


    public void SaveGame(SaveObject sobj)
    {  
        try{ 
            //Set All Data in SaveObject 
        saveObject.amountOfGem=sobj.amountOfGem;
        saveObject.amountOfStar=sobj.amountOfStar;
        saveObject.curretnSelectedCarIndex=sobj.curretnSelectedCarIndex;
        saveObject.amountOfStar=sobj.amountOfStar;
        for(int i=0;i<saveObject.playerCars.Length;i++)
        {
            saveObject.playerCars[i]=sobj.playerCars[i];
        }
        


        //conver to Json String
        json= JsonUtility.ToJson(saveObject);
        //save it
        File.WriteAllText(SAVE_FOLDER +"/save.txt",json);
        

        }
        catch(UnassignedReferenceException ex){
            print("Error"+ex);
        }
       
    }

    public SaveObject LoadGame()
    {
        //Text If file Exists
        if(File.Exists(SAVE_FOLDER + "/save.txt"))
        {
            //load the string
            string saveString=File.ReadAllText(SAVE_FOLDER + "/save.txt");
            lodedSavobject = JsonUtility.FromJson<SaveObject>(saveString);

            //set All data In Game
            
           return lodedSavobject;

        }        
        return new SaveObject(0,0);
    }

   
    
}


