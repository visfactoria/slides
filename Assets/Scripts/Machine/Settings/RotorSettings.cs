using UnityEngine;
using System.Collections;
using Math;

public class RotorSettings : SettingsWindow {

	public int index;

	private Rotor.ModelType type;
	private char ring;
	
	public RotorSettings () : base("Zmiana rotora") { }

	protected override void Start() {
		base.Start ();
		Title += " " + (index + 1);
	}
	
	protected override void Refresh () {
		cursor.Info = "Rotor " + (index + 1) + " typu " + Logic.Name + ". Kliknij, by go wymienić.";
		type = Logic.Type;
		ring = Logic.Ring;
	}
	
	protected override void Save () {
		Rotor rot = Logic;
		if (type == Rotor.ModelType.I) {
			rot = Rotor.CreateRotorI ();
		} else if (type == Rotor.ModelType.II) {
			rot = Rotor.CreateRotorII ();
		} else if (type == Rotor.ModelType.III) {
			rot = Rotor.CreateRotorIII ();
		} else if (type == Rotor.ModelType.IV) {
			rot = Rotor.CreateRotorIV ();
		} else if (type == Rotor.ModelType.V) {
			rot = Rotor.CreateRotorV ();
		} else if (type == Rotor.ModelType.VI) {
			rot = Rotor.CreateRotorVI ();
		} else if (type == Rotor.ModelType.VII) {
			rot = Rotor.CreateRotorVII ();
		} else if (type == Rotor.ModelType.VIII) {
			rot = Rotor.CreateRotorVIII ();
		}
		rot.Ring = ring;
		enigma.Logic.Rotors[index] = rot;
	}
	
	protected override void Content () {
		GUILayout.BeginVertical ();
		{
			GUILayout.Label("Wybierz typ rotora " + (index + 1), style);
			GUILayout.BeginHorizontal();
			{
				if (GUILayout.Toggle (type == Rotor.ModelType.I, "I")) {
					type = Rotor.ModelType.I;
				}
				GUILayout.Space (10);
				if (GUILayout.Toggle (type == Rotor.ModelType.II, "II")) {
					type = Rotor.ModelType.II;
				}
				GUILayout.Space (10);
				if (GUILayout.Toggle (type == Rotor.ModelType.III, "III")) {
					type = Rotor.ModelType.III;
				}
				GUILayout.Space (10);
				if (GUILayout.Toggle (type == Rotor.ModelType.IV, "IV")) {
					type = Rotor.ModelType.IV;
				}
				GUILayout.Space (10);
				if (GUILayout.Toggle (type == Rotor.ModelType.V, "V")) {
					type = Rotor.ModelType.V;
				}
				GUILayout.Space (10);
				if (GUILayout.Toggle (type == Rotor.ModelType.VI, "VI")) {
					type = Rotor.ModelType.VI;
				}
				GUILayout.Space (10);
				if (GUILayout.Toggle (type == Rotor.ModelType.VII, "VII")) {
					type = Rotor.ModelType.VII;
				}
				GUILayout.Space (10);
				if (GUILayout.Toggle (type == Rotor.ModelType.VIII, "VIII")) {
					type = Rotor.ModelType.VIII;
				}
			}
			GUILayout.EndHorizontal();
			GUILayout.Space (3);
			GUILayout.BeginHorizontal();
			{
				GUILayout.Label("Wpisz przesunięcie pierścienia:", style);
				GUILayout.Space (10);
				ring = Math.StringHelper.Coerce(GUILayout.TextField ("" + ring));
			}
			GUILayout.EndHorizontal();
		}
		GUILayout.EndVertical ();
	}
	
	public Math.Rotor Logic {
		get { return enigma.Logic.Rotors[index]; }
	}
	
}