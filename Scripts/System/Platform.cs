using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Platform : MonoBehaviour
{
    [SerializeField] float fallLimit=-2;
    [Range(1,5)]
    [SerializeField] int addScore=1;
    [SerializeField] List<Currency> spawnables=new List<Currency>();
    

    void Start()
    {
        Spawn();
    }

    void OnCollisionEnter(Collision info)
    {
        if(info.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DestroyPlatform());
        }
    }

    IEnumerator DestroyPlatform()
    {
        //wait untill the timmer ends 
        yield return new WaitForSeconds(GameManager.instance.platfromFallTimmer);

        Vector3 tempNewPos=transform.position;
        //let platform fall slowly
        while(tempNewPos.y>=fallLimit)
        {
            tempNewPos=new Vector3(transform.position.x,transform.position.y-Time.deltaTime,transform.position.z);
            transform.position=tempNewPos;
            
            yield return  null;
        }
        //add score before destroing
        ScoreManager.instance.AddScore(addScore);
        Destroy(this.gameObject);
        
        
    }


    void Spawn()
    {
        float cal=0,posx=0;
        Vector3 newPosition;
        foreach(Currency item in spawnables)
        {
            cal=Random.Range(0f,101f);
            posx=Random.Range(transform.position.x-0.2f,transform.position.x+0.2f);
            newPosition=new Vector3(posx,1f,transform.localPosition.z);
            if(item.chance>cal)
            {
                Instantiate(item.gameObject,newPosition,Quaternion.identity).transform.SetParent(this.transform);
            }
        }
    }
}
