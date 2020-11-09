using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 10.0f;
    public GameObject CompleteIngredient;
    public Button checkmark;
    float currentTime;
    bool playerClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        currentTime = 0;
        checkmark.onClick.AddListener(checkmarkClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if((currentTime / maxTime) > 0.574)
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

    void checkmarkClicked()
    {
      SceneManager.LoadScene("Recipe_Scene");
    }
}
