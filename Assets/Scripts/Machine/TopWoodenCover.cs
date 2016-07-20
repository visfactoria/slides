using UnityEngine;
using System.Collections;

public class TopWoodenCover : SimpleCover {
	
	protected override void Start () {
		base.Start ();
		openAnimationName = "BoxTopOpen";
		closeAnimationName = "BoxTopClose";
		InitialState = OpenCloseState.open;
	}
}