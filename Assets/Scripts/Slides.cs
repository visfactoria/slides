using UnityEngine;
using System.Collections;

public class Slides : MonoBehaviour {

	public GameObject[] slideArray;
	private int currentSlideIndex = 0;
	private GameObject currentSlide;
	private RectTransform rect;
	private Vector3 showedPos =new Vector3 (0,0,0);
	private Vector3 hiddenPos =new Vector3 (50000,0,0);

	// Use this for initialization
	void Start () {
		UpdateSlide ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void UpdateSlide(){
		/*if (currentSlide != null)
			Destroy (currentSlide);
		currentSlide = Instantiate (slideArray [currentSlideIndex]);
		currentSlide.transform.SetParent (this.transform, false);
		rect = currentSlide.GetComponent<RectTransform>();
		rect.anchoredPosition = new Vector3 (0, 0, 0);
		//currentSlide.transform.localPosition =new Vector3 (0, 0, 0);
		currentSlide.transform.localScale = new Vector3 (1, 1, 1);*/

		rect = slideArray [currentSlideIndex].GetComponent<RectTransform> ();
		rect.anchoredPosition3D = showedPos;
	}

	private void HideSlide(){
		rect = slideArray [currentSlideIndex].GetComponent<RectTransform> ();
		rect.anchoredPosition3D = hiddenPos;
	}

	public void Next(){
		HideSlide ();
		if(currentSlideIndex<slideArray.Length-1)
			currentSlideIndex++;
		UpdateSlide ();
	}

	public void Previous(){
		HideSlide ();
		if(currentSlideIndex>0)
		currentSlideIndex--;
		UpdateSlide ();
	}
}
