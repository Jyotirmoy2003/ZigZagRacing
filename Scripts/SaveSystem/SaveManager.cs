using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
   public static SaveManager instance;
   [SerializeField] GameEvent doneInitializationEvent;

   public SaveObject globalSaveObject;

   void Awake()
   {
        if(instance==null)
        {
            instance=this;
            
        }
       
   }

   
   void Start()
   {
       globalSaveObject=SaveAndLoad.instance.LoadGame();
       doneInitializationEvent.Raise(this,true);

       
   }

  
    
   
    public void Save()
    {
        SaveAndLoad.instance.SaveGame(globalSaveObject);
    }
}
