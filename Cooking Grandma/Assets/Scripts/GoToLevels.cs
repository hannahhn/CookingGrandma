using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToLevels : MonoBehaviour
{
    public Button Level_One_Button, Level_Two_Button, Level_Three_Button, Level_Four_Button;
    public static bool levelOneComplete, levelTwoComplete, levelThreeComplete = false;
    public static string currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.ordersComplete = 0;
        Level_One_Button.interactable = true;
        if(levelOneComplete)
        {
            Level_Two_Button.interactable = true;
        }
        if(levelTwoComplete)
        {
            Level_Three_Button.interactable = true;
        }
        if(levelThreeComplete)
        {
            Level_Four_Button.interactable = true;
        }

        Level_One_Button.onClick.AddListener(LevelOneClicked);
        Level_Two_Button.onClick.AddListener(LevelTwoClicked);
        Level_Three_Button.onClick.AddListener(LevelThreeClicked);
        Level_Four_Button.onClick.AddListener(LevelFourClicked);
    }

    public void LevelOneClicked()
    {
        currentLevel = "LevelOne";
        GameTimer.timeLeft = 45;
        SceneManager.LoadScene("Loading_Scene");
    }

    public void LevelTwoClicked()
    {
        currentLevel = "LevelTwo";
        GameTimer.timeLeft = 60;
        SceneManager.LoadScene("Loading_Scene");
    }

    public void LevelThreeClicked()
    {
        currentLevel = "LevelThree";
        GameTimer.timeLeft = 75;
        SceneManager.LoadScene("Loading_Scene");
    }

    public void LevelFourClicked()
    {
        currentLevel = "LevelFour";
        GameTimer.timeLeft = 90;
        SceneManager.LoadScene("Loading_Scene");
    }
}
