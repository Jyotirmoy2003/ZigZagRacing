using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ADManager : MonoBehaviour
{
    [SerializeField] TMP_Text adButtonText;
    
    

    public void onClickRewardAD()
    {
        AdModAdsScript.instance.LoadRewardedAd();
        AdModAdsScript.instance.ShowRewardedAd();

    }

    #region  Events

    public void LisrtenToRewardAD(Component sender,object data)
    {
        if(sender is AdModAdsScript && data is true)
        {

        }else if(sender is AdModAdsScript && data is false){
            adButtonText.text="Ad Is Not Availabe";
        }
    }

    public void ListenToGameOver(Component sender,object data)
    {
        if(sender is GameManager)
        {
            AdModAdsScript.instance.LoadBannerAd();
        }
    }
    public void ListenToRestart(Component sender,object data)
    {
        if(data is true)
        {
            AdModAdsScript.instance.DestroyBannerAd();
        }
    }
    #endregion
}
