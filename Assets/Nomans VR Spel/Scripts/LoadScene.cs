using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName; // The name of the scene you want to load
    public float delayTime = 1.0f; // Delay time in seconds before loading the new scene
    [SerializeField] private Material triggeredMaterial;

    private Material defaultMaterial;
    private Renderer renderer;

    private bool triggerEntered = false; // Flag to check if the trigger has been entered
    private float timer = 2.0f;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultMaterial = renderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fireball")) // Assuming your player has the tag "Player"
        {
            triggerEntered = true;
            renderer.material = triggeredMaterial;

        }
    }

    void Update()
    {
        if (triggerEntered)
        {
            // If the trigger has been entered
            timer += Time.deltaTime; // Start the delay timer

            if (timer >= delayTime)
            {
                // If the delay time has passed
                SceneManager.LoadScene(sceneName); // Load the new scene
            }
        }
    }
}