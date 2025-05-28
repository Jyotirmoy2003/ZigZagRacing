using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct CarObject
{   
    public GameObject carModel;
    public int price;
}
public class Car : MonoBehaviour
{
    public static Car instance;
    public List<CarObject> carMoodels=new List<CarObject>();


    void Awake()
    {
        if(instance==null) instance=this;
        else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }


    public GameObject GetCar(int index)
    {
        return carMoodels[index].carModel;
    }
    public int GetPrice(int index)
    {
        return carMoodels[index].price;
    }
}
