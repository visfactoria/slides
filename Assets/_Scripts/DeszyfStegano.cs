using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeszyfStegano : MonoBehaviour {

	public Transform targetList;
	public Text successMessage;
	public Text depecheMessage;

	public string easyDT;
	public string easyAnswer;
	public string easyHint;

	public string mediumDT;
	public string mediumAnswer;
	public string mediumHint;

	public string hardDT;
	public string hardAnswer;
	public string hardHint;

	string rightAnswer = "TAJNOPIS";


	public GameObject hintObject;
	private Text hintText;
	public GameObject answerFrame;
	public Color beige;
	public Color dGray;
	public Color burgundy;

	private int difficulty=0;

	public void Start(){
		hintText = hintObject.GetComponent<Text> ();
	}

	public void CheckAnswer(){
		System.Text.StringBuilder builder = new System.Text.StringBuilder ();

		foreach (Transform slotTransform in targetList) {
			GameObject item = slotTransform.GetComponent<SlotDropHandler>().item;
			if(item){
				builder.Append (item.name [0]);

			}
		}
		if (builder.ToString ().Equals (rightAnswer)) {
			if(difficulty==0){
				successMessage.text = "Tajnopis to inne określenie steganografii.";
			}else{
				successMessage.text = "Sukces!!!";
			}
			successMessage.color = dGray;
			answerFrame.GetComponent<Image> ().color = beige;
		} else {
			successMessage.text = "Źle. Próbuj Dalej.";

			successMessage.color = beige;
			answerFrame.GetComponent<Image> ().color = burgundy;
		}
	}

	public void setEasy(){
		hintObject.SetActive (false);
		hintText.text = easyHint;
		depecheMessage.text = easyDT;
		rightAnswer = easyAnswer;
		difficulty = 0;
	}

	public void setMedium(){
		hintObject.SetActive (false);
		hintText.text = mediumHint;
		depecheMessage.text = mediumDT;
		rightAnswer = mediumAnswer;
		difficulty = 1;
	}

	public void setHard(){
		hintObject.SetActive (false);
		hintText.text = hardHint;
		depecheMessage.text = hardDT;
		rightAnswer = hardAnswer;
		difficulty = 2;
	}
}
