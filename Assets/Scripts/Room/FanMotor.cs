using UnityEngine;
using System.Collections;

public class FanMotor : MonoBehaviour {

	private AnimationState state;

	void Start () {
		state = GetComponent<Animation>() ["FanPanning"];
	}
	
	public void TurnOff() {}
	
	public void TurnOn() {}

	public float Speed {
		get { return state.speed; }
		set { state.speed = value; }
	}
}
