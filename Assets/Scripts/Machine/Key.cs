using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface CanBePressedHandler {
	bool CanBePressed(Key key);
}

public class Key : MonoBehaviour, CanBePressedHandler {

	public enum State { up, pressed, down, released, tapped }

	public delegate void KeyPressedHandler(Key key);
	public delegate void KeyDownHandler(Key key);
	public delegate void KeyReleasedHandler(Key key);
	public delegate void KeyUpHandler(Key key);

	public event KeyPressedHandler KeyPressed;
	public event KeyDownHandler KeyDown;
	public event KeyReleasedHandler KeyReleased;
	public event KeyUpHandler KeyUp;

	public int mousePressButton = 0;
	public string letterString;
	public string lowercase;
	
	private IList<CanBePressedHandler> canBePressedHandlers = new List<CanBePressedHandler>();
	
	private State state = State.up;
	private int count = 0;

	private bool releaseTapped = false;

	private SimpleCursor cursor;
	
	public string pressInfo;
	public string releaseInfo;

	public Key () {
		AddCanBePressedHandler (this);
	}

	void Start () {
		lowercase = letterString.ToLower ();
		cursor = GetComponent<SimpleCursor>();
		pressInfo += " " + letterString;
		cursor.Info = pressInfo;
		KeyPressed += (Key key) => { cursor.Info = ""; };
		KeyDown += (Key key) => { cursor.Info = releaseInfo; };
		KeyReleased += (Key key) => { cursor.Info = ""; };
		KeyUp += (Key key) => { cursor.Info = pressInfo; };
	}

	void LateUpdate () {
		if (Input.GetKeyDown(lowercase) && CanBePressed()) {
			Press ();
		} else if (Input.GetKeyUp(lowercase)) {
			HandleRelease ();
		} else if (releaseTapped) {
			releaseTapped = false;
			StartCoroutine("ReleaseTapped");
		}
	}
	
	public char Letter { 
		get { return letterString[0]; } 
	}
	
	public int Index {
		get { return Math.StringHelper.Index(Letter); }
	}
	
	private void Press (int times, bool tap) {
		count = Mathf.Max (times, 0);
		if (count > 0) {
			state = tap ? State.tapped : State.pressed;
			if (KeyPressed != null) {
				KeyPressed(this);
			}
			GetComponent<Animation>().Play ("KeyDown");
			GetComponent<AudioSource>().Play ();
			StartCoroutine ("Down");
		}
	}
	
	public void Press (int times) {
		Press (times, times > 1);
	}
	
	public void Press () {
		Press (1);
	}
	
	private IEnumerator Down () {
		do {
			yield return null;
		} while (GetComponent<Animation>().isPlaying);
		if (KeyDown != null) {
			KeyDown(this);
		}
		if (state == State.tapped) {
			releaseTapped = true;
		} else {
			state = State.down;
		}
	}
	
	void OnMouseDown() {
		if (Input.GetMouseButtonDown (mousePressButton) && CanBePressed ()) {
			Press ();
		}
	}

	private void Release () {
		state = State.released;
		if (KeyReleased != null) {
			KeyReleased(this);
		}
		GetComponent<Animation>().Play("KeyUp");
		StartCoroutine("Up");
	}
	
	private IEnumerator Up () {
		do {
			yield return null;
		} while (GetComponent<Animation>().isPlaying);
		if (KeyUp != null) {
			KeyUp(this);
		}
		state = State.up;
		count--;
		if (count > 0) {
			Press (count, true);
		}
	}
	
	void OnMouseUp() {
		if (Input.GetMouseButtonUp (mousePressButton)) {
			HandleRelease ();
		}
	}

	void HandleRelease () {
		if (state == State.down) {
			Release ();
		} else if (state == State.pressed) {
			state = State.tapped;
		}
	}
	
	private IEnumerator ReleaseTapped () {
		yield return new WaitForSeconds(0.05f);
		Release ();
	}

	public Key.State CurrentState {
		get { return state; }
	}

	public bool CanBePressed(Key key) {
		return key.state == State.up;
	}

	public void AddCanBePressedHandler(CanBePressedHandler h) {
		canBePressedHandlers.Add(h);
	}
	
	public bool CanBePressed() {
		foreach (CanBePressedHandler h in canBePressedHandlers) {
			if (!h.CanBePressed (this)) {
				return false;
			}
		}
		return true;
	}


}
