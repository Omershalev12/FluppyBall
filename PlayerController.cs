using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public SphereCollider sc;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI starText;
    public TextMeshProUGUI highscoreText;
    public int blinkCount;
    public float blinkDelay;
    public float jumpPower;
    public int score = 0;
    public int highScore = 0;
    public int starCount = 0;
    public GameObject mainStar;
    public GameObject shieldSphere;
    public bool withShield;
    public bool isPause = false;
    public bool isInvisible = false;
    public float lives = 1;
    public int stars = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        highscoreText.text = "HIGHSCORE: " + highScore.ToString();
        if (PlayerPrefs.HasKey("starsCollected"))
        {
            stars = PlayerPrefs.GetInt("starsCollected");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.velocity += Vector3.up * jumpPower;
        }
        if (score > 20 && score < 30 && lives != 0 && isPause == false)
        {
            Time.timeScale = 1.05f;
        }
        if (score > 30 && score < 40 && lives != 0 && isPause == false)
        {
            Time.timeScale = 1.1f;
        }
        if (score > 40 && score < 50 && lives != 0 && isPause == false)
        {
            Time.timeScale = 1.15f;
        }
        if (score > 50 && score < 60 && lives != 0 && isPause == false)
        {
            Time.timeScale = 1.2f;
        }
        if (score > 60 && score < 70 && lives != 0 && isPause == false)
        {
            Time.timeScale = 1.25f;
        }
        if (score > 70 && score < 80 && lives != 0 && isPause == false)
        {
            Time.timeScale = 1.3f;
        }
        if (score > 90 && score < 100 && lives != 0 && isPause == false)
        {
            Time.timeScale = 1.35f;
        }
        if (score > 100 && score < 120 && lives != 0 && isPause == false)
        {
            Time.timeScale = 1.4f;
        }
        if (score > 120 && lives != 0 && isPause == false)
        {
            Time.timeScale = 1.45f;
        }
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obsticle"))
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
            if (score > highScore)
            {
                PlayerPrefs.SetInt("highScore", score);
                highScore = PlayerPrefs.GetInt("highScore");
            }
            highscoreText.text = "HIGHSCORE: " + highScore.ToString();
        }

        else if (other.CompareTag("invisible"))
        {
            isInvisible = true;
            sc.isTrigger = true;
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < blinkCount; i++)
            {
                GetComponent<MeshRenderer>().enabled = false;
                yield return new WaitForSeconds(blinkDelay);
                GetComponent<MeshRenderer>().enabled = true;
                yield return new WaitForSeconds(blinkDelay);
                
            }
            yield return new WaitForSeconds(0.5f);
            sc.isTrigger = false;
            isInvisible = false;
        }

        else if (other.CompareTag("star"))
        {
            starCount++;
            starText.text = "x" + starCount.ToString();
        }

        else if (other.CompareTag("plusfive"))
        {
            score += 5;
            scoreText.text = "Score: " + score.ToString();
            if (score > highScore)
            {
                PlayerPrefs.SetInt("highScore", score);
                highScore = PlayerPrefs.GetInt("highScore");
            }
            highscoreText.text = "HIGHSCORE: " + highScore.ToString();
        }

        else if (other.CompareTag("shield") && withShield == false)
        {
            withShield = true;
            shieldSphere.SetActive(true);
        }
    }

    IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cube" && withShield == false)
        {
            lives--;
        }
        if (collision.gameObject.tag == "cube" && withShield == true)
        {
            sc.enabled = false;
            shieldSphere.SetActive(false);
            withShield = false;
            yield return new WaitForSeconds(1f);
            sc.enabled = true;
        }
    }
    public void extraLife()
    {
        lives++;
        rb.velocity = Vector3.up * 0;
        isPause = true;
    }
  
}