/*
Autor: ChatGPT, Bearbeitet von Klaus Wiegmann
*/

using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropObjects : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public SmoothMove mover;
    private bool beingDragged;
    public bool enabled;
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 initialPosition;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        beingDragged = false;
        enabled = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (enabled){
            beingDragged = true;
            mover.freeze = true;
            initialPosition = rectTransform.anchoredPosition;

            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (enabled){
            beingDragged = true;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out Vector2 localPosition);
            rectTransform.anchoredPosition = localPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (enabled) {
            beingDragged = false;
            mover.freeze = false;
            canvasGroup.blocksRaycasts = true;
            if (!eventData.dragging)
            {
                rectTransform.anchoredPosition = initialPosition;
            }
        }
    }

    public bool isBeingDragged(){
        return beingDragged;
    }
}