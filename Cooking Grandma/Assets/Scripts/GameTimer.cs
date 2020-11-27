using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// this script handles the overall game timer
public class GameTimer : MonoBehaviour
{
  public static float timeLeft;
  public static bool timeUp = false;
  public Text timeLeftText;
  public GameObject timesUpText;

  void Update()
  {
      updateTimer();
      if(timeUp)
      {
          StartCoroutine(TimesUp());
      }
  }

  public void updateTimer()
  {
      if(timeLeft > 1)
      {
          timeLeft -= Time.deltaTime;
          timeLeftText.text = Mathf.FloorToInt(timeLeft) + "s";
      }
      else
      {
          timeUp = true;
      }
  }

  IEnumerator TimesUp()
  {
      timesUpText.SetActive(true);
      yield return new WaitForSeconds(3);
      timesUpText.SetActive(false);
      SceneManager.LoadScene("Score_Scene");
  }

}
