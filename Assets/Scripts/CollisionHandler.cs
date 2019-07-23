using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      //ok as long as this is the only script that loads scenes...
                                        //yk encapsulation

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX Prefab on Player")][SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }
    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }

    private void ReloadScene()  //string referenced
    {
        SceneManager.LoadScene(1);
    }
}
