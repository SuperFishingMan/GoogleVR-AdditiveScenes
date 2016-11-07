using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {
    
    public void LoadLevel(string sceneToLoad)
    {
        StartCoroutine(GameController.control.LoadLevel(sceneToLoad));
    }
}
