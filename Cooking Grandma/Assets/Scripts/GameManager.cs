using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Salad_Recipe, Soup_Recipe, Burger_Recipe, Steak_Recipe;
    string[] recipes = {"Salad", "Soup", "Burger", "Steak"};
    string currentLevel;
    static string currentOrder;
    public static bool needNewOrder = true;
    public static int ordersComplete, saladsComplete, soupsComplete, burgersComplete, steaksComplete = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = GoToLevels.currentLevel;
        if(needNewOrder)
        {
            if(currentLevel.Equals("LevelOne"))
            {
                currentOrder = recipes[Random.Range(0,1)]; // only salads in this level
            }
            else if(currentLevel.Equals("LevelTwo"))
            {
                if(ordersComplete == 0)
                    currentOrder = "Soup"; // so that the first order in each level is the new recipe introduced
                else
                    currentOrder = recipes[Random.Range(0,2)]; // randomizes between salad and soup in this level
            }
            else if(currentLevel.Equals("LevelThree"))
            {
                if(ordersComplete == 0)
                    currentOrder = "Burger"; // so that the first order in each level is the new recipe introduced
                else
                    currentOrder = recipes[Random.Range(0,3)]; // randomizes between salad, soup, and burger in this level
            }
            else if(currentLevel.Equals("LevelFour"))
            {
                if(ordersComplete == 0)
                    currentOrder = "Steak"; // so that the first order in each level is the new recipe introduced
                else
                    currentOrder = recipes[Random.Range(0,4)]; // randomizes between salad, soup, burger, and steak in this level
            }

            needNewOrder = false;
            ordersComplete++;
        }

        if(currentOrder.Equals("Salad"))
        {
            Salad_Recipe.SetActive(true);
        }
        else if(currentOrder.Equals("Soup"))
        {
            Soup_Recipe.SetActive(true);
        }
        else if(currentOrder.Equals("Burger"))
        {
            Burger_Recipe.SetActive(true);
        }
        else if(currentOrder.Equals("Steak"))
        {
            Steak_Recipe.SetActive(true);
        }
    }
}
