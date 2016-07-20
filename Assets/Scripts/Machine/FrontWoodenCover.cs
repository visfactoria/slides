using UnityEngine;
using System.Collections;

public class FrontWoodenCover : SimpleCover {

	protected override void Start () {
		base.Start ();
		openAnimationName = "BoxFrontOpen";
		closeAnimationName = "BoxFrontClose";
		InitialState = OpenCloseState.open;
	}
}