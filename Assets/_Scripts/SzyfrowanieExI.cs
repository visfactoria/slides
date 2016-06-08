using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SzyfrowanieExI : MonoBehaviour {

	public Transform codedList;
	public Transform unCodedList;
	public Text message;
	public string codeAlphabet = "POSNAIBCDEFGHJKLMQRTUVWXYZ";


	public void CheckAnswer(){
		System.Text.StringBuilder builderCoded = new System.Text.StringBuilder ();
		System.Text.StringBuilder builderUnCoded = new System.Text.StringBuilder ();

		foreach (Transform slotTransform in codedList) {
			GameObject item = slotTransform.GetComponent<SlotDropHandler>().item;
			if(item){
				builderCoded.Append (item.name [0]);

			}
		}

		foreach (Transform slotTransform in unCodedList) {
			GameObject item = slotTransform.GetComponent<SlotDropHandler>().item;
			if(item){
				builderUnCoded.Append (item.name [0]);

			}
		}

	
		if (builderCoded.ToString ().Equals (Code(builderUnCoded.ToString()))) {
			message.text = "Sukces!!!";
		} else {
			message.text = "Źle. Próbuj Dalej.";
		}
	}

	private string Code(string unCodedMessage){
		System.Text.StringBuilder codeBuilder = new System.Text.StringBuilder ();
		foreach (char unCodedCharacter in unCodedMessage) {
			codeBuilder.Append(codeAlphabet[unCodedCharacter-65]);
		}
		return codeBuilder.ToString ();
	}
}
