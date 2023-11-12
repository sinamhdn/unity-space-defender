using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] float delaySeconds = 2f;

    public void LoadStartMenu()
    {
        // loading with index is better than string literals
        // SceneManager.LoadScene(0);
        SceneManager.LoadScene("StartMenu");
    }

    public void ReloadGame()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("Game");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoadGameOver());
        // SceneManager.LoadScene("GameOver");
    }

    IEnumerator WaitAndLoadGameOver()
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadGameComplete()
    {
        StartCoroutine(WaitAndLoadGameComplete());
    }

    IEnumerator WaitAndLoadGameComplete()
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene("GameComplete");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
