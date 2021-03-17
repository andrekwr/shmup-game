using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = .2f;

    public void LoadNextLevel() 
    {
        if(SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));  
        }
        else
        {
           StartCoroutine(LoadLevel(1));  
        }
    } 

    public void ReloadLevel() => StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex ));

    public void LoadExit() => StartCoroutine(LoadLevel(1));

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
