using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public Button Chop_Lettuce, Chop_Tomato, Cook_Soup, Cook_Pasta, Cook_Burger, Cook_Steak, Combine_Salad, Combine_Soup, Combine_Burger, Combine_Steak, Order_Complete;
    public GameObject Lettuce_Complete, Tomato_Complete, Cook_Soup_Complete, Cook_Pasta_Complete, Cook_Burger_Complete, Cook_Steak_Complete, Combine_Salad_Complete, Combine_Soup_Complete, Combine_Burger_Complete, Combine_Steak_Complete;
    public string currentRecipe;

    void Start()
    {
        // these if statements from lines 17-56 are to activate the checkmarks in the recipe list when
        // the user has completed that ingredient
        if(Chop.lettuceComplete)
        {
            Lettuce_Complete.SetActive(true);
        }
        if(Chop.tomatoComplete)
        {
            Tomato_Complete.SetActive(true);
        }
        if(TimerScript.cookSoupComplete)
        {
            Cook_Soup_Complete.SetActive(true);
        }
        if(TimerScript.cookPastaComplete)
        {
            Cook_Pasta_Complete.SetActive(true);
        }
        if(TimerScript.cookBurgerComplete)
        {
            Cook_Burger_Complete.SetActive(true);
        }
        if(TimerScript.cookSteakComplete)
        {
            Cook_Steak_Complete.SetActive(true);
        }
        if(RecipeManager.combineSaladComplete)
        {
            Combine_Salad_Complete.SetActive(true);
        }
        if(RecipeManager.combineSoupComplete)
        {
            Combine_Soup_Complete.SetActive(true);
        }
        if(RecipeManager.combineBurgerComplete)
        {
            Combine_Burger_Complete.SetActive(true);
        }
        if(RecipeManager.combineSteakComplete)
        {
            Combine_Steak_Complete.SetActive(true);
        }

        if(currentRecipe.Equals("Salad"))
        {
            // if the player has already chopped the lettuce, then the chop lettuce button will be disabled in the recipe list
            if(Chop.lettuceComplete)
            {
                Chop_Lettuce.interactable = false;
            }
            if(Chop.tomatoComplete)
            {
                Chop_Tomato.interactable = false;
            }
            if(Chop.lettuceComplete && Chop.tomatoComplete) // if the player has successfully chopped both the lettuce and the tomato, then the Combine Salad button will be enabled for the user to click
            {
                Combine_Salad.interactable = true;
            }
            if(RecipeManager.combineSaladComplete)
            {
                Combine_Salad.gameObject.SetActive(false);
            }
            // if the user finishes preparing all the ingredients in the recipe list for Salad, the "Next Order" button will appear
            if(Chop.lettuceComplete && Chop.tomatoComplete && RecipeManager.combineSaladComplete)
            {
                Order_Complete.gameObject.SetActive(true);
            }
        }
        else if(currentRecipe.Equals("Soup"))
        {
            if(Chop.tomatoComplete)
            {
                Chop_Tomato.interactable = false;
            }
            if(TimerScript.cookSoupComplete)
            {
                Cook_Soup.interactable = false;
            }
            if(TimerScript.cookPastaComplete)
            {
                Cook_Pasta.interactable = false;
            }
            if(Chop.tomatoComplete && TimerScript.cookSoupComplete && TimerScript.cookPastaComplete)
            {
                Combine_Soup.interactable = true;
            }
            if(RecipeManager.combineSoupComplete)
            {
                Combine_Soup.gameObject.SetActive(false);
            }
            // if the user finishes preparing all the ingredients in the recipe list for Soup, the "Next Order" button will appear
            if(Chop.tomatoComplete && TimerScript.cookSoupComplete && TimerScript.cookPastaComplete && RecipeManager.combineSoupComplete)
            {
                Order_Complete.gameObject.SetActive(true);
            }
        }
        else if(currentRecipe.Equals("Burger"))
        {
            if(Chop.lettuceComplete)
            {
                Chop_Lettuce.interactable = false;
            }
            if(Chop.tomatoComplete)
            {
                Chop_Tomato.interactable = false;
            }
            if(TimerScript.cookBurgerComplete)
            {
                Cook_Burger.interactable = false;
            }
            if(Chop.lettuceComplete && Chop.tomatoComplete && TimerScript.cookBurgerComplete)
            {
                Combine_Burger.interactable = true;
            }
            if(RecipeManager.combineBurgerComplete)
            {
                Combine_Burger.gameObject.SetActive(false);
            }
            // if the user finishes preparing all the ingredients in the recipe list for Burger, the "Next Order" button will appear
            if(Chop.lettuceComplete && Chop.tomatoComplete && TimerScript.cookBurgerComplete && RecipeManager.combineBurgerComplete)
            {
                Order_Complete.gameObject.SetActive(true);
            }
        }
        else if(currentRecipe.Equals("Steak"))
        {
            if(TimerScript.cookSteakComplete)
            {
                Cook_Steak.interactable = false;
                Combine_Steak.interactable = true;
            }
            if(RecipeManager.combineSteakComplete)
            {
                Combine_Steak.gameObject.SetActive(false);
            }
            // if the user finishes preparing all the ingredients in the recipe list for Steak, the "Next Order" button will appear
            if(TimerScript.cookSteakComplete && RecipeManager.combineSteakComplete)
            {
                Order_Complete.gameObject.SetActive(true);
            }
        }

        // calls a corresponding function when the user clicks a button on the recipe list
        Chop_Lettuce.onClick.AddListener(ChopLettuceClicked);
        Chop_Tomato.onClick.AddListener(ChopTomatoClicked);
        Cook_Soup.onClick.AddListener(CookSoupClicked);
        Cook_Pasta.onClick.AddListener(CookPastaClicked);
        Cook_Burger.onClick.AddListener(CookBurgerClicked);
        Cook_Steak.onClick.AddListener(CookSteakClicked);
        Combine_Salad.onClick.AddListener(CombineSaladClicked);
        Combine_Soup.onClick.AddListener(CombineSoupClicked);
        Combine_Burger.onClick.AddListener(CombineBurgerClicked);
        Combine_Steak.onClick.AddListener(CombineSteakClicked);

        Order_Complete.onClick.AddListener(LoadNextOrder);
    }

    // when the player clicks a button to perform a cooking functionality, it will load the corresponding scene
    void ChopLettuceClicked()
    {
        SceneManager.LoadScene("Chop_Lettuce");
    }

    void ChopTomatoClicked()
    {
        SceneManager.LoadScene("Chop_Tomato");
    }

    void CookSoupClicked()
    {
        SceneManager.LoadScene("Cook_Soup");
    }

    void CookPastaClicked()
    {
        SceneManager.LoadScene("Cook_Pasta");
    }

    void CookBurgerClicked()
    {
        SceneManager.LoadScene("Cook_Burger");
    }

    void CookSteakClicked()
    {
        SceneManager.LoadScene("Cook_Steak");
    }

    void CombineSaladClicked()
    {
        SceneManager.LoadScene("Combine_Ingredients_Salad");
    }

    void CombineSoupClicked()
    {
        SceneManager.LoadScene("Combine_Ingredients_Soup");
    }

    void CombineBurgerClicked()
    {
        SceneManager.LoadScene("Combine_Ingredients_Burger");
    }

    void CombineSteakClicked()
    {
        SceneManager.LoadScene("Combine_Ingredients_Steak");
    }

    void LoadNextOrder()
    {
        // resetting all static variables
        Chop.lettuceComplete = Chop.tomatoComplete = TimerScript.cookSoupComplete = TimerScript.cookPastaComplete = TimerScript.cookBurgerComplete = TimerScript.cookSteakComplete = RecipeManager.combineSaladComplete = RecipeManager.combineSoupComplete = RecipeManager.combineBurgerComplete = RecipeManager.combineSteakComplete = false;
        GameManager.needNewOrder = true;
        if(currentRecipe.Equals("Salad"))
        {
            GameManager.saladsComplete++;
        }
        else if(currentRecipe.Equals("Soup"))
        {
            GameManager.soupsComplete++;
        }
        else if(currentRecipe.Equals("Burger"))
        {
            GameManager.burgersComplete++;
        }
        else if(currentRecipe.Equals("Steak"))
        {
            GameManager.steaksComplete++;
        }

        // temporary until game timer is made
        // makes every level end after 2 orders are completed
        Debug.Log(GameManager.ordersComplete);
        if(GameManager.ordersComplete == 2)
        {
            if(GoToLevels.currentLevel == "LevelOne")
                GoToLevels.levelOneComplete = true;
            else if(GoToLevels.currentLevel == "LevelTwo")
                GoToLevels.levelTwoComplete = true;
            else if(GoToLevels.currentLevel == "LevelThree")
                GoToLevels.levelThreeComplete = true;
            SceneManager.LoadScene("LevelLoader");
        }
        else
            SceneManager.LoadScene("Recipe_Scene");
    }

}
