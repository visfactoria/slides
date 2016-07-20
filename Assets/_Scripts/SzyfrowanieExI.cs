using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SzyfrowanieExI : MonoBehaviour {

	public Transform codedList;
	public Transform unCodedList;
	public Text message;
	public string codeAlphabet = "POSNAIBCDEFGHJKLMQRTUVWXYZ";
	public GameObject answerFrame;
	public Color beige;
	public Color dGray;
	public Color burgundy;
	public string scuccessText;
	public string failText;


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
			message.text = scuccessText;
			message.color = dGray;
			answerFrame.GetComponent<Image> ().color = beige;
		} else {
			message.text = failText;
			message.color = beige;
			answerFrame.GetComponent<Image> ().color = burgundy;
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
