using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SzyfrTranspozycyjny : MonoBehaviour {
	public string depeche;
	public string answer;
	public GameObject columnPrefab;
	public GameObject slotPrefab;
	public GameObject textPrefab;

	public Text message;

	public GridLayoutGroup grid;
	public float letterSize = 70.0f;
	public float sizeOffset = 2.0f;

	private int colHeight;

	public void CreateCollumns(int n){
		ClearChildren ();

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

			for(int j=0;j<colHeight;j++){
				GameObject letter = Instantiate(textPrefab);
				letter.transform.SetParent (colClone.transform);
				if ((j * n + i) < depeche.Length) {
					System.Text.StringBuilder builder = new System.Text.StringBuilder ();
					builder.Append (depeche [j * n + i]);
					letter.GetComponent<Text> ().text = builder.ToString();
				}

			}


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
			message.text = "Sukces!!!";
		} else {
			message.text = "Źle. Próbuj Dalej.";
		}
	}

	public void ClearChildren(){
		
			for (int i = transform.childCount-1; i >= 0; i--) {
				GameObject.Destroy(transform.GetChild(i).gameObject);
			}
		
	}
}
