using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

    // Define a static Gamecontroller
    public static GameController control;

    void Awake()
    {
        // Set control to this object
        control = this;
    }
	// Use this for initialization
	void Start () {
        // Load Level01
        StartCoroutine(LoadLevel("Level01"));
	}
	
    // Load a Scene, pass scene name
    public IEnumerator LoadLevel(string sceneName)
    {
        // Wait until the end of the current frame
        yield return new WaitForEndOfFrame();
        // Load the scene Asynchronously
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        // Unload previous scenes
        StartCoroutine(UnloadLevels(sceneName));

    }

    // Unload all levels except "exception" and the VRMain Scene
    public IEnumerator UnloadLevels(string exception)
    {
        // Wait until the end of current frame
        yield return new WaitForEndOfFrame();
        // For each scene that is currently loaded
        for(int i=0; i<SceneManager.sceneCount; i++)
        {
            // Check this scene to make sure it's NOT 'exception' NOR VRMain scene
            if(SceneManager.GetSceneAt(i).name != exception && SceneManager.GetSceneAt(i).name != "VRMain")
            {
                // It's not the newly loaded scene, nor VRMain; Unload this scene
                SceneManager.UnloadScene(SceneManager.GetSceneAt(i).name);
            }
        }
    }
	
}
