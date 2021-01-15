using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    IEnumerator WaitSecondsAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
        
    public void LoadGame()
    {
        SceneManager.LoadScene("Game scene");
        FindObjectOfType<GameSession>().resetGame();
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(WaitSecondsAndLoad());
    }

    public void LoadingQuitGame()
    {
        Application.Quit();
    }
}
