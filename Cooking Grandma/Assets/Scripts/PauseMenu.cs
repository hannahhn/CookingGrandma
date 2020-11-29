using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button pause, Back;
    public GameObject pauseMenu;
    public static bool isPaused = false;
    void Start()
    {
        pause.interactable = true;
        pauseMenu.SetActive(false);
    }


    public void Pause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }


    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void BackToLevels()
    {
        Back.onClick.AddListener(GoToLevelSelection);
    }

    void GoToLevelSelection()
    {
        // resetting all static variables
        GameTimer.timeUp = false;
        GameManager.needNewOrder = true;
        Chop.lettuceComplete = Chop.tomatoComplete = TimerScript.cookSoupComplete = TimerScript.cookPastaComplete = TimerScript.cookBurgerComplete = TimerScript.cookSteakComplete = RecipeManager.combineSaladComplete = RecipeManager.combineSoupComplete = RecipeManager.combineBurgerComplete = RecipeManager.combineSteakComplete = false;
        Time.timeScale = 1f;

        SceneManager.LoadScene("LevelLoader");
    }
}
