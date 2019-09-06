using UnityEngine;

public static class HighScore
{
    private static string _highScoreKey = "HighScore";
    
    private static int _highScore;

    public static void SaveHighScore(int highScore)
    {
        PlayerPrefs.SetInt(_highScoreKey, highScore);
        PlayerPrefs.Save();
    }

    public static int LoadHighScore()
    {
        return PlayerPrefs.GetInt(_highScoreKey);
    }
}