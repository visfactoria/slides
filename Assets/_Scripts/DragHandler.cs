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
		dragRect.anchoredPosition3D =(Input.mousePosition-mouseStartPosition+startPosition);

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

	/*public Vector3 GetStartPosition(){
		return startPosition;
	}

	public Transform GetStartParent(){
		return startParentRect;
	}

	public void SetAnchorPosition(Vector3 newPosition){
		dragRect = gameObject.GetComponent<RectTransform> ();
		dragRect.anchoredPosition3D = newPosition;
	}*/



	public static void cloneDragged(){
		if (itemBeingDragged) {
			GameObject clone = Instantiate (itemBeingDragged);

			clone.GetComponent<RectTransform> ().SetParent (DragHandler.itemBeingDragged.GetComponent<RectTransform> ().parent);
			clone.GetComponent<RectTransform> ().anchoredPosition3D = DragHandler.itemBeingDragged.GetComponent<DragHandler>().startPosition;
			clone.GetComponent<RectTransform> ().localScale.Set (1.0f, 1.0f, 1.0f);
			clone.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
	}




}
