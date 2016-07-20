using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleCursor : MonoBehaviour, ShowCursorHandler {

	public Texture2D texture;
	public int x;
	public int y;
	private int width;
	private int height;
	private bool mouseover = false;
	private bool show = false;
	public string info = null;
	protected GUIStyle style = new GUIStyle ();

	private IList<ShowCursorHandler> showCursorHandlers = new List<ShowCursorHandler>();

	void Start () {
		width = texture.width;
		height = texture.height;
		style.normal.textColor = Color.white;
		style.fontSize = 20;
		AddCanCursorBeShownHandler(this);
	}
	
	public void Refresh (bool show) {
		this.show = show;
		Cursor.visible = !show;
	}
	
	public void Refresh () {
		Refresh(ShowCursor ());
	}
	
	void OnMouseEnter() {
		mouseover = true;
		Refresh ();
	}
	
	void OnMouseExit() {
		mouseover = false;
		show = ForceShowCursor ();
		Cursor.visible = !show;
	}
	
	void OnGUI(){
		if (show) {
			var rect = new Rect (Input.mousePosition.x - x, Screen.height - Input.mousePosition.y - y, width, height);
			GUI.DrawTexture (rect, texture);
			if (info != null) {
				GUI.Label(new Rect(20, Screen.height - 45, Screen.width - 40, 25), info);
			}
		}
	}

	public string Info {
		get { return info; }
		set { info = value; }
	}
	
	public bool ShowCursor(bool mouseover) {
		return mouseover;
	}
	
	public bool ForceShowCursor(bool mouseover) {
		return false;
	}
	
	private bool ShowCursor() {
		foreach (ShowCursorHandler h in showCursorHandlers) {
			if (!h.ShowCursor (mouseover)) {
				return false;
			}
		}
		return true;
	}
	
	private bool ForceShowCursor() {
		foreach (ShowCursorHandler h in showCursorHandlers) {
			if (h.ForceShowCursor (mouseover)) {
				return true;
			}
		}
		return false;
	}
	
	public void AddCanCursorBeShownHandler(ShowCursorHandler h) {
		showCursorHandlers.Add(h);
	}

	public static SimpleCursor operator+(SimpleCursor cursor, ShowCursorHandler handler) {
		cursor.AddCanCursorBeShownHandler (handler);
		return cursor;
	}
}

public interface ShowCursorHandler {
	bool ShowCursor(bool mouseover);
	bool ForceShowCursor(bool mouseover);
}