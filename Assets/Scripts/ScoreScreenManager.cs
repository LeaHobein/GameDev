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

    for (int i = 0; i < sorted.Count; i++)
        {
            scoreboard += $"Runde {sorted[i].playerId}\t\t{sorted[i].score}\n";
        }

    scoreboardText.text = scoreboard;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
