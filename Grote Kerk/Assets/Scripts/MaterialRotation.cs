using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RotateLeft()
    {
        RotateChildren(Vector3.down);
    }

    public void RotateRight()
    {
        RotateChildren(Vector3.up);
    }

    public void RotateUp()
    {
        RotateChildren(Vector3.right);
    }

    public void RotateDown()
    {
        RotateChildren(Vector3.left);
    }

    public void RotateChildren(Vector3 direction)
    {
        foreach (Transform child in transform)
        {
            if(child.tag == "Material")
            {
                child.transform.Rotate(direction, 90, Space.Self);
            }
        }
    }
}
