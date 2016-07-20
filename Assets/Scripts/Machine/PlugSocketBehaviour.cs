using UnityEngine;
using System.Collections;
using Math;

public class PlugSocketBehaviour : SettingsWindow {

	private static StringHelper chars = StringHelper.ALL;

	private PlugboardBehaviour plugboard;

	public string letterString;	
	public GameObject plugPrefab;
	private PlugBehaviour plug;
	private char connect;

	public PlugSocketBehaviour () : base (null) {
		SetNiceRect (Mathf.Max (Screen.width / 2, 850), 100);
	}

	void Update () { }
	
	public char Letter { 
		get { return letterString[0]; } 
	}
	
	public int Index {
		get { return Math.StringHelper.Index(Letter); }
	}

	public void ShowPlug (bool visible) {
		if (visible && plug == null) {
			plug = ((GameObject) Instantiate(plugPrefab, transform.position, Quaternion.identity)).GetComponent<PlugBehaviour>();
			plug.transform.parent = transform;
			plug.Socket = this;
		}
		if (plug != null) {
			plug.ShowPlug (visible);
		}
		Refresh ();
	}
	
	public Enigma3D Enigma {
		get { return plugboard.Enigma; }
	}
	
	public PlugboardBehaviour Plugboard {
		get { return plugboard; }
		set { plugboard = value; }
	}
	
	public Math.Plugboard Logic {
		get { return plugboard.Logic; }
	}
	
	public char Connected { 
		get { return Logic[Letter]; } 
	}
	
	protected override void Refresh () {
		if (cursor != null && plugboard != null) {
			Title = "Połącz gniazdo " + Letter + " łącznicy z innym";
			cursor.Info = "Gniazdo " + Letter + " łącznicy. Kliknij, by połączyć je z innym.";
			connect = Connected;
		}
	}
	
	public void Refresh2 () {
		Refresh ();
	}
	
	protected override void Save () {
		Logic.Connect (Letter, connect);
	}
	
	protected override void Content () {
		GUILayout.BeginVertical ();
		{
			GUILayout.Label("Wybierz drugi koniec połączenia:", style);
			GUILayout.BeginHorizontal();
			{
				for (int i = 0; i < chars.Length; i++) {
					char c = chars[i];
					if (c != Letter && Logic.IsFixed(c)) {
						if (GUILayout.Toggle (connect == c, c.ToString())) {
							connect = c;
						}
						GUILayout.Space (5);
					}
				}
			}
			GUILayout.EndHorizontal();
		}
		GUILayout.EndVertical ();
	}
	
	public override bool ShowCursor(bool mouseover) {
		return base.ShowCursor(mouseover) && (plug == null || !plug.Enabled);
	}

}
