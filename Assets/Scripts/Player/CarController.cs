using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
   [SerializeField] float moveSpeed;
   [SerializeField] Transform carModel,carParent;
   
   private bool faceLeft=false,firstTab=false;
   private Transform myTransform;


    void Start()
    {
        myTransform=GetComponent<Transform>();

        int index=SaveManager.instance.globalSaveObject.curretnSelectedCarIndex;
        Transform newModel=Instantiate(Car.instance.GetCar(index),carModel.position,carModel.rotation).transform;
        newModel.SetParent(carParent);
        newModel.localScale=new Vector3(0.5f,0.5f,0.5f);

        Destroy(carModel.gameObject);
        
    }
    void Update()
    {
        if(!GameManager.instance.IsGameStarted) return;
        CheckInput();
    }
    
    void FixedUpdate()
    {
        if(!GameManager.instance.IsGameStarted) return;
        Move();
        

        if(myTransform.position.y<-3)
        {
            GameManager.instance.GameOver();
        }
    }

    //fun to move the body
    void Move()
    {
        myTransform.position+=myTransform.forward*moveSpeed*Time.deltaTime;
    }

    void CheckInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CheckDirection();
        }
    }

    //fun to check the car's current Direction
    void CheckDirection()
    {
        if(faceLeft)
        {
            faceLeft=false;
            myTransform.rotation=Quaternion.Euler(0,90,0);
        }else{
            faceLeft=true;
            myTransform.rotation=Quaternion.Euler(0,0,0);
        }
    }
}
