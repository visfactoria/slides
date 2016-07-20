using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CipherResultStatic : SimpleWindow {

	protected IList<string> inputGroups = new List<string>();
	protected IList<string> outputGroups = new List<string>();
	protected Texture upper;
	protected Texture lower;
	
	public CipherResultStatic (string title) : base(title) {
		windowSize = new Rect(25, 25, Screen.width - 50, 200);
	}
	
	public CipherResultStatic (string title, GUIStyle style) : this(title) {
		this.style = style;
	}
	
	public CipherResultStatic () : this ("") { }

	public void copyContent (CipherResultStatic other, string input, string output) {
		inputGroups.Clear ();
		outputGroups.Clear ();
		upper = other.upper;
		lower = other.lower;
		for (int i = 0; i < other.inputGroups.Count; i++) {
			inputGroups.Add (other.inputGroups[i]);
			outputGroups.Add (other.outputGroups[i]);
		}
		if (input.Length > 0) {
			inputGroups.Add (input);
			outputGroups.Add (output);
		}
	}
	
	protected override void Content () {
		GUILayout.BeginVertical();
		{
			GUILayout.Label(upper);
			GUILayout.Label(lower);
		}
		GUILayout.EndVertical();
		GUILayout.Space(10);
		for (int i = 0; i < Groups; i++) {
			GUILayout.Space(10);
			GUILayout.BeginVertical();
			{
				GUILayout.Label(inputGroups[i], style);
				GUILayout.Label(outputGroups[i], style);
			}
			GUILayout.EndVertical();
		}
	}
	
	protected int Groups {
		get { return inputGroups.Count; }
	}
}