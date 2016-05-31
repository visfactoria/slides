using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviour {

	private GameObject popUpWindow;
	public RectTransform rect;
	private Vector3 showedPos =new Vector3 (0,0,0);
	private Vector3 hiddenPos =new Vector3 (50000,0,0);

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Show(){
		rect.anchoredPosition3D = showedPos;
	}

	public void Hide(){
		rect.anchoredPosition3D = hiddenPos;
	}


}
