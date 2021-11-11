using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int scenesTotalCount = SceneManager.sceneCountInBuildSettings;
        GameSession gameStatus = FindObjectOfType<GameSession>();

        if (currentSceneIndex == 0 && gameStatus != null)
            gameStatus.SetGameTextStatus(true);
        if (currentSceneIndex + 2 == scenesTotalCount && gameStatus != null)
            gameStatus.SetGameTextStatus(false);

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadScene(int requestedScene)
    {
        if (requestedScene >= 0 && requestedScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(requestedScene);
        }
    }

    public void LoadStartScene()
    {
        GameSession gameStatus = FindObjectOfType<GameSession>();
        gameStatus.RestartGameStatus();

        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
