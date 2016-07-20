using UnityEngine;
using System.Collections;
using Math;

public abstract class SettingsWindow : SimpleWindow, ShowCursorHandler {
	
	public Enigma3D enigma;
	public int mousePressButton = 0;
	
	protected SimpleCursor cursor;
	
	public SettingsWindow (string title) : base (title) {
		SetNiceRect (Mathf.Max (Screen.width / 4, 450), 125);
		Visible = false;
	}
	
	protected override void Start () {
		base.Start ();
		enabled = true;
		cursor = GetComponent<SimpleCursor> () + this;
		Refresh ();
	}
	
	protected abstract void Refresh ();
	
	protected override void Close () {
		Visible = false;
		Refresh ();
	}
	
	protected abstract void Save ();
	
	private void PerformSave () {
		Save ();
		Refresh ();
		enigma.BindViewToLogic();
		Close ();
	}
	
	protected override void LateUpdate () {
		if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && Visible) {
			PerformSave ();
		}
		base.LateUpdate ();
	}
	
	protected override void ButtonsRow () {
		if (GUILayout.Button ("Zastosuj")) {
			PerformSave ();
		}
		GUILayout.Space (10);
		base.ButtonsRow ();
	}
	
	void OnMouseDown() {
		if (ShowCursor(true) && Input.GetMouseButtonDown (mousePressButton)) {
			Visible = true;
			cursor.Refresh (false);
		}
	}
	
	public virtual bool ShowCursor(bool mouseover) {
		return !Visible;
	}
	
	public bool ForceShowCursor(bool mouseover) {
		return false;
	}
	
}