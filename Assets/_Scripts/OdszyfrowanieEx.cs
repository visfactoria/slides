﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OdszyfrowanieEx : MonoBehaviour {
	public Transform targetList;
	public Text message;
	public string rightAnswer = "POSNAIBCDEFGHJKLMQRTUVWXYZ";


	public GameObject answerFrame;
	public Color beige;
	public Color dGray;
	public Color burgundy;


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

			message.color = dGray;
			answerFrame.GetComponent<Image> ().color = beige;
		} else {


				message.text = "Źle. Próbuj Dalej.";
				message.color = beige;
				answerFrame.GetComponent<Image> ().color = burgundy;

		}
	}
}