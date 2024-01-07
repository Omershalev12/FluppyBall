using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using TMPro;
using UnityEngine.SceneManagement;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    int stars = 0;
    public string id;
    public PlayerController ourPlayer;
    public GameObject threePanel;
    public GameObject twoPanel;
    public GameObject onePanel;
    public GameManager gameManager;
    public float pausedelay;
    public int blinkCount;
    public float blinkDelay;
    public bool isWatching = false;
     

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("starsCollected"))
        {
            stars = PlayerPrefs.GetInt("starsCollected");
        }
        Advertisement.AddListener(this);
        Advertisement.Initialize("3895825", true);
        if (id == "exstralife")
        {
            gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
            ourPlayer = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        }
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("starsCollected") && isWatching == false)
        {
            stars = PlayerPrefs.GetInt("starsCollected");
        }
    }
    
    public void ShowRewardedVideo(string p)
    {
        if (Advertisement.IsReady(p))
        {
            Advertisement.Show(p);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            if (placementId == "rewardedVideo")
            {
                stars = stars + 1;
                PlayerPrefs.SetInt("starsCollected", stars);
                stars = PlayerPrefs.GetInt("starsCollected");

            }
            if (placementId == "exstralife")
            {
                
                
            }
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
        isWatching = false;
    }
    public void OnUnityAdsDidStart(string placementId)
    {
        isWatching = true;


    }
    public void OnUnityAdsReady(string placementId)
    {

    }
    public void OnUnityAdsDidError(string message)
    {

    }
    public IEnumerator countdowm()
    {
        gameManager.sawAd = true;
        ourPlayer.GetComponent<SphereCollider>().isTrigger = true;
        Time.timeScale = 0.0001f;
        gameManager.threePanel.SetActive(true);
        yield return new WaitForSeconds(pausedelay);
        gameManager.threePanel.SetActive(false);
        gameManager.twoPanel.SetActive(true);
        yield return new WaitForSeconds(pausedelay);
        gameManager.twoPanel.SetActive(false);
        gameManager.onePanel.SetActive(true);
        yield return new WaitForSeconds(pausedelay);
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
        for (int i = 0; i < blinkCount; i++)
        {
            ourPlayer.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(blinkDelay);
            ourPlayer.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(blinkDelay);

        }
        yield return new WaitForSeconds(0.5f);
        ourPlayer.GetComponent<SphereCollider>().isTrigger = false;
    }
}
