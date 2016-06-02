using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CezarExI : MonoBehaviour {
	public Transform targetList;
	public Text message;
	public string rightAnswer = "";

	public void CheckAnswer(){
		System.Text.StringBuilder builder = new System.Text.StringBuilder ();

		foreach (Transform slotTransform in targetList) {
			GameObject item = slotTransform.GetComponent<SlotDropHandler>().item;
			if(item){
				builder.Append (item.name [0]);

			}
		}
		if (builder.ToString ().Equals (rightAnswer)) {
			message.text = "Sukces!!!";
		} else {
			message.text = "Źle. Próbuj Dalej.";
		}
	}
}
