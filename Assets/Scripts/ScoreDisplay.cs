using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    GameSession gameSession;
    TextMeshProUGUI scoreText;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!gameSession) return;
        scoreText.text = gameSession.GetScore().ToString();
    }
}
