using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlugboardBehaviour : MonoBehaviour {
	
	public Enigma3D enigma;
	
	public PlugSocketBehaviour[] plugSockets;
	private IDictionary<char, PlugSocketBehaviour> all = new Dictionary<char, PlugSocketBehaviour> ();

	void Start () {
		foreach (PlugSocketBehaviour socket in plugSockets) {
			socket.Plugboard = this;
			socket.Refresh2 ();
			all.Add(socket.Letter, socket);
		}
	}

	void Update () { }
	
	public PlugSocketBehaviour this[char letter] {
		get {
			PlugSocketBehaviour socket = null;
			all.TryGetValue (letter, out socket);
			return socket;
		}
	}

	public void Set (Math.Plugboard logic) {
		foreach (PlugSocketBehaviour s in plugSockets) {
			s.ShowPlug (false);
		}
		char[,] pairs = logic.Pairs;
		for (int i = 0; 2 * i < pairs.Length; i++) {
			this[pairs[i, 0]].ShowPlug(true);
			this[pairs[i, 1]].ShowPlug(true);
		}
	}
	
	public Enigma3D Enigma {
		get { return enigma; }
		set { enigma = value; }
	}
	
	public Math.Plugboard Logic {
		get { return enigma.Logic.Plugboard; }
	}
}
