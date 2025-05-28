using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instacne;

    [SerializeField] TMP_Text outputText;
    private int amountOfGem=0;
    private int amountOfStar=0;
    private int currentGameStar=0;
    private int currentGameGem=0;

   

    void Awake()
    {
       instacne=this;
    }

    void Init()
    {
        amountOfGem=SaveManager.instance.globalSaveObject.amountOfGem;
        amountOfStar=SaveManager.instance.globalSaveObject.amountOfStar;

        outputText.text=amountOfStar.ToString();
        
    }

    

    //fun to add currency in Local view
    public void AddCurency(Currency val)
    {
        if(val.myType==Currency.CurrencyType.Gem)
        {
            currentGameGem++;
        }else if(val.myType==Currency.CurrencyType.Star)
        {
            currentGameStar++;
        }
    }
    //fun to add in global view
    public void AddStar(int val)
    {
        amountOfStar+=val;
        outputText.text=amountOfStar.ToString();
        SaveManager.instance.globalSaveObject.amountOfStar=amountOfStar;
    }
    public void AddGem(int val) {
        amountOfGem+=val;
        outputText.text=amountOfGem.ToString();
        SaveManager.instance.globalSaveObject.amountOfGem=amountOfGem;
    }

    

    void OnGameOver()
    {
        SaveManager.instance.globalSaveObject.amountOfGem=currentGameGem+amountOfGem;
        SaveManager.instance.globalSaveObject.amountOfStar=currentGameStar+amountOfStar;

        //PlayerPrefs.SetInt("Start",amountOfStar);
        outputText.text="Stars: " + currentGameStar.ToString();
        //Save the Data
        SaveManager.instance.Save();

    }

    public void ListenToGameOver(Component Sender,object data)
    {
        if(Sender is GameManager)
        {
            OnGameOver();
        }
    }

    //when the savemanager script done Initializing 
    public void ListenToDoneInit(Component Sender,object data)
    {
        Init();
    }


    //listen if ad is loaded and shown
    public void ListenToRewardAD(Component sender,object data)
    {
        if(sender is AdModAdsScript && data is true)
        {
            currentGameStar*=2;
            OnGameOver();

        }
    }
}
