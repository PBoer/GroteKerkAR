using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestCubeScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnBeginDrag(PointerEventData eventData)
    {
        var newCube = Instantiate(gameObject);
        newCube.transform.parent = gameObject.transform.parent;
        newCube.transform.position = gameObject.transform.position;
        newCube.transform.rotation = gameObject.transform.rotation;
    }

    public void OnEndDrag(PointerEventData eventdata)
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        Vector3 cameraPos = Camera.allCameras[0].transform.position;
        Vector3 rayDir = (transform.position - cameraPos);
        Debug.Log("Camera: " + cameraPos + " , ray dir: " + rayDir);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(cameraPos, transform.TransformDirection(rayDir), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(cameraPos, transform.TransformDirection(rayDir) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(cameraPos, transform.TransformDirection(rayDir) * 1000, Color.white);
            Debug.Log("Did not Hit");
            Destroy(gameObject);
        }
    }
}
