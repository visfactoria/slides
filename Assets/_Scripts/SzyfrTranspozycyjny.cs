using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SzyfrTranspozycyjny : MonoBehaviour {
	public string depeche;
	public string answer;
	public string errMessage1;
	public string errMessage2;
	public string helpMess1;
	public string helpMess2;
	public GameObject columnPrefab;
	public GameObject slotPrefab;
	public GameObject textPrefab;

	public GameObject answerFrame;
	public Color beige;
	public Color dGray;
	public Color burgundy;
	public string scuccessText;

	int columnCount = 0;

	public Text message;

	public GameObject helpObject;
	private Text helpMessage;
	private int helpNumber=0;

	public GridLayoutGroup grid;
	public float letterSize = 70.0f;
	public float sizeOffset = 2.0f;

	private int colHeight;
	private bool filled = false;

	public void CreateCollumns(int n){
		filled = false;
		ClearChildren ();

		columnCount = n;

		colHeight = depeche.Length / n;
		if((depeche.Length%n)!=0) colHeight++;

		grid.cellSize = new Vector2 (letterSize, letterSize * colHeight);
		for (int i = 0; i < n; i++) {
			
			//create slot clone
			GameObject slotClone = Instantiate(slotPrefab);
			slotClone.transform.SetParent (transform);

			//modify slot clone grid size
			slotClone.GetComponent<GridLayoutGroup>().cellSize = new Vector2(letterSize-sizeOffset,letterSize * colHeight-sizeOffset);

			//instantiate draggable collumn to slot
			GameObject colClone = Instantiate (columnPrefab);
			colClone.transform.SetParent (slotClone.transform);
			colClone.GetComponent<GridLayoutGroup>().cellSize = new Vector2(letterSize-sizeOffset*2,letterSize-sizeOffset*2);
			colClone.GetComponent<GridLayoutGroup> ().spacing = new Vector2 (0.0f, sizeOffset * 2);

			//create lettering for collumn
			/*
			for(int j=0;j<colHeight;j++){
				GameObject letter = Instantiate(textPrefab);
				letter.transform.SetParent (colClone.transform);
				if ((j * n + i) < depeche.Length) {
					System.Text.StringBuilder builder = new System.Text.StringBuilder ();
					builder.Append (depeche [j * n + i]);
					letter.GetComponent<Text> ().text = builder.ToString();
				}

			}*/


		}
	}

	public void CheckAnswer(){
		System.Text.StringBuilder builder = new System.Text.StringBuilder ();
		for (int j = 0; j < colHeight; j++) {
			for (int i=0;i<transform.childCount;i++) {
				builder.Append (transform.GetChild(i).GetChild(0).GetChild(j).GetComponent<Text>().text);//order:slot,dragcollumn,UItext,textcomponent
			}
		}
		if (builder.ToString ().Equals (answer)) {
			message.text =scuccessText;

			message.color = dGray;
			answerFrame.GetComponent<Image> ().color = beige;
		} else {
			message.text = errMessage2;


			message.color = beige;
			answerFrame.GetComponent<Image> ().color = burgundy;
		}
	}

	public void FillLettering(){
		if (!filled) {
			for (int i = 0; i < columnCount; i++) {
				Transform slot = transform.GetChild (i);
				foreach (Transform child in slot) {
					Destroy (child);
				}
				for (int j = 0; j < colHeight; j++) {
					GameObject letter = Instantiate (textPrefab);
					letter.transform.SetParent (slot.transform.GetChild (0).transform);
					if ((j * columnCount + i) < depeche.Length) {
						System.Text.StringBuilder builder = new System.Text.StringBuilder ();
						builder.Append (depeche [j * columnCount + i]);
						letter.GetComponent<Text> ().text = builder.ToString ();
					}
				}
			}
			if (columnCount != 5) {
				message.text = errMessage1;
				message.color = beige;
				answerFrame.GetComponent<Image> ().color = burgundy;
			} else {
				helpObject.SetActive (false);
				helpNumber = 1;
				message.text = "";
				message.color = beige;
				answerFrame.GetComponent<Image> ().color = dGray;
			}
			filled = true;
		}
	}

	public void showHelp(){
		if (helpNumber == 0) {
			helpObject.GetComponent<Text> ().text = helpMess1;
			helpObject.SetActive (true);
		}

		if (helpNumber == 1) {
			helpObject.GetComponent<Text> ().text = helpMess2;
			helpObject.SetActive (true);
		}
	}

	public void ClearChildren(){
		
			for (int i = transform.childCount-1; i >= 0; i--) {
				GameObject.Destroy(transform.GetChild(i).gameObject);
			}
		
	}
}
