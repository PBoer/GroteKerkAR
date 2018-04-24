﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestCubeScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler {

    private Collider myCollider;
	// Use this for initialization
	void Start () {
        myCollider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // When user starts dragging object, create duplicate in the object's default location
    public void OnBeginDrag(PointerEventData eventData)
    {
        var newCube = Instantiate(gameObject);
        newCube.transform.parent = gameObject.transform.parent;
        newCube.transform.position = gameObject.transform.position;
        newCube.transform.rotation = gameObject.transform.rotation;
        transform.parent = null;
    }

    /*
     * When user drops the object, raycast.
     * If it hits a target, the object is dropped in the target location and its collider is disabled,
     * else the object is destroyed
     */
    public void OnEndDrag(PointerEventData eventdata)
    {
        // Raycaster object is used instead of camera because Vuforia's camera doesn't work well with raycasting
        GameObject myRaycaster = GameObject.Find("Raycaster");

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        // Temporary variables to raycast from the camera's position (through Raycaster object) in the direction of dragged object
        Vector3 cameraPos = myRaycaster.transform.position;
        Vector3 rayDir = (transform.position - cameraPos);
        RaycastHit hit;

        // Check if the raycast hits anything besides the player controlled layer
        if (Physics.Raycast(cameraPos, rayDir, out hit, Mathf.Infinity, layerMask))
        {
            myCollider.enabled = false;
            transform.position = hit.point;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}