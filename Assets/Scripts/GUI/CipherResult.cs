using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CipherResult : CipherResultStatic {

	public Enigma3D enigma;

	public Texture padlock;
	public Texture text;

	private string input = "";
	private string output = "";
	private bool enciphering = true;
	private string switchText;

	public int group = 5;
	
	private CipherResultStatic other;
	private MessageBox popup;
	
	public CipherResult () : base ("Wynik") {
		windowSize = new Rect(25, Screen.height - 225, Screen.width - 50, 200);
	}

	protected override void Start () {
		base.Start ();
		Style.fontSize = 50;
		enigma.OnResult += OnResult;
		SetMode (enciphering);
		other = gameObject.AddComponent<CipherResultStatic> ();
		other.Title = "Zapamiętany wynik";
		other.Style = Style;
		popup = gameObject.AddComponent<MessageBox> ();
		popup.Style = Style;
		popup.Title = "Tekst Ostateczny";

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
		if (input.Length > 0) {
			GUILayout.Space(10);
			GUILayout.BeginVertical();
			{
				GUILayout.Label(input, style);
				GUILayout.Label(output, style);
			}
			GUILayout.EndVertical();
		}
	}
	
	protected override void ButtonsRow () {
		if (GUILayout.Button(switchText)) {
			SetMode(!enciphering);
		}
		if (Length > 0) {
			GUILayout.Space(10);
			if (GUILayout.Button("Skopiuj do drugiego okna")) {
				other.copyContent(this, input, output);
				other.enabled = true;
			}
			if (!enciphering) {
				GUILayout.Space(10);
				if (GUILayout.Button("Odczytaj")) {
					popup.Show(OriginalText);
				}
			}
			GUILayout.Space(10);
			if (GUILayout.Button("Wyczyść")) {
				Clear ();
			}
		}
		GUILayout.Space(10);
		base.ButtonsRow ();
	}
	
	public void Clear () {
		input = "";
		inputGroups.Clear ();
		output = "";
		outputGroups.Clear ();
	}

	private int Length {
		get { return group * inputGroups.Count + input.Length; }
	}

	private void OnResult (Math.Result result) {
		if (enabled) {
			input += result.Input;
			output += result.Output;
			if (input.Length % group == 0) {
				inputGroups.Add (input);
				input = "";
				outputGroups.Add (output);
				output = "";
			}
		}
	}

	protected override void LateUpdate () {
		if (Input.GetKeyDown(KeyCode.Backspace)) {
			Clear ();
		}
	}

	private void SetMode (bool enciphering) {
		this.enciphering = enciphering;
		upper = enciphering ? text : padlock;
		lower = !enciphering ? text : padlock;
		switchText = enciphering ? "Przejdź do deszyfrowania" : "Wróć do szyfrowania";
		Clear ();
	}

	public string OriginalText {
		get {
			if (!enciphering) {
				string text = "";
				foreach (string s in outputGroups) {
					text += s;
				}
				text += output;
				return text.Replace("XXX", " ");
			}
			return null;
		}
	}

}