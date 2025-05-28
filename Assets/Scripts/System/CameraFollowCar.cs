using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollowCar : MonoBehaviour
{
   [SerializeField] Transform target;
   [SerializeField] float followSpeed=5f;
   private Vector3 distance;
   private Transform myTransform;


    void Start()
    {
        myTransform=GetComponent<Transform>();
        distance=target.position-myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if(target.position.y>=-1) Follow();
    }

    void Follow()
    {
        Vector3 targetWithOffset=target.position-distance;

        myTransform.position=Vector3.Lerp(myTransform.position,targetWithOffset,followSpeed);
    }

    void ChnageColor(Color col)
    {
       Camera.main.backgroundColor=col;
    }

    //listen from the change time event
    public void ListenTimeChangeEvent(Component sender,object data)
    {
        if(sender is GameManager)
        {
            ChnageColor((Color)data);
        }
    }
}
