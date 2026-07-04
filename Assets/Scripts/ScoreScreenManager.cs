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
        AudioManager.Instance.Play(AudioManager.SoundType.Fanfare);

        scoreScreenText.text = score.ToString();

        // Nach Score sortieren
        var sorted = ScoreBoardManager.entries
            .OrderByDescending(e => e.score)
            .ToList();

        // Zuletzt gespielte Runde
        ScoreBoardManager.ScoreEntry currentEntry = ScoreBoardManager.entries.Last();

        // Platz der aktuellen Runde in sortierter Liste
        int currentIndex = sorted.IndexOf(currentEntry);

        string scoreboard = "";

        scoreboard += "TOP 3\n\n";

        for (int i = 0; i < Mathf.Min(3, sorted.Count); i++)
        {
            scoreboard += $"{i + 1}. Platz: " +
                          $"Runde {sorted[i].playerId}   " +
                          $"Score {sorted[i].score}   " +
                          $"{sorted[i].endTime} Uhr\n";
        }
        scoreboard += "\n------------------------\n\n";

        if (currentIndex > 0)
        {
            var above = sorted[currentIndex - 1];

            scoreboard += "Über dir\n";
            scoreboard += $"{currentIndex}. Platz: " +
                          $"Runde {above.playerId}   " +
                          $"Score {above.score}   " +
                          $"{above.endTime} Uhr\n\n";
        }

        var me = sorted[currentIndex];

        scoreboard += "<b><color=#FFA500>Deine Runde</color></b>\n";
        scoreboard += $"<b><color=#FFA500>{currentIndex + 1}. Platz: " +
                      $"Runde {me.playerId}   " +
                      $"Score {me.score}   " +
                      $"{me.endTime} Uhr</color></b>\n\n";

        if (currentIndex < sorted.Count - 1)
        {
            var below = sorted[currentIndex + 1];

            scoreboard += "Unter dir\n";
            scoreboard += $"{currentIndex + 2}. Platz: " +
                          $"Runde {below.playerId}   " +
                          $"Score {below.score}   " +
                          $"{below.endTime} Uhr\n";
        }

        scoreboard += "\n------------------------\n\n";

        int totalRounds = ScoreBoardManager.entries.Count;
        string firstRoundTime = ScoreBoardManager.entries.First().endTime;

        if (totalRounds == 1)
        {
            scoreboard += $"Von insgesamt {totalRounds} Runde seit {firstRoundTime} Uhr";
        }
        else
        {
            scoreboard += $"Von insgesamt {totalRounds} Runden seit {firstRoundTime} Uhr";
        }

        scoreboardText.text = scoreboard;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
