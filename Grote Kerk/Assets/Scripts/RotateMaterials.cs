using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMaterials : MonoBehaviour {

    private GameObject[] materials;

    void Update()
    {
    }

    /// <summary>
    /// Function to rotate objects tagged "Material"
    /// </summary>
    public void Rotate()
    {
        // Find all objects with tag "Material" and put them in the list materials
        materials = GameObject.FindGameObjectsWithTag("Material");

        // Rotate each object in the list by 45 degrees
        foreach(GameObject material in materials)
        {
            material.transform.Rotate(Vector3.up * 45);
        }
    }
}