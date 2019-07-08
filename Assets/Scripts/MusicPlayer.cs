using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadFirstScene",3f);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {

    }
    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
