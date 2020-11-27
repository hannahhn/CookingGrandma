using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Button Back_Button, Replay_Button;
    public Sprite Filled_Star;
    public Image Star1, Star2, Star3;
    public Text goalScoreText, playerScoreText, expertScoreText;
    public GameObject Confetti;
    float goalScore, playerScore, expertScore;
    float currentDisplayScore = 0;

    void Start()
    {
        Back_Button.onClick.AddListener(GoToLevelSelection);
        Replay_Button.onClick.AddListener(ReplayLevel);

        CalculateScore();

        /*
        playerScore = 1100;
        goalScore = 900;
        expertScore = 1000;
        StartCoroutine(CountUpScore());
        */

        if(GoToLevels.currentLevel.Equals("LevelOne"))
        {
            goalScore = 150;
            expertScore = 250;
            StartCoroutine(CountUpScore());
        }
        else if(GoToLevels.currentLevel.Equals("LevelTwo"))
        {
            goalScore = 400;
            expertScore = 500;
            StartCoroutine(CountUpScore());
        }
        else if(GoToLevels.currentLevel.Equals("LevelThree"))
        {
            goalScore = 700;
            expertScore = 800;
            StartCoroutine(CountUpScore());
        }
        else if(GoToLevels.currentLevel.Equals("LevelFour"))
        {
            goalScore = 900;
            expertScore = 1000;
            StartCoroutine(CountUpScore());
        }

        // resetting all static variables
        GameTimer.timeLeft = 60;
        GameTimer.timeUp = false;
        GameManager.needNewOrder = true;
        Chop.lettuceComplete = Chop.tomatoComplete = TimerScript.cookSoupComplete = TimerScript.cookPastaComplete = TimerScript.cookBurgerComplete = TimerScript.cookSteakComplete = RecipeManager.combineSaladComplete = RecipeManager.combineSoupComplete = RecipeManager.combineBurgerComplete = RecipeManager.combineSteakComplete = false;
    }

    private IEnumerator CountUpScore()
    {
        yield return new WaitForSeconds(1);
        while (currentDisplayScore < goalScore) // counts up goal score
        {
            currentDisplayScore += 5;
            currentDisplayScore = Mathf.Clamp(currentDisplayScore, 0, goalScore);
            goalScoreText.text = currentDisplayScore + "";
            yield return null;
        }
        currentDisplayScore = 0;
        yield return new WaitForSeconds(1);
        while (currentDisplayScore < expertScore) // counts up expert score
        {
            currentDisplayScore += 5;
            currentDisplayScore = Mathf.Clamp(currentDisplayScore, 0, expertScore);
            expertScoreText.text = currentDisplayScore + "";
            yield return null;
        }
        currentDisplayScore = 0;
        yield return new WaitForSeconds(1);
        while (currentDisplayScore < playerScore) // counts up player score
        {
            currentDisplayScore += 2;
            currentDisplayScore = Mathf.Clamp(currentDisplayScore, 0, playerScore);
            playerScoreText.text = currentDisplayScore + "";
            if(currentDisplayScore >= (goalScore*.7))
            {
                Star1.sprite = Filled_Star;
            }
            if(currentDisplayScore >= goalScore)
            {
                Star2.sprite = Filled_Star;
            }
            if(currentDisplayScore >= expertScore)
            {
                Star3.sprite = Filled_Star;
            }
            yield return null;
        }

        if(playerScore >= goalScore)
        {
            Confetti.SetActive(true);
        }
    }

    void CalculateScore()
    {
        playerScore = GameManager.saladsComplete*70 + GameManager.soupsComplete*80 + GameManager.burgersComplete*90 + GameManager.steaksComplete*100;
    }

    void GoToLevelSelection()
    {
        if(playerScore >= goalScore)
        {
            if(GoToLevels.currentLevel.Equals("LevelOne"))
            {
                GoToLevels.levelOneComplete = true;
            }
            else if(GoToLevels.currentLevel.Equals("LevelTwo"))
            {
                GoToLevels.levelTwoComplete = true;
            }
            else if(GoToLevels.currentLevel.Equals("LevelThree"))
            {
                GoToLevels.levelThreeComplete = true;
            }
        }

        currentDisplayScore = 0;
        SceneManager.LoadScene("LevelLoader");
    }

    void ReplayLevel()
    {
        currentDisplayScore = 0;
        SceneManager.LoadScene("Recipe_Scene");
    }
}
