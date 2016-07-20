using UnityEngine;
using System.Collections;

public class EnigmaSettings : MessageBox {
	
	public Enigma3D enigma;

	public EnigmaSettings () {
		SetNiceRect (Mathf.Max (Screen.width / 2, 700), 130);
	}
	
	protected override void Start () {
		base.Start ();
		Style.fontSize = 20;
		Title = "Aktualne ustawienia szyfrowania";
		closeOnEscape = false;
	}

	protected override void Content () {
		Math.Enigma enigma = this.enigma.Logic;
		GUILayout.BeginVertical ();
		{
			GUILayout.BeginHorizontal ();
			{
				GUILayout.Label("Walec Wstępny:", style);
				GUILayout.Space (10);
				GUILayout.Label(enigma.EntryWheel.Name, style);
				GUILayout.Space (20);
				
				GUILayout.Label("Reflektor:", style);
				GUILayout.Space (10);
				GUILayout.Label(enigma.Reflector.Name, style);
			}
			GUILayout.EndHorizontal ();
			GUILayout.BeginHorizontal ();
			{				
				Math.Rotor[] rotors = enigma.Rotors;
				GUILayout.Label("Rotory:", style);
				for (int i = 0; i < rotors.Length; i++) {
					GUILayout.Space (10);
					Math.Rotor r = rotors[i];
					GUILayout.Label(r.Name + " (" + r.Ring + ")", style);
				}
			}
			GUILayout.EndHorizontal ();
			GUILayout.BeginHorizontal ();
			{
				Math.Plugboard plugboard = enigma.Plugboard;
				char[,] pairs = plugboard.Pairs;
				GUILayout.Label("Łącznica:", style);
				GUILayout.Space (20);
				for (int i = 0; 2 * i < pairs.Length; i++) {
					GUILayout.Label(pairs[i, 0] + "" + pairs[i, 1], style);
					GUILayout.Space (10);
				}
			}
			GUILayout.EndHorizontal ();
		}
		GUILayout.EndVertical ();
	}
}