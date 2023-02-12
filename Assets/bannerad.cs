using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
public class bannerad : MonoBehaviour
{
    string GameID = "4982867";
    bool testmode = true;   //make it false when game is uploaded on playstore
    string BannerAdID = "ca-app-pub-3940256099942544/6300978111";
    // Start is called before the first frame update
    void Start()
    {
        //Advertisement.AddListener(this);
        Advertisement.Initialize(GameID, testmode);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        StartCoroutine(ShowAdsWhenInitialized());
    }
    IEnumerator ShowAdsWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(BannerAdID);
    }
}