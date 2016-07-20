using UnityEngine;
using System.Collections;

public class MetalCoverBehaviour : SimpleCover {

	public delegate void MouseHandler();
	
	public event MechanismCoverBehaviour.MouseHandler MouseDown;
	public event MechanismCoverBehaviour.MouseHandler MouseUp;
	public RotorsCoverBehaviour source;
	
	protected override void Start () {
		cursor = source.GetComponent<SimpleCursor> ();
		base.Start ();
		openAnimationName = "RotorCoverOpen";
		closeAnimationName = "RotorCoverClose";
		source.MouseDown += () => base.OnMouseDown();
		source.MouseUp += () => base.OnMouseUp();
	}
	
	override protected void OnMouseDown() {
		MouseDown ();
	}
	
	override protected void OnMouseUp() {
		MouseUp ();
	}
}
