using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public Button Chop_Lettuce, Chop_Tomato, Combine_Salad, Combine_Burger, Cook_Burger;
    string[] recipes = {"Salad", "Soup", "Burger", "Steak"};

    // Start is called before the first frame update
    void Start()
    {
        Chop_Lettuce.onClick.AddListener(ChopLettuceClicked);
        Chop_Tomato.onClick.AddListener(ChopTomatoClicked);
        Cook_Burger.onClick.AddListener(CookBurgerClicked);
        Combine_Salad.onClick.AddListener(CombineSaladClicked);
        Combine_Burger.onClick.AddListener(CombineBurgerClicked);
    }

    void ChopLettuceClicked()
    {
        SceneManager.LoadScene("Chop_Lettuce");
    }

    void ChopTomatoClicked()
    {
        SceneManager.LoadScene("Chop_Tomato");
    }

    void CookBurgerClicked()
    {
        SceneManager.LoadScene("Cook_Burger");
    }

    void CombineSaladClicked()
    {
        SceneManager.LoadScene("Combine_Ingredients_Salad");
    }

    void CombineBurgerClicked()
    {
        SceneManager.LoadScene("Combine_Ingredients_Burger");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
