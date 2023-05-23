using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GoBetweenScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SceneManager.LoadSceneAsync(0);
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SceneManager.LoadSceneAsync(1);
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            SceneManager.LoadSceneAsync(2);
        }
        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            SceneManager.LoadSceneAsync(3);
        }
        if (Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            SceneManager.LoadSceneAsync(4);
        }
    }
}
