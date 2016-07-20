using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class SimpleWindow : MonoBehaviour {
	
	protected GUIStyle style = new GUIStyle ();

	public int mouseButtonDrag = 0;
	protected Rect windowSize;
	public string title;
	private int id;
	private bool visible = true;
	protected bool closeOnEscape = true;
	
	public SimpleWindow (string title) {
		this.title = title;
		id = GetHashCode ();
		SetNiceRect (Screen.width / 2, Screen.height / 3);
	}
	
	public SimpleWindow (string title, GUIStyle style) : this(title) {
		this.style = style;
	}
	
	public SimpleWindow () : this ("") { }
	
	public Rect SetNiceRect (float width, float height) {
		windowSize = new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height);
		return windowSize;
	}
	
	public Rect SetNiceWidth (float width) {
		return SetNiceRect (width, windowSize.height);
	}
	
	public Rect SetNiceHeight (float height) {
		return SetNiceRect (windowSize.width, height);
	}
	
	protected virtual void Start () {
		enabled = false;
		style.normal.textColor = Color.white;
	}

	protected virtual void OnGUI() {
		if (visible) {
			windowSize = GUI.Window (id, windowSize, WindowContent, title);
		}
	}

	protected virtual void Close () {
		enabled = false;
	}
	
	protected virtual void LateUpdate () {
		if (Input.GetKeyDown(KeyCode.Escape) && Visible && closeOnEscape) {
			Close ();
		}
	}
	
	protected virtual void ButtonsRow () {
		if (GUILayout.Button ("Zamknij")) {
			Close ();
		}
	}
	
	protected abstract void Content ();
	
	protected virtual void WindowContent (int id) {
		GUILayout.BeginHorizontal();
		Content ();
		GUILayout.EndHorizontal();

		GUILayout.Space (5);
		
		GUILayout.BeginHorizontal();
		ButtonsRow ();
		GUILayout.EndHorizontal();

		if (Input.GetMouseButton(mouseButtonDrag)) {
			GUI.DragWindow ();
		}
	}
	
	public string Title {
		get { return title; }
		set { title = value; }
	}
	
	public GUIStyle Style {
		get { return style; }
		set { style = value; }
	}
	
	public bool Visible {
		get { return enabled && visible; }
		set { visible = value; }
	}
}