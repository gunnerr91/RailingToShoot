using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] GameObject deathFx;

    private void OnTriggerEnter(Collider other)
    {
        BeginDeathSequence();
        deathFx.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    void BeginDeathSequence()
    {
        SendMessage("RemoveControl");
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
