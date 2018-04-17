using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BringToFront : MonoBehaviour {

    public void OnEnable()
    {
        transform.SetAsLastSibling();
    }
}
