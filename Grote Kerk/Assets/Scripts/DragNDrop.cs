using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    int initialPointerId;
    private Vector3 screenPoint;
    private Vector3 offset;

    void Start()
    {
        initialPointerId = int.MaxValue;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (initialPointerId == int.MaxValue)
        {
            initialPointerId = eventData.pointerId;

            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (initialPointerId == eventData.pointerId)
        {
            initialPointerId = int.MaxValue;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (initialPointerId == eventData.pointerId)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            transform.position = curPosition;
        }
    }
}