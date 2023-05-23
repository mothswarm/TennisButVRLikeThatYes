using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextScene : MonoBehaviour
{
    float timeBeforeNextScene = 0f;

    // Update is called once per frame
    void Update()
    {
        // Increment timeBeforeNextScene in every frame
        timeBeforeNextScene += Time.deltaTime;

        if (timeBeforeNextScene > 3)
        {
            SceneManager.LoadSceneAsync(1);
        }
    }
}
