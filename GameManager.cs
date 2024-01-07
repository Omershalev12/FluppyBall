using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI EndScoreText2;
    public PlayerController ourPlayer;
    public GameObject extralifepanel;
    public GameObject GameOverPanel2;
    public GameObject PausePanel;
    public GameObject threePanel;
    public GameObject twoPanel;
    public GameObject onePanel;
    public float pausedelay;
    public int blinkCount;
    public float blinkDelay;
    public bool sawAd = false;


    // Start is called before the first frame update
    void Start()
    {
        ourPlayer = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ourPlayer.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Time.timeScale = 0;
        if (sawAd == true)
        {
            GameOverPanel2.SetActive(true);
            EndScoreText2.text = "Score: " + ourPlayer.score;
        }
        if (sawAd == false)
        {
            extralifepanel.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        if (ourPlayer.lives == 0)
        {
            ourPlayer.stars = ourPlayer.stars + ourPlayer.starCount;
            PlayerPrefs.SetInt("starsCollected", ourPlayer.stars);
            ourPlayer.stars = PlayerPrefs.GetInt("starsCollected");
        }
        ourPlayer.lives = 1;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void pause()
    {
        ourPlayer.isPause = true;
        Time.timeScale = 0;
        ourPlayer.GetComponent<Rigidbody>().velocity = Vector3.up * 0;
        PausePanel.SetActive(true);
    }

    public void resume()
    {
        PausePanel.SetActive(false);
        ourPlayer.GetComponent<Rigidbody>().velocity = Vector3.up * 0;
        StartCoroutine(countdowm());
    }
    public void Continue()
    {
        extralifepanel.SetActive(false);
        sawAd = true;
        StartCoroutine(countdowm2());
    }
    public void Skip()
    {
        sawAd = true;
        extralifepanel.SetActive(false);
    }

    public IEnumerator countdowm()
    {
        Time.timeScale = 0.0001f;
        threePanel.SetActive(true);
        yield return new WaitForSeconds(pausedelay);
        threePanel.SetActive(false);
        twoPanel.SetActive(true);
        yield return new WaitForSeconds(pausedelay);
        twoPanel.SetActive(false);
        onePanel.SetActive(true);
        yield return new WaitForSeconds(pausedelay);
        onePanel.SetActive(false);
        ourPlayer.isPause = false;
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
    }

    public IEnumerator countdowm2()
    {
        ourPlayer.GetComponent<SphereCollider>().isTrigger = true;
        Time.timeScale = 0.0001f;
        yield return new WaitForSeconds(0.0001f);
        threePanel.SetActive(true);
        yield return new WaitForSeconds(pausedelay);
        threePanel.SetActive(false);
        twoPanel.SetActive(true);
        yield return new WaitForSeconds(pausedelay);
        twoPanel.SetActive(false);
        onePanel.SetActive(true);
        yield return new WaitForSeconds(pausedelay);
        onePanel.SetActive(false);
        ourPlayer.isPause = false;
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
            if(ourPlayer.isInvisible == false)
            {
                ourPlayer.GetComponent<MeshRenderer>().enabled = false;
                yield return new WaitForSeconds(blinkDelay);
                ourPlayer.GetComponent<MeshRenderer>().enabled = true;
                yield return new WaitForSeconds(blinkDelay);
            }
        }
        yield return new WaitForSeconds(0.5f);
        if (ourPlayer.isInvisible == false)
        {
            ourPlayer.GetComponent<SphereCollider>().isTrigger = false;
        }
    }

    public void Menu()
    {
        if (ourPlayer.lives == 0)
        {
            ourPlayer.stars = ourPlayer.stars + ourPlayer.starCount;
            PlayerPrefs.SetInt("starsCollected", ourPlayer.stars);
            ourPlayer.stars = PlayerPrefs.GetInt("starsCollected");
        }
        ourPlayer.isPause = false;
        ourPlayer.lives = 1;
        sawAd = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}