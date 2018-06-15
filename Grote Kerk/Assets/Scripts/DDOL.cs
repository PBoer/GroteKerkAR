using UnityEngine;

public class DDOL : MonoBehaviour {

    //Simple DontDestroyOnLoad script for any game objects in the preload scene that need to persist through other scenes
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
