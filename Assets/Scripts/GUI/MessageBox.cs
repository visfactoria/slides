using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MessageBox : SimpleWindow {

	private string text;
	
	public MessageBox (string title) : base (title) {
		windowSize = new Rect(25, (Screen.height - 120) / 2, Screen.width - 50, 120);
	}
	
	public MessageBox (string title, GUIStyle style) : this (title) {
		this.style = style;
	}
	
	public MessageBox () : this ("") { }

	protected override void Content () {
		GUILayout.Label (text, style);
	}

	public string Text {
		get { return text; }
		set { text = value; }
	}

	public void Show (string text) {
		Text = text;
		enabled = true;
	}
}