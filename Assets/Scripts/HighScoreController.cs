using UnityEngine;

public static class HighScoreController
{
    private const string HighScoreKey = "HighScore";

    public static void SaveHighScore(int highScore)
    {
        PlayerPrefs.SetInt(HighScoreKey, highScore);
        PlayerPrefs.Save();
    }

    public static int LoadHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey);
    }
}