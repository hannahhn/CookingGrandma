using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Button checkmark, redo_button;
    public GameObject CompleteIngredient;
    public GameObject TooEarlyText;
    public GameObject TooLateText;
    public static bool cookSoupComplete, cookPastaComplete, cookBurgerComplete, cookSteakComplete = false;
    public string currentDish;
    Image timerBar;
    float currentTime;
    float maxTime = 6.0f;
    bool playerClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        currentTime = 0;
        checkmark.onClick.AddListener(checkmarkClicked);
        redo_button.onClick.AddListener(redoScene);
    }

    // Update is called once per frame
    void Update()
    {
        if((currentTime / maxTime) > 0.574) // only for burger, shows cooked meat on pan
        {
            CompleteIngredient.SetActive(true);
        }

        if(Input.GetMouseButton(0)) // equivalent to touch
        {
            if(((currentTime/maxTime) > 0.574) && ((currentTime/maxTime) < 0.849))
            {
                playerClicked = true;
                checkmark.gameObject.SetActive(true);
            }
            else if(((currentTime/maxTime) < 0.574) && ((currentTime/maxTime) > 0.1))
            {
                playerClicked = true;
                TooEarlyText.SetActive(true);
                redo_button.gameObject.SetActive(true);
            }
            else if((currentTime/maxTime) > 0.849)
            {
                playerClicked = true;
                TooLateText.SetActive(true);
                redo_button.gameObject.SetActive(true);
            }
        }

        if(!playerClicked)
        {
            if(currentTime < maxTime)
            {
                currentTime += Time.deltaTime;
                timerBar.fillAmount = currentTime / maxTime;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }

    public void checkmarkClicked()
    {
        if(currentDish.Equals("Burger"))
        {
            cookBurgerComplete = true;
            SceneManager.LoadScene("Recipe_Scene");
        }
        else if(currentDish.Equals("Soup"))
        {
            cookSoupComplete = true;
            SceneManager.LoadScene("Recipe_Scene");
        }
        else if(currentDish.Equals("Pasta"))
        {
            cookPastaComplete = true;
            SceneManager.LoadScene("Recipe_Scene");
        }
        else if(currentDish.Equals("Steak"))
        {
            cookSteakComplete = true;
            SceneManager.LoadScene("Recipe_Scene");
        }
    }

    void redoScene()
    {
        if(currentDish.Equals("Burger"))
        {
            SceneManager.LoadScene("Cook_Burger");
        }
        else if(currentDish.Equals("Soup"))
        {
            SceneManager.LoadScene("Cook_Soup");
        }
        else if(currentDish.Equals("Pasta"))
        {
            SceneManager.LoadScene("Cook_Pasta");
        }
        else if(currentDish.Equals("Steak"))
        {
            SceneManager.LoadScene("Cook_Steak");
        }
    }
}
