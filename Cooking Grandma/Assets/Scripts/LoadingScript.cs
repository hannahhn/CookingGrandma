using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    public Image LevelOneScreen, LevelTwoScreen, LevelThreeScreen, LevelFourScreen;
    Image loadingBar;
    float currentLoad;
    float fullLoad = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        loadingBar = GetComponent<Image>();
        if(GoToLevels.currentLevel.Equals("LevelOne"))
            LevelOneScreen.gameObject.SetActive(true);
        else if(GoToLevels.currentLevel.Equals("LevelTwo"))
            LevelTwoScreen.gameObject.SetActive(true);
        else if(GoToLevels.currentLevel.Equals("LevelThree"))
            LevelThreeScreen.gameObject.SetActive(true);
        else if(GoToLevels.currentLevel.Equals("LevelFour"))
            LevelFourScreen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLoad < fullLoad)
        {
            currentLoad += Time.deltaTime;
            loadingBar.fillAmount = currentLoad / fullLoad;
        }
        else
        {
            SceneManager.LoadScene("Recipe_Scene");
        }
    }
}
