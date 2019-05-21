using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    SpriteRenderer spriteRenderer;
   	PieceModel pieceModel;
    
    void Awake ()
    {
        pieceModel = GetComponent<PieceModel>();
    }
    
    
    public void OnBeginDrag (PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag (PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        pieceModel.transform.position = eventData.position;
    }

    public void OnEndDrag (PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }
}
