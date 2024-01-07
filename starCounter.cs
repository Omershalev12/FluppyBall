using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class starCounter : MonoBehaviour
{
    public static starCounter instance;

    public int stars = 0;
    public TextMeshProUGUI starText;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("starsCollected"))
        {
            stars = PlayerPrefs.GetInt("starsCollected");
        }
        starText.text = "x" + stars.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("starsCollected"))
        {
            stars = PlayerPrefs.GetInt("starsCollected");
        }
        starText.text = "x" + stars.ToString();
    }
}
