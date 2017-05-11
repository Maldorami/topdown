using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvasController : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadScene("main");
    }

    public void Exit()
    {
        Application.Quit();
    }
}