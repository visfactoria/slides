using UnityEngine;
using System.Collections;

public class MechanismCoverBehaviour : SimpleCover {
	
	public delegate void MouseHandler();
	public MetalCoverBehaviour source;
	
	protected override void Start () {
		cursor = source.GetComponent<SimpleCursor> ();
		base.Start ();
		openAnimationName = "CoverScrewsUnscrew";
		closeAnimationName = "CoverScrewsInsert";
		source.MouseDown += () => OnMouseDown();
		source.MouseUp += () => OnMouseUp();
	}
}