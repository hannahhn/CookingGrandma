using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chop : MonoBehaviour
{
  public Sprite Full_Ingredient, Slice1, Slice2, Slice3, Slice4, Slice5;
  SpriteRenderer currentSprite;
  public Button checkmark;

  void Start ()
  {
     currentSprite = gameObject.GetComponent<SpriteRenderer> ();
     checkmark.onClick.AddListener(checkmarkClicked);
  }

  void Update()
  {
  }

  void OnMouseDown()
  {
    if(currentSprite.sprite.Equals(Full_Ingredient))
      currentSprite.sprite = Slice1;
    else if(currentSprite.sprite.Equals(Slice1))
      currentSprite.sprite = Slice2;
    else if(currentSprite.sprite.Equals(Slice2))
      currentSprite.sprite = Slice3;
    else if(currentSprite.sprite.Equals(Slice3))
      currentSprite.sprite = Slice4;
    else if(currentSprite.sprite.Equals(Slice4))
    {
      currentSprite.sprite = Slice5;
      checkmark.gameObject.SetActive(true);
    }
  }

  void checkmarkClicked()
  {
    SceneManager.LoadScene("Recipe_Scene");
  }
}
