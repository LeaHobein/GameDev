using System.Collections.Generic;
using System;

public static class ScoreBoardManager
{
    public class ScoreEntry
    {
        public int playerId;
        public int score;
        public string endTime;

        public ScoreEntry(int playerId, int score, string endTime)
        {
            this.playerId = playerId;
            this.score = score;
            this.endTime = endTime;
        }
    }

    public static List<ScoreEntry> entries = new List<ScoreEntry>();

    public static void AddScore(int playerId, int score)
    {
        string currentTime = DateTime.Now.ToString("HH:mm");//("dd.MM.yyyy HH:mm:ss");
        entries.Add(new ScoreEntry(playerId, score, currentTime));
    }

    public static int playerCount = 0;
}