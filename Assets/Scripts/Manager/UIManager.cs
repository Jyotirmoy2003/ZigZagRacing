using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
   [SerializeField] GameObject ExitPanel,restartPanel;
   [SerializeField] GameEvent restartEvent;
    void Start()
    {
        restartPanel.SetActive(false);
    }


    //fun to turn on score/restart panel
    void ActiveRestartPanel()
    {
        restartPanel.SetActive(true);
    }
    #region  Buttons
    public void OnClickRestart()
    {
        restartEvent.Raise(this,true); //raise event
        restartPanel.SetActive(false);
        LevelLoder.instance.LoadLevel(0); //load scene
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
    #endregion


    //listen to game over event
    public void ListenToGameOver(Component sender,object data)
    {
        if(sender is GameManager)
        {
            ActiveRestartPanel();
        }
    }
}
