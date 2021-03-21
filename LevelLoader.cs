using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    
    public Animator transition;
    public float transitionTime = 1f;
    public Button Button;
    public void OnClicked(Button button)
    {
                if(button.name == "PlayButton" || button.name == "HighScoreButton"
                || button.name == "CreditButton" || button.name == "TutorialButton" ){
                    LoadNextLevel();
                }

    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
