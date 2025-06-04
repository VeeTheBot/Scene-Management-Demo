using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneChange : MonoBehaviour
{
    [Tooltip("The name or filepath of the scene to load when the player collides with this object.")]
    [SerializeField] private string sceneName;

    private void Awake()
    {
        Debug.Log("Door awake!", this);
    }

    // Only runs when something enters the trigger zone.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.tag, collider);

        // If the object that entered is tagged as a player...
        if(collider.CompareTag("Player"))
        {
            // ... and there's an assigned scene...
            if(!sceneName.Equals(""))
                // ... load the scene.
                SceneManager.LoadScene(sceneName);
            
            // Otherwise, send an error to the console.
            else
                Debug.LogError("No scene to load was assigned!", this);
        }
    }
}
