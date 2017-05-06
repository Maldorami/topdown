using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public static InputManager instance;
    IInput input;

    void Awake()
    {
        if (!instance){
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

#if UNITY_EDITOR
        input = new InputKeyboard();
#elif UNITY_ANDROID
        input = new InputMobile();
#endif

    }

    public IInput getInput()
    {
        return input;
    }

    public Vector3 Movement()
    {
        return input.GetAxis();
    }

    public bool Fire()
    {
        return input.GetFire();
    }

    public Vector3 Look()
    {
        return input.LookAt();
    }
}
