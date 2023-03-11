using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    public Text LastScore;
    public Text HighestScore;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("lastscore"))
        {
            LastScore.text = "Last Score: " + PlayerPrefs.GetInt("lastscore");
        }
        else
        {
            LastScore.text = "Last Score: 0";
        }

        if (PlayerPrefs.HasKey("highscore"))
        {
            HighestScore.text = "Last Score: " + PlayerPrefs.GetInt("highscore");
        }
        else
        {
            HighestScore.text = "Highest Score: 0";
        }
    }
}
