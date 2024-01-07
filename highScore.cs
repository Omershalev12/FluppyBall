using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class highScore : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highScore").ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
