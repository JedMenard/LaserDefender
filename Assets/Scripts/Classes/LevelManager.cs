using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private ScoreKeeper scoreKeeper;

    private void Awake() => this.scoreKeeper = FindObjectOfType<ScoreKeeper>();

    public void LoadGame()
    {
        this.scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver(float delay = 0)
    {
        StartCoroutine(this.DelayLoadScene("GameOver", delay));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public IEnumerator DelayLoadScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
