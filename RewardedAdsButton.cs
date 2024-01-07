using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class RewardedAdsButton : MonoBehaviour, IUnityAdsListener
{

    private string gameId = "3895825";
    int stars = 0;
    Button myButton;
    public PlayerController ourPlayer;
    public GameManager gameManager;
    public string myPlacementId;
    public float pausedelay;
    public int blinkCount;
    public float blinkDelay;
    public bool isWatching = false;
    void Start()
    {
        myButton = GetComponent<Button>();
        if (PlayerPrefs.HasKey("starsCollected"))
        {
            stars = PlayerPrefs.GetInt("starsCollected");
        }
        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady(myPlacementId);

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
        if (myPlacementId == "exstralife")
        {
            ourPlayer = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        }
    }

    void update()
    {
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if (placementId == myPlacementId && myPlacementId == "rewardedVideo")
            {
                stars = stars + 1;
                PlayerPrefs.SetInt("starsCollected", stars);
                stars = PlayerPrefs.GetInt("starsCollected");
            }
            else if (placementId == myPlacementId && myPlacementId == "exstralife")
            {

                ourPlayer.lives++;
                ourPlayer.GetComponent<Rigidbody>().velocity = Vector3.up * 0;
                StartCoroutine(countdowm());
            }
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
        isWatching = false;
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
        isWatching = true;
    }
    public IEnumerator countdowm()
    {
        gameManager.sawAd = true;
        ourPlayer.GetComponent<SphereCollider>().isTrigger = true;
        Time.timeScale = 0.0001f;
        gameManager.threePanel.SetActive(true);
        yield return new WaitForSeconds(gameManager.pausedelay);
        gameManager.threePanel.SetActive(false);
        gameManager.twoPanel.SetActive(true);
        yield return new WaitForSeconds(gameManager.pausedelay);
        gameManager.twoPanel.SetActive(false);
        gameManager.onePanel.SetActive(true);
        yield return new WaitForSeconds(gameManager.pausedelay);
        gameManager.onePanel.SetActive(false);
        ourPlayer.GetComponent<Rigidbody>().velocity = Vector3.up * 0;
        if (ourPlayer.score <= 20 && ourPlayer.lives != 0)
        {
            Time.timeScale = 1f;
        }
        if (ourPlayer.score > 20 && ourPlayer.score < 30 && ourPlayer.lives != 0)
        {
            Time.timeScale = 1.05f;
        }
        if (ourPlayer.score > 30 && ourPlayer.score < 40 && ourPlayer.lives != 0)
        {
            Time.timeScale = 1.1f;
        }
        if (ourPlayer.score > 40 && ourPlayer.score < 50 && ourPlayer.lives != 0)
        {
            Time.timeScale = 1.15f;
        }
        if (ourPlayer.score > 50 && ourPlayer.score < 60 && ourPlayer.lives != 0)
        {
            Time.timeScale = 1.2f;
        }
        if (ourPlayer.score > 60 && ourPlayer.score < 70 && ourPlayer.lives != 0)
        {
            Time.timeScale = 1.25f;
        }
        if (ourPlayer.score > 70 && ourPlayer.score < 80 && ourPlayer.lives != 0)
        {
            Time.timeScale = 1.3f;
        }
        if (ourPlayer.score > 80 && ourPlayer.score < 100 && ourPlayer.lives != 0)
        {
            Time.timeScale = 1.35f;
        }
        if (ourPlayer.score > 100 && ourPlayer.score < 120 && ourPlayer.lives != 0)
        {
            Time.timeScale = 1.4f;
        }
        if (ourPlayer.score > 120 && ourPlayer.lives != 0)
        {
            Time.timeScale = 1.45f;
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 5; i++)
        {
            ourPlayer.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            ourPlayer.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);

        }
        yield return new WaitForSeconds(0.5f);
        ourPlayer.GetComponent<SphereCollider>().isTrigger = false;
        
    }
}
