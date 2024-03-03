using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public bool Stop=false;
   [SerializeField] GameObject platform;

   [SerializeField] Transform lastPlatformPosition,environmentTransform;
   private Vector3 lastPos,newPos;



    void Start()
    {
        lastPos=lastPlatformPosition.position;
        StartCoroutine(SpawnPlatform());
    }

   

    void GeneratePlatform()
    {
        newPos=lastPos;
        int rand=Random.Range(0,2);

        if(rand>0)
        {
            newPos.x+=2f;
        }else{
            newPos.z+=2f;
        }

        lastPos=newPos;
    }

    IEnumerator SpawnPlatform()
    {
        while(!Stop)
        {
            GeneratePlatform();
            Instantiate(platform,newPos,Quaternion.identity).transform.SetParent(environmentTransform);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
