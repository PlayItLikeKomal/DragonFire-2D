using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class ads : MonoBehaviour//,IUnityAdsListener
{

    string gameid = "4982867";
    bool testmode = true;

    string videoad = "Interstitial_Android";
    string rewardedvidepad = "Rewarded_Android";
    string banneradid = "banner";

    private void Start()
    {
        //  Advertisement.AddListener(this);
        Advertisement.Initialize(gameid, testmode);

    }

    public void displayvideoad()
    {
        Advertisement.Show(videoad);
    }


}
