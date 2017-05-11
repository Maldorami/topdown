using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterCanvasController : MonoBehaviour {

    public GameObject endCanvas;

    public static MasterCanvasController instance;

    void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void endGame()
    {
        endCanvas = Instantiate(endCanvas);
    }

}
