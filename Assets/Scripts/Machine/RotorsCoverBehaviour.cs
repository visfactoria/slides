using UnityEngine;
using System.Collections;

public class RotorsCoverBehaviour : MonoBehaviour {
	
	public event MetalCoverBehaviour.MouseHandler MouseDown;
	public event MetalCoverBehaviour.MouseHandler MouseUp;
	
	void OnMouseDown() {
		MouseDown ();
	}
	
	void OnMouseUp() {
		MouseUp ();
	}
}
