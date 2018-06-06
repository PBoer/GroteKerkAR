using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour {

    //private bool hasGrabbedPoint = false;
    //private Vector3 grabbedPoint;
    private GameObject[] materials;

    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    RaycastHit hit;
        //    if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {

        //        if (hit.transform.name == "Sphere")
        //        {
        //            if (!hasGrabbedPoint)
        //            {
        //                hasGrabbedPoint = true;
        //                grabbedPoint = getTouchedPoint();
        //                materials = GameObject.FindGameObjectsWithTag("Material");
        //            }
        //            else
        //            {
        //                Vector3 targetPoint = getTouchedPoint();
        //                Quaternion rot = Quaternion.FromToRotation(grabbedPoint, targetPoint);
        //                transform.localRotation *= rot;
        //                foreach (GameObject material in materials)
        //                {
        //                    material.transform.localRotation *= rot;
        //                }
        //            }
        //        }
        //    }
        //}
        //else hasGrabbedPoint = false;
    }


    //Vector3 getTouchedPoint()
    //{
    //    RaycastHit hit;
    //    Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);


    //    return transform.InverseTransformPoint(hit.point);

    //}

    public void FlipArch()
    {
        materials = GameObject.FindGameObjectsWithTag("Material");
        foreach(GameObject material in materials)
        {
            material.transform.Rotate(Vector3.up * 45);
        }
    }
}