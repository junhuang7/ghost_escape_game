using UnityEngine;
using UnityEngine.SceneManagement; // Necessary for using the SceneManager

public class GameStarter : MonoBehaviour
{
    // Name of the scene you want to load
    public string sceneNameToLoad = "demo"; // You can change "SCENE_NAME" to the actual name of your scene.

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
