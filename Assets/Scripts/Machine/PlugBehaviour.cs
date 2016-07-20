using UnityEngine;
using System.Collections;

public class PlugBehaviour : ApplyBox, ShowCursorHandler {
		
	private SimpleCursor cursor;
	public int mousePressButton = 0;
	private PlugSocketBehaviour socket;

	public PlugBehaviour () : base ("Odłącz wtyczkę ") {
		Visible = false;
		SetNiceHeight (75);
	}
	
	protected override void Start () {
		base.Start ();
		enabled = true;
		cursor = GetComponent<SimpleCursor> () + this;
		Title += Letter;
		Refresh ();
	}
	
	public void Refresh () {
		if (cursor != null) {
			Text = "Czy na pewno chcesz rozłączyć połączenie " + Letter + " z " + Connected + "?";
			cursor.Info = "Kliknij, by rozłączyć połączenie " + Letter + " z " + Connected + ".";
		}
	}
	
	protected override void Apply () {
		socket.Plugboard.Logic.Disconnect (Letter, Connected);
		Enigma.BindViewToLogic ();
	}
	
	protected override void Close () {
		Visible = false;
		Refresh ();
	}
	
	public Enigma3D Enigma {
		get { return socket.Enigma; }
	}
	
	public PlugSocketBehaviour Socket {
		get { return socket; }
		set { socket = value; }
	}
	
	void OnMouseDown() {
		if (Input.GetMouseButtonDown (mousePressButton)) {
			Visible = true;
			cursor.Refresh (false);
		}
	}
	
	public bool ShowCursor(bool mouseover) {
		return !Visible;
	}
	
	public bool ForceShowCursor(bool mouseover) {
		return false;
	}
	
	public char Letter {
		get { return socket.Letter; }
	}
	
	public char Connected {
		get { return socket.Connected; }
	}
	
	public void ShowPlug (bool visible) {
		if (visible) {
			Refresh();
		}
		Enabled = visible;
	}

	public bool Enabled {
		get { return GetComponent<Renderer>().enabled && GetComponent<Collider>().enabled; }
		set {
			GetComponent<Renderer>().enabled = value;
			GetComponent<Collider>().enabled = value;
		}
	}

}