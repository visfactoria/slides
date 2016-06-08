using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SlotDropHandler : MonoBehaviour, IDropHandler {
	public bool isTrashCan = false;
	public bool respawns = false;
	public bool switcher = false;

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
		if (!item) {
			if (DragHandler.itemBeingDragged.transform.parent.GetComponent<SlotDropHandler> ().CheckRespawn ()) {
				DragHandler.cloneDragged ();
				DragHandler.itemBeingDragged.transform.SetParent (transform);

			} else {
				DragHandler.itemBeingDragged.transform.SetParent (transform);
			}
		} else {
			if (switcher) {
				item.transform.SetParent (DragHandler.itemBeingDragged.transform.parent);
				DragHandler.itemBeingDragged.transform.SetParent (transform);
			}
		}


		if (isTrashCan) {
			Destroy (DragHandler.itemBeingDragged);
		}
	}
	#endregion

	public bool CheckRespawn(){
		return respawns;
	}


}
