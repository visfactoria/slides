using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Keyboard : MonoBehaviour, CanBePressedHandler {

	public Key[] keys;
	private IDictionary<char, Key> all = new Dictionary<char, Key> ();
	public event Key.KeyPressedHandler KeyPressed;
	public event Key.KeyDownHandler KeyDown;
	public event Key.KeyReleasedHandler KeyReleased;
	private Key x;

	void Start () {
		foreach (Key key in keys) {
			all.Add(key.Letter, key);
			key.KeyPressed += (Key k) => KeyPressed(k);
			key.KeyDown += (Key k) => KeyDown(k);
			key.KeyReleased += (Key k) => KeyReleased(k);
			key.AddCanBePressedHandler(this);
		}
		x = this ['X'];
	}

	void Update () { }
	
	void LateUpdate () {
		if (Input.GetKeyDown(KeyCode.Space) && x.CanBePressed()) {
			x.Press (3);
		}
	}
	
	public Key this[char letter] {
		get {
			Key key = null;
			all.TryGetValue (letter, out key);
			return key;
		}
	}
	
	public bool CanBePressed(Key key) {
		foreach (Key k in keys) {
			if (k != key && k.CurrentState != Key.State.up) {
				return false;
			}
		}
		return true;
	}
}
