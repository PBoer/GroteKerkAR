using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectPlacement : MonoBehaviour, IBeginDragHandler, IEndDragHandler {

    private string scene;
    private Collider myCollider;

	// Use this for initialization
	void Start () {
        myCollider = GetComponent<Collider>();
        scene = GameManager.Instance.GetCurrentScene();
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
        newCube.transform.localScale = gameObject.transform.localScale;
        newCube.name = transform.name;
    }

    /*
     * When user drops the object, raycast.
     * If it hits a target, the object is dropped in the target location and its collider is disabled,
     * else the object is destroyed
     */
    public void OnEndDrag(PointerEventData eventdata)
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Check if raycast hits anything, if not, destroy this object
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log(Quaternion.Angle(transform.rotation, hit.transform.rotation));

            // Check name of the object that was hit
            // If name is the same, replace the object that was hit with this one
            // Otherwise, destroy this object
            if(hit.transform.name == gameObject.name)
            {
                // If object is an arch, the rotation also needs to be similar,
                // Check difference between the two objects' rotations, if they are close enough, replace the hit object,
                // otherwise destroy this object
                if (gameObject.name == "Arch")
                {
                    if (Quaternion.Angle(transform.rotation, hit.transform.rotation) <= 75)
                    {
                        PlaceObject(hit);
                    } else
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    PlaceObject(hit);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Function to replace a hit object with the dragged object,
    /// using RaycastHit that was passed along in the function call
    /// </summary>
    /// <param name="hit"></param>
    private void PlaceObject(RaycastHit hit)
    {
        // Replace target with this object and disable collider so it can't be manipulated anymore
        myCollider.enabled = false;
        transform.parent = hit.transform.parent;
        transform.localScale = hit.transform.localScale;
        Destroy(hit.transform.gameObject);
        transform.position = hit.transform.position;
        transform.rotation = hit.transform.rotation;

        // Remove tag so the object can't be rotated anymore
        transform.tag = "Untagged";
        gameObject.GetComponent<DragNDrop>().enabled = false;

        // Tell this scene's progress script a block/part has been placed
        switch (scene)
        {
            case "MasterMason":
                GameObject.Find("Progress").GetComponent<MasterMasonProgress>().PlacedBlock();
                break;

            case "Carpenter":
                GameObject.Find("Progress").GetComponent<CarpenterProgress>().PlacedPart();
                break;
        }
    }
}
