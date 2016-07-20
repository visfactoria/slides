using UnityEngine;
using System.Collections;
using Math;

public class ReflectorSettings : SettingsWindow {

	private Reflector.ModelType type;
	
	public ReflectorSettings () : base("Zmiana reflektora") {
		SetNiceHeight (100);
	}

	protected override void Refresh () {
		cursor.Info = "Reflektor typu " + Logic.Name + ". Kliknij, by go wymienić.";
		type = Logic.Type;
	}
	
	protected override void Save () {
		if (type == Reflector.ModelType.B) {
			enigma.Logic.Reflector = Reflector.CreateReflectorB();
		} else if (type == Reflector.ModelType.C) {
			enigma.Logic.Reflector = Reflector.CreateReflectorC();
		}
	}
	
	protected override void Content () {
		GUILayout.BeginVertical ();
		{
			GUILayout.Label("Wybierz typ reflektora:", style);
			GUILayout.BeginHorizontal();
			{
				if (GUILayout.Toggle (type == Reflector.ModelType.B, "B")) {
					type = Reflector.ModelType.B;
				}
				GUILayout.Space (10);
				if (GUILayout.Toggle (type == Reflector.ModelType.C, "C")) {
					type = Reflector.ModelType.C;
				}
			}
			GUILayout.EndHorizontal();
		}
		GUILayout.EndVertical ();
	}

	public Math.Reflector Logic {
		get { return enigma.Logic.Reflector; }
	}

}