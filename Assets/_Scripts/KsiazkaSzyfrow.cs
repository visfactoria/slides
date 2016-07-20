using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class KsiazkaSzyfrow : MonoBehaviour {
	public Transform targetList;
	public Text hiddenMessage;
	public string answer;
	public GameObject answerFrame;
	public Color beige;
	public Color dGray;
	public Color burgundy;

	public void checkAnswer(){
		System.Text.StringBuilder builder = new System.Text.StringBuilder ();

		foreach (Transform slotTransform in targetList) {
			GameObject item = slotTransform.GetComponent<SlotDropHandler>().item;
			if(item){
				builder.Append (item.name[0]);

				builder.Append (item.name[1]);

				builder.Append (item.name[2]);

				builder.Append (item.name[3]);

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

		print (builder.ToString ());
	}
}
