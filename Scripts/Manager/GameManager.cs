using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.TextCore;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameEvent gameStartedEvent,gameoverEvent,chnageTimeEvent;
    [SerializeField] GameObject platformSpawner;
    public float platfromFallTimmer=0.3f;
    public bool IsGameStarted=false;

    private bool DayTime=true;
    [SerializeField] float dayNightChnageTimmer=30f,diectionLightXAngel=-6;
    [SerializeField] Transform directionLightTransform;
    [SerializeField] Color dayCameraColor,nightCameraColor;

    void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
        platformSpawner.SetActive(false);
    }
    void Start()
    {
        AudioManager.instance.PlayBackgroundSound("Game BackGround",10);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&  !IsGameStarted)
        {
            GameStarted();
        }
    }


    public void GameStarted()
    {
        IsGameStarted=true;
        gameStartedEvent.Raise(this,true);
        platformSpawner.SetActive(true);
    }

    public void GameOver()
    {
        gameoverEvent.Raise(this,true);
        platformSpawner.SetActive(false);
        IsGameStarted=false;

    }

    IEnumerator CheangeTime()
    {
        yield return new WaitForSeconds(dayNightChnageTimmer);
        if(DayTime)
        {
            DayTime=false;
            chnageTimeEvent.Raise(this,nightCameraColor);
            directionLightTransform.rotation=Quaternion.Euler(diectionLightXAngel,-30,0); 
        }else{
            DayTime=true;
            chnageTimeEvent.Raise(this,dayCameraColor);
            directionLightTransform.rotation=Quaternion.Euler(60,-30,0);
        }
        StartCoroutine(CheangeTime());
    }



}
