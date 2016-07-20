using UnityEngine;
using System.Collections;

public class testAnimation : MonoBehaviour {
	public Transform boxTop;
	public Transform boxFront;

	// Use this for initialization
	void Start () {

		//animation["WoodFrontClose"].AddMixingTransform(boxFront);
		//animation["WoodTopClose"].AddMixingTransform(boxTop);

		GetComponent<Animation>().Play("WoodTopClose");
		GetComponent<Animation>().Blend ("WoodFrontClose");
		//animation.Play("WoodFrontClose");
	}
	
	// Update is called once per frame
	void Update () {
		/* if ((animation ["WoodTopClose"].enabled == false)&&(animation ["WoodFrontClose"].enabled == false)) {
			animation.Play("WoodTopClose");
			animation.Blend ("WoodFrontClose");
		} */
	}
}
