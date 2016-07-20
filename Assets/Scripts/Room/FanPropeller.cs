using UnityEngine;
using System.Collections;

public class FanPropeller : MonoBehaviour {

	private AnimationState state;
	
	void Start () {
		state = GetComponent<Animation>() ["FanRotating"];
		Speed = 2;
	}
	
	public void TurnOff() {
		GetComponent<AudioSource>().Stop ();
	}
	
	public void TurnOn() {
		GetComponent<AudioSource>().Play ();
	}
	
	public float Speed {
		get { return state.speed; }
		set { state.speed = value; }
	}
}
