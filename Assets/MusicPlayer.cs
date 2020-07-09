using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        LoadFirstLevel();
    }

    void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

}
