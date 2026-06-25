using TMPro;
using UnityEngine;
using System.Linq;

public class ScoreScreenManager : MonoBehaviour
{
    public TMP_Text scoreScreenText;
    public TMP_Text scoreboardText;
    int score = ScoreManager.score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreScreenText.text = score.ToString();
        //Sortieren nach Score
        var sorted = ScoreBoardManager.entries
                .OrderByDescending(e => e.score)
                .ToList();

        string scoreboard = "";

        scoreboard += string.Format("{0,-10}{1,-10}{2,-20}\n",
                                "RUNDE", "PUNKTE", "UHRZEIT");

        scoreboard += "-------------------------------------------\n";

        for (int i = 0; i < sorted.Count; i++)
        {
            scoreboard += string.Format("{0,-10}{1,-10}{2,-20}\n",
                                    sorted[i].playerId,
                                        sorted[i].score,
                                        sorted[i].endTime);
        }

        scoreboardText.text = scoreboard;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
