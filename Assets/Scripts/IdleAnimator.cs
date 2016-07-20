 using UnityEngine;
using System.Collections;

public class IdleAnimator : MonoBehaviour {
	
	public float waitTime;
	public float velocity;
	private float time;
	private MainCamera cam;
	private Vector3 mouse;
	
	void Start () {
		time = Time.time;
		cam = GetComponent<MainCamera>();
		mouse = Input.mousePosition;
	}
	
	void LateUpdate () {
		if (Input.anyKey || !mouse.Equals (Input.mousePosition)) {
			time = Time.time;
			mouse = Input.mousePosition;
		} else if (Time.time - time > waitTime) {
			cam.RotateHorizontally(Time.deltaTime * velocity);
		}
	}
}
