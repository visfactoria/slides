using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlfabetSzyfrowyExI : MonoBehaviour {

	public Transform targetList;
	public Text message;
	public string rightAnswer = "POSNAIBCDEFGHJKLMQRTUVWXYZ";

	public void CheckAnswer(){
		System.Text.StringBuilder builder = new System.Text.StringBuilder ();

		foreach (Transform slotTransform in targetList) {
			GameObject item = slotTransform.GetComponent<SlotDropHandler>().item;
			if(item){
				builder.Append (item.name [0]);

			}
		}

		int count = builder.ToString ().Split ('A').Length - 1;


		if (builder.ToString ().Equals (rightAnswer)) {
			message.text = "Sukces!!!";
		} else {

			if(count>=2){
				message.text = "Litery się powtarzają.";
			}else{
				message.text = "Źle. Próbuj Dalej.";
			}
		}
	}
}
