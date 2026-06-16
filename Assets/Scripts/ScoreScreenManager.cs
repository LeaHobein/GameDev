using TMPro;
using UnityEngine;

public class ScoreScreenManager : MonoBehaviour
{
    public TMP_Text scoreScreenText;
    int score = ScoreManager.score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreScreenText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
