using UnityEngine;
using System.Collections;

public class RotorHandle : MonoBehaviour {

	public delegate void OnRotorPositionChanged ();
	public event OnRotorPositionChanged OnForward;
	public event OnRotorPositionChanged OnBackward;
	
	public RotorHandleSingle forward;
	public RotorHandleSingle backward;

	void Start () {
		forward.OnClick +=  Forward;
		backward.OnClick += Backward;
	}
	
	private void Forward () {
		if (OnForward != null) {
			OnForward ();
		}
	}

	private void Backward () {
		if (OnBackward != null) {
			OnBackward ();
		}
	}
}
