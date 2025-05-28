using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CarShowCase : MonoBehaviour
{
    [SerializeField] Transform carTransform;
    [SerializeField] Transform carParent;
    [SerializeField] int CurrentIndex=0;
    [SerializeField] TMP_Text selectButtonText;
    [SerializeField] TMP_Text priceText;
    [SerializeField] GameObject buyButton,selectButton;

    void Init()
    {
        CurrentIndex= SaveManager.instance.globalSaveObject.curretnSelectedCarIndex;


        ShowCar(CurrentIndex);
    }

    #region  Buttons
    public void OnBuy()
    {
        if(SaveManager.instance.globalSaveObject.amountOfStar>=Car.instance.GetPrice(CurrentIndex))
        {
            SaveManager.instance.globalSaveObject.playerCars[CurrentIndex]=1;
            CurrencyManager.instacne.AddStar(Car.instance.GetPrice(CurrentIndex)*-1);

            selectButton.SetActive(true);
            buyButton.SetActive(false);
            selectButtonText.text="SELECTED";
            SaveManager.instance.globalSaveObject.curretnSelectedCarIndex=CurrentIndex;
            SaveManager.instance.Save();
        }
    }
    public void LeftArrow()
    {
        if(CurrentIndex<=0) return;
        CurrentIndex--;
        ShowCar(CurrentIndex);
    }

    public void RightArrow()
    {
        if(CurrentIndex>=Car.instance.carMoodels.Count-1) return;
        CurrentIndex++;
        ShowCar(CurrentIndex);
    }

    public void SelectCar()
    {
        selectButtonText.text="SELECTED";
        SaveManager.instance.globalSaveObject.curretnSelectedCarIndex=CurrentIndex;
        SaveManager.instance.Save();
        LevelLoder.instance.LoadLevel(1);
    }

    #endregion

    
    public void ShowCar(int index)
    {
        //Instantiate care
        Transform newCarModel=Instantiate(Car.instance.GetCar(index),carTransform.position,carTransform.rotation).transform;
        newCarModel.SetParent(carParent);
        //Set Button acording to player data (check if player already bougth the car)
        if(SaveManager.instance.globalSaveObject.curretnSelectedCarIndex==CurrentIndex)
        {
            selectButton.SetActive(true);
            buyButton.SetActive(false);
            selectButtonText.text="SELECTED";
        }else if(SaveManager.instance.globalSaveObject.playerCars[CurrentIndex]==1)
        {
            selectButton.SetActive(true);
            buyButton.SetActive(false);
            selectButtonText.text="SELECT";
        }else{
            selectButton.SetActive(false);
            buyButton.SetActive(true);
        }
        //Destroy old car and set new price
        Destroy(carTransform.gameObject);
        carTransform=newCarModel;
        SetCarPrice(CurrentIndex);
    }

    void SetCarPrice(int index)
    {
        priceText.text=Car.instance.GetPrice(index).ToString();
    }

    public void ListenToDoneInit(Component Sender,object data)
    {
        Init();
    }
}
