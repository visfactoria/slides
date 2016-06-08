using UnityEngine;
using System.Collections;

public class Slides : MonoBehaviour {

	public GameObject[] slideArray;
	private int currentSlideIndex = 0;
	private GameObject currentSlide;
	private RectTransform slideRect;
	private RectTransform contentRect;
	private Vector3 showedPos =new Vector3 (0,0,0);
	private Vector3 hiddenPos =new Vector3 (50000,0,0);

	// Use this for initialization
	void Start () {
		contentRect = gameObject.GetComponent<RectTransform> ();
		CallibrateContentPosition ();
		UpdateSlide ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void UpdateSlide(){
		slideRect = slideArray [currentSlideIndex].GetComponent<RectTransform> ();
		slideRect.anchoredPosition3D = new Vector3(0.0f,slideRect.sizeDelta.y*(-0.5f),0.0f);
		contentRect.sizeDelta = new Vector2 (contentRect.sizeDelta.x, slideRect.sizeDelta.y);
	}

	private void HideSlide(){
		slideRect = slideArray [currentSlideIndex].GetComponent<RectTransform> ();
		slideRect.anchoredPosition3D = hiddenPos;
	}

	private void CallibrateContentPosition(){
		//contentRect.anchoredPosition3D = new Vector3 (-500.0f, 0.0f, 0.0f);
	}

	public void NextSlide(){
		HideSlide ();
		if(currentSlideIndex<slideArray.Length-1)
			currentSlideIndex++;
		UpdateSlide ();
	}

	public void PreviousSlide(){
		HideSlide ();
		if(currentSlideIndex>0)
		currentSlideIndex--;
		UpdateSlide ();
	}

	public void JumpToSlide(int n){
		HideSlide ();
		if((n<=slideArray.Length-1)&&(n>=0))
			currentSlideIndex = n;
		UpdateSlide ();
	}

}
