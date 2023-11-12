using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score;

    private void Awake()
    {
        score = 0;
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        score = 0;
        Destroy(gameObject);
    }
}
