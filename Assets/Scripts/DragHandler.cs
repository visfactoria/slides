using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler{
	public static GameObject itemBeingDragged;
	RectTransform dragRect;
	Vector3 startPosition;
	Vector3 mouseStartPosition;
	Transform startParentRect;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		dragRect = gameObject.GetComponent<RectTransform> ();
		startPosition = dragRect.anchoredPosition3D;
		startParentRect = dragRect.parent;
		mouseStartPosition = Input.mousePosition;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		print ("mouse: " + Input.mousePosition);
		print ("GO: " + dragRect.anchoredPosition3D);
		print ("GO start: " + startPosition);
		dragRect.anchoredPosition3D = (Input.mousePosition-mouseStartPosition+startPosition);

	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
		if(dragRect.parent == startParentRect)
			dragRect.anchoredPosition3D = startPosition;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

	#endregion



}
