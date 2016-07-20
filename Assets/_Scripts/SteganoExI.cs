using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SteganoExI : MonoBehaviour,IChanged {
	public Transform targetList;
	public Text hiddenMessage;
	string answer = "alarm";
	public GameObject answerFrame;
	public Color beige;
	public Color dGray;
	public Color burgundy;

	void Start(){
		//HasChanged ();

		//define colors

	}

	#region IChanged implementation

	public void HasChanged ()
	{
		System.Text.StringBuilder builder = new System.Text.StringBuilder ();

		foreach (Transform slotTransform in targetList) {
			GameObject item = slotTransform.GetComponent<SlotDropHandler>().item;
			if(item){
				builder.Append (item.name [2]);

			}
		}
		if(builder.ToString().Equals(answer)){
			hiddenMessage.text = "Sukces!!!";
		}
	}

	#endregion

	public void checkAnswer(){
		System.Text.StringBuilder builder = new System.Text.StringBuilder ();

		foreach (Transform slotTransform in targetList) {
			GameObject item = slotTransform.GetComponent<SlotDropHandler>().item;
			if(item){
				builder.Append (item.name [2]);

			}
		}
		if(builder.ToString().Equals(answer)){
			hiddenMessage.text = "Sukces!!!";
			hiddenMessage.color = dGray;
			answerFrame.GetComponent<Image> ().color = beige;
		}else {
			hiddenMessage.text = "Źle. Próbuj Dalej.";
			hiddenMessage.color = beige;
			answerFrame.GetComponent<Image> ().color = burgundy;
		}
	}

}

namespace UnityEngine.EventSystems{
	public interface IChanged : IEventSystemHandler{
		void HasChanged();
	}
}
