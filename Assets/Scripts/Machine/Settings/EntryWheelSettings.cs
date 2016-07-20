using UnityEngine;
using System.Collections;
using Math;

public class EntryWheelSettings : SettingsWindow {

	private EntryWheel.ModelType type;
	
	public EntryWheelSettings () : base("Zmiana walca wstępnego") {
		SetNiceHeight (100);
	}
	
	protected override void Refresh () {
		cursor.Info = "Walec wstępny typu " + Logic.Name + ". Kliknij, by go wymienić.";
		type = Logic.Type;
	}
	
	protected override void Save () {
		if (type == EntryWheel.ModelType.ABC) {
			enigma.Logic.EntryWheel = EntryWheel.CreateEntryWheelABC ();
		} else if (type == EntryWheel.ModelType.QWERTY) {
			enigma.Logic.EntryWheel = EntryWheel.CreateEntryWheelQWERTY ();
		}
	}
	
	protected override void Content () {
		GUILayout.BeginVertical ();
		{
			GUILayout.Label("Wybierz typ walca wstępnego:", style);
			GUILayout.BeginHorizontal();
			{
				if (GUILayout.Toggle (type == EntryWheel.ModelType.ABC, "ABC")) {
					type = EntryWheel.ModelType.ABC;
				}
				GUILayout.Space (10);
				if (GUILayout.Toggle (type == EntryWheel.ModelType.QWERTY, "QWERTY")) {
					type = EntryWheel.ModelType.QWERTY;
				}
			}
			GUILayout.EndHorizontal();
		}
		GUILayout.EndVertical ();
	}

	public Math.EntryWheel Logic {
		get { return enigma.Logic.EntryWheel; }
	}

}