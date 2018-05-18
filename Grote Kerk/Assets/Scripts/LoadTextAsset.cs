using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextAsset : MonoBehaviour {
    public TextAsset asset;
    
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().text = asset.text;
	}


}
