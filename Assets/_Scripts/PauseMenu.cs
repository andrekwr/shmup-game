using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    public Loader LoadLevel;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if (GamePaused) {
                Resume();
            } else {
                Pause();
            }
            
        }
        
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
         Time.timeScale = 1;
         GamePaused = false;

    }
     void Pause() {
         pauseMenuUI.SetActive(true);
         Time.timeScale = 0;
         GamePaused = true;
        
    }

    public void Exit(){
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        //LoadLevel.LoadExit();
        SceneManager.LoadScene("StartMenu");
        GamePaused = false;
    }
}
