using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Isekai : MonoBehaviour
{
    public int SceneToIsekaiTo;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            LoadScene(SceneToIsekaiTo);
        }
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadSceneAsync(scene);

    }
}
