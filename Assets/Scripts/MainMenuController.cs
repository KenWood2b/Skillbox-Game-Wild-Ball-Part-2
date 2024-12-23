using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Canvas MainMenuCanvas;
    public Canvas LevelMenuCanvas;

    public void ShowLevelSelection()
    {
        MainMenuCanvas.gameObject.SetActive(false);
        LevelMenuCanvas.gameObject.SetActive(true);
    }

    public void ShowMainMenu()
    {
        LevelMenuCanvas.gameObject.SetActive(false);
        MainMenuCanvas.gameObject.SetActive(true);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex); // Загружает сцену по индексу
    }

    public void Exit()
    {
        Application.Quit();
    }
}
