using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{


    public float pointsPerSecond;


    public TextMesh scoreText;
    public TextMesh hiScoreText;

    private float score;
    private float hiScore;

    public TextMesh moneyScore;

    public int moneyCollected = 0;

    private CoinPicker coinPicker;

    void Start()
    {
        moneyCollected = 0;

        coinPicker = FindObjectOfType<CoinPicker>();

        if(PlayerPrefs.HasKey("HiScore"))
        {
            hiScore = PlayerPrefs.GetFloat("HiScore");
        }

    }

    // Update is called once per frame
    void Update()
    {







        score += pointsPerSecond * Time.deltaTime;

        if (score > hiScore)
        {

            hiScore = score;
            PlayerPrefs.SetFloat("HiScore", hiScore);
        }

        scoreText.text = Mathf.Round(score).ToString();
        hiScoreText.text = Mathf.Round(hiScore).ToString();
        moneyScore.text = moneyCollected.ToString();
    }
}
