using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SteganoExI : MonoBehaviour,IChanged {
	public Transform targetList;
	public Text hiddenMessage;
	string answer = "ALARM";

	void Start(){
		HasChanged ();
	}

	#region IChanged implementation

	public void HasChanged ()
	{
		System.Text.StringBuilder builder = new System.Text.StringBuilder ();

		foreach (Transform slotTransform in targetList) {
			GameObject item = slotTransform.GetComponent<SlotDropHandler>().item;
			if(item){
				builder.Append (item.name [0]);

			}
		}
		if(builder.ToString().Equals(answer)){
			hiddenMessage.text = "Sukces!!!";
		}
		//hiddenMessage.text = builder.ToString ();

	}

	#endregion



}

namespace UnityEngine.EventSystems{
	public interface IChanged : IEventSystemHandler{
		void HasChanged();
	}
}
