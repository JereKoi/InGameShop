using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    string gameId = "4401142";
#else
    string gameId = "4401143";
#endif

    public static ShopManagerScript shopmanagerscript;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
    }

    public void RewardAd()
    {
        if (Advertisement.IsReady("Reward"))
        {
            Advertisement.Show("Reward");
        }
        else
        {

        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("ads are ready!");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ERROR: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("video started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Reward" && showResult == ShowResult.Finished)
        {
            ShopManagerScript.Instance.coins = 1000;
            ShopManagerScript.Instance.CoinsTXT.text = "Coins:" + ShopManagerScript.Instance.coins.ToString();
            PlayerPrefs.SetFloat("coins", ShopManagerScript.Instance.coins);
        }
    }
}
