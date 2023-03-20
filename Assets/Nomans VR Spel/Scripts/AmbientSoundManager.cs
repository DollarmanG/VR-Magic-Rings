using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbientSoundManager : MonoBehaviour
{
    private static AmbientSoundManager instance = null;

    private string currentScene;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != currentScene)
        {
            if (SceneManager.GetActiveScene().name == "Tutorial Scene")
            {
                GetComponent<AudioSource>().Pause();
            }
            else
            {
                GetComponent<AudioSource>().UnPause();
            }
            currentScene = SceneManager.GetActiveScene().name;
        }
    }
}