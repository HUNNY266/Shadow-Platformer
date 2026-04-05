using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{ 
    AudioManager audio;
    ScoreKeeper score;

    void Awake() 
    {
        audio = FindFirstObjectByType<AudioManager>();
        score = FindFirstObjectByType<ScoreKeeper>();
    }
    public void OnStartGame()
    {
        SceneManager.LoadScene("GameScene");
        score.ResetScore();
    }

    public void OnExit()
    {
        // Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void GameOver()
    {
        audio.GameOverVFX();
        StartCoroutine(GameOverDelay());
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(2f);
         SceneManager.LoadScene("GameOver");
    }
}
