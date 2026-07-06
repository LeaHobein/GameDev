using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreScreenManager : MonoBehaviour
{
    public TMP_Text scoreScreenText;
    public TMP_Text gutgemacht;
    public TMP_Text ihrhabt;
    public TMP_Text bauauftraege;

    public TMP_Text top3text;
    public TMP_Text yourScoreText;
    public TMP_Text totalRoundsText;
    public RawImage background2;

    int score = ScoreManager.score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        background2.gameObject.SetActive(false);

        AudioManager.Instance.Play(AudioManager.SoundType.Fanfare);

        scoreScreenText.text = score.ToString();

        if (score == 0)
        {
            gutgemacht.text = "Hoppla!";
            ihrhabt.text = "Punkte:";
            bauauftraege.text = "Probiert's gleich nochmal!";
        }

        if (score == 1)
        {
            bauauftraege.text = "Bauauftrag erfüllt";
        }


        // Nach Score sortieren
        var sorted = ScoreBoardManager.entries
            .OrderByDescending(e => e.score)
            .ToList();

        // Rangliste erstellen (gleiche Scores = gleicher Platz)
        Dictionary<ScoreBoardManager.ScoreEntry, int> ranks = new();

        int currentRank = 1;

        for (int i = 0; i < sorted.Count; i++)
        {
            if (i > 0 && sorted[i].score < sorted[i - 1].score)
            {
                currentRank++;
            }

            ranks[sorted[i]] = currentRank;
        }

        // Zuletzt gespielte Runde
        ScoreBoardManager.ScoreEntry currentEntry = ScoreBoardManager.entries.Last();

        // Position in der sortierten Liste
        int currentIndex = sorted.IndexOf(currentEntry);

        string scoreboard1 = "";
        string scoreboard2 = "";
        string scoreboard3 = "";

        // TOP 3
        for (int i = 0; i < Mathf.Min(3, sorted.Count); i++)
        {
            scoreboard1 +=
                $"{ranks[sorted[i]]}.               " +
                $"Runde {sorted[i].playerId}              " +
                $"{sorted[i].score} P.              " +
                $"{sorted[i].endTime} Uhr\n";
        }

        // Spieler über dir
        if (currentIndex > 0)
        {
            var above = sorted[currentIndex - 1];

            scoreboard2 +=
                $"{ranks[above]}.            " +
                $"Runde {above.playerId}          " +
                $"{above.score} P.         " +
                $"{above.endTime} Uhr\n";
        }
        else
        {
            background2.gameObject.SetActive(true);
            gutgemacht.text = "NEUER HIGHSCORE!";
        }

        // Deine Runde
        var me = sorted[currentIndex];

        scoreboard2 +=
            $"<b><color=#FFA500>{ranks[me]}.        " +
            $"Runde {me.playerId}      " +
            $"{me.score} P.      " +
            $"{me.endTime} Uhr</color></b>\n";

        // Spieler unter dir
        if (currentIndex < sorted.Count - 1)
        {
            var below = sorted[currentIndex + 1];

            scoreboard2 +=
                $"{ranks[below]}.            " +
                $"Runde {below.playerId}          " +
                $"{below.score} P.         " +
                $"{below.endTime} Uhr\n";
        }
        else
        {
            background2.gameObject.SetActive(true);
        }

        int totalRounds = ScoreBoardManager.entries.Count;
        string firstRoundTime = ScoreBoardManager.entries.First().endTime;

        if (totalRounds == 1)
        {
            scoreboard3 += $"Von insgesamt {totalRounds} Runde seit {firstRoundTime} Uhr";
        }
        else
        {
            scoreboard3 += $"Von insgesamt {totalRounds} Runden seit {firstRoundTime} Uhr";
        }

        top3text.text = scoreboard1;
        yourScoreText.text = scoreboard2;
        totalRoundsText.text = scoreboard3;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
