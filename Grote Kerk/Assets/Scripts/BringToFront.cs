﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BringToFront : MonoBehaviour {

    public void OnEnable()
    {
        // Set object as last sibling so it's in front of all other siblings
        transform.SetAsLastSibling();
    }
}
