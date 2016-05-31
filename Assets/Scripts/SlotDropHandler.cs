using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SlotDropHandler : MonoBehaviour, IDropHandler {
	public GameObject item{
		get{
			if(transform.childCount>0){
				return transform.GetChild (0).gameObject;
			}else{
				return null;
			}
		}
	}

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		if(!item){
			DragHandler.itemBeingDragged.transform.SetParent (transform);
		}
	}
	#endregion
}
