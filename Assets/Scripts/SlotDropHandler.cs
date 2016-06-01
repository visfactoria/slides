using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SlotDropHandler : MonoBehaviour, IDropHandler {
	public bool isTrashCan = false;
	public bool respawns = false;

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
			if (respawns) {
				print ("creating clone");
				//GameObject clone =  Instantiate (DragHandler.itemBeingDragged);
				//clone.transform.SetParent (DragHandler.itemBeingDragged.GetComponent<RectTransform>().parent);
				//clone.GetComponent<RectTransform>().anchoredPosition3D = DragHandler.itemBeingDragged.GetComponent<RectTransform>()
				//DragHandler.itemBeingDragged.GetComponent<DragHandler>().
				DragHandler.cloneDragged();
				DragHandler.itemBeingDragged.transform.SetParent (transform);

			} else {
				DragHandler.itemBeingDragged.transform.SetParent (transform);
			}
			//ExecuteEvents.ExecuteHierarchy<IChanged> (gameObject, null, (x,y) => x.HasChanged());
		}
		if (isTrashCan) {
			Destroy (DragHandler.itemBeingDragged);
		}
	}
	#endregion
}
