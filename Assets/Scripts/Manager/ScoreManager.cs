using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] GameEvent newHighstScoreEvent;
    [SerializeField] TMP_Text scoretext,highstScoreText;
    private int currentScore=0;
    private int highstScore=0;


    void Awake()=>instance=this;
    
    void Start()
    {
        highstScore=PlayerPrefs.GetInt("HighstScore",0);
    }

   


    public void AddScore(int amount)
    {
        currentScore+=amount;
    }

    public int GetScore(){
        return currentScore;
    }

    public void ListenGameStarted(Component sender,object data)
    {
        if(sender is GameManager)
        {

        }
    }
    public void ListenGameOver(Component sender,object data)
    {
        if(sender is GameManager)
        {
            if(currentScore>highstScore)
            {
                newHighstScoreEvent.Raise(this,currentScore);
                PlayerPrefs.SetInt("HighstScore",currentScore);
                highstScore=currentScore;
                
            }
            //set scores in UI
                scoretext.text="Score: "+currentScore.ToString();
                highstScoreText.text="Highst Score: " + highstScore.ToString();
        }
    }
}
