using UnityEngine;
using System.Collections.Generic;

public static class ScoreBoardManager
{
    public class ScoreEntry
    {
        public int playerId;
        public int score;

        public ScoreEntry(int playerId, int score)
        {
            this.playerId = playerId;
            this.score = score;
        }
    }

    public static List<ScoreEntry> entries = new List<ScoreEntry>();

    public static void AddScore(int playerId, int score)
    {
        entries.Add(new ScoreEntry(playerId, score));
    }

    public static int playerCount = 0;
}