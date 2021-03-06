﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chop : MonoBehaviour
{
  public Sprite Full_Ingredient, Slice1, Slice2, Slice3, Slice4, Slice5;
  SpriteRenderer currentSprite;
  public Button checkmark, Ingredient_Button;
  public static bool lettuceComplete, tomatoComplete = false;

  void Start ()
  {
       currentSprite = gameObject.GetComponent<SpriteRenderer>();
       checkmark.onClick.AddListener(checkmarkClicked);
       Ingredient_Button.onClick.AddListener(Click_Ingredient);
  }

  public void Click_Ingredient()
  {
      if(currentSprite.sprite.Equals(Full_Ingredient))
      {
          SoundManager.PlaySound("chop");
          currentSprite.sprite = Slice1;
      }
      else if(currentSprite.sprite.Equals(Slice1))
      {
          SoundManager.PlaySound("chop");
          currentSprite.sprite = Slice2;
      }
      else if(currentSprite.sprite.Equals(Slice2))
      {
          SoundManager.PlaySound("chop");
          currentSprite.sprite = Slice3;
      }
      else if(currentSprite.sprite.Equals(Slice3))
      {
          SoundManager.PlaySound("chop");
          currentSprite.sprite = Slice4;
      }
      else if(currentSprite.sprite.Equals(Slice4))
      {
          SoundManager.PlaySound("chop");
          currentSprite.sprite = Slice5;
          checkmark.gameObject.SetActive(true);
          if(Full_Ingredient.name.Equals("Lettuce"))
          {
              lettuceComplete = true;
          }
          else if(Full_Ingredient.name.Equals("Tomato"))
          {
              tomatoComplete = true;
          }
      }
  }

  void checkmarkClicked()
  {
      SceneManager.LoadScene("Recipe_Scene");
  }

}
