using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ApplyBox : MessageBox {
	
	public ApplyBox (string title) : base (title) {
		SetNiceRect(Mathf.Max (Screen.width / 4, 450), 125);
	}
	
	public ApplyBox (string title, GUIStyle style) : this (title) {
		this.style = style;
	}
	
	public ApplyBox () : this ("") { }
	
	protected abstract void Apply ();
	
	protected override void ButtonsRow () {
		if (GUILayout.Button ("Zastosuj")) {
			Apply ();
			Close ();
		}
		GUILayout.Space (10);
		base.ButtonsRow ();
	}
	
	protected override void LateUpdate () {
		if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && Visible) {
			Apply ();
			Close ();
		}
		base.LateUpdate ();
	}
}