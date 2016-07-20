using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lights : MonoBehaviour {

	public LightBulb[] lights;
	private IDictionary<char, LightBulb> all = new Dictionary<char, LightBulb> ();

	// Use this for initialization
	void Start () {
		foreach (LightBulb light in lights) {
			all.Add(light.Letter, light);
		}
	}

	void Update () {
	
	}

	public LightBulb this[char letter] {
		get {
			LightBulb light = null;
			all.TryGetValue (letter, out light);
			return light;
		}
	}
}
