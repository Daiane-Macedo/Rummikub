using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Draggable : MonoBehaviour
{
    public const string DRAGGABLE_TAG = "UIDraggable";
    private bool dragging = false;
    private Vector3 originalPosition;
    private Transform objectToDrag;
    private Image objectToDragImage;
    
    List<RaycastResult> hitObjects = new List<RaycastResult>();
    
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            objectToDrag = GetDraggableTransformUnderMouse();

            if(objectToDrag != null)
            {
                dragging = true;

                objectToDrag.SetAsLastSibling();

                originalPosition = objectToDrag.position;
                objectToDragImage = objectToDrag.GetComponent<Image>();
                objectToDragImage.raycastTarget = false;
            }
        }

        if (dragging)
        {
            objectToDrag.position = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0))
        {

        }

    }

    private GameObject GetObjectUnderMouse()
    {
        var pointer = new PointerEventData(EventSystem.current);

        pointer.position = Input.mousePosition;
        EventSystem.current.RaycastAll(pointer, hitObjects);
        if (hitObjects.Count <= 0) return null;
        return hitObjects[0].gameObject;
    }
    private Transform GetDraggableTransformUnderMouse ()
    {
        GameObject clickedObject = GetObjectUnderMouse();

        if (clickedObject != null && clickedObject.tag == DRAGGABLE_TAG)
        {
            return clickedObject.transform;
        }
        return null;
    }



}
