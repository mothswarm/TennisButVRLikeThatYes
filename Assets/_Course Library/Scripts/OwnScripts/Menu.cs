using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   // [SerializeField] List<string> _levels = new List<string>();

    public void LoadScene(int scene)
    {
        SceneManager.LoadSceneAsync(scene);

    }
    //public void LoadScene2()
    //{

    
    //}
    //public void LoadScene3()
    //{


    //}
}
