using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture keyTexture;
	public Texture resultTexture;
	public Texture closeTexture;

	public CipherResult result;
	public EnigmaSettings settings;

	public Font font;
	
	protected GUIStyle style = new GUIStyle ();

	void Start () {
		style.font = font;
		style.fontSize = 50;
		settings.Style.font = font;
		result.Style.font = font;
	}

	private int padding = 15;

	void OnGUI() {
		if (!settings.enabled || !result.enabled) {
			GUILayout.BeginHorizontal();
			{
				GUILayout.Space (padding);
				GUILayout.BeginVertical();
				{
					if (!settings.enabled) {
						GUILayout.Space (padding);
						if (GUILayout.Button(keyTexture)) {
							settings.enabled = true;
						}
					}
					if (!result.enabled) {
						GUILayout.Space (padding);
						if (GUILayout.Button(resultTexture)) {
							result.Clear();
							result.enabled = true;
						}
					}
				}
				GUILayout.EndVertical ();
			}
			GUILayout.EndHorizontal ();
		}
		if (GUI.Button (new Rect(Screen.width - closeTexture.width - padding - 3, padding, closeTexture.width + 6, closeTexture.height + 6), closeTexture)) {
			Application.Quit ();
		}
	}
}