using UnityEngine;

public class DDOL : MonoBehaviour {

    //Simple DontDestroyOnLoad script for any game objects in the preload scene
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
