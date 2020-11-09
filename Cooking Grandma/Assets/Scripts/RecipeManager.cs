using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecipeManager : MonoBehaviour
{
    public GameObject completedDish;
    public Button checkmark;
    int ingredientCount = 0;

    void Start ()
    {
       checkmark.onClick.AddListener(checkmarkClicked);
    }

    public void IngredientAdded()
    {
      ingredientCount++;

      if(completedDish.CompareTag("Salad") && ingredientCount >= 2)
      {
        DishComplete();
      }
      else if(completedDish.CompareTag("Soup") && ingredientCount >= 1)
      {
        DishComplete();
      }
      else if(completedDish.CompareTag("Hamburger") && ingredientCount >= 5)
      {
        DishComplete();
      }
      else if(completedDish.CompareTag("Steak") && ingredientCount >= 1)
      {
        DishComplete();
      }
    }

    void DishComplete()
    {
      completedDish.SetActive(true);
      checkmark.gameObject.SetActive(true);
    }

    void checkmarkClicked()
    {
      SceneManager.LoadScene("Recipe_Scene");
    }
}
