using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCanvas : MonoBehaviour {

    void Start()
    {
        Time.timeScale = 0;
    }

    void OnDestroy()
    {
        Time.timeScale = 1;        
    }

    public void Restart()
    {
        SceneManager.LoadScene("main");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("startupscene");
    }
}
