 using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	
	public int mouseButton = 2;
	public Transform target;
	public string mouseHorizontalAxisName = "Mouse X";
	public string mouseVerticalAxisName = "Mouse Y";
	public string scrollAxisName = "Mouse ScrollWheel";
	public float verticalSensitivity = 5;
	public float horizontalSensitivity = 5;
	public float scrollSensitivity = 5;
	public float minimalDistance = 5;
	public float maximalDistance = 5;

	private float vertical = 0;
	private float horizontal = 0;
	
	void Start () {
		SetVerticalAngle (45);
	}
	
	public void SetHorizontalAngle (float horizontal) {
		transform.RotateAround (target.position, Vector3.up, horizontal - this.horizontal);
		this.horizontal = Mathf.Clamp(horizontal, 0, 360);
	}
	
	public void SetVerticalAngle (float vertical) {
		vertical = Mathf.Clamp(vertical, 0, 89);
		transform.RotateAround (target.position, transform.right, vertical - this.vertical);
		this.vertical = vertical;
	}
	
	public void RotateHorizontally (float angle) {
		SetHorizontalAngle (horizontal + angle);
	}
	
	public void RotateVertically (float angle) {
		SetVerticalAngle (vertical + angle);
	}
	
	void LateUpdate () {
		if (Input.GetMouseButton (mouseButton)) {
			RotateVertically(Input.GetAxis(mouseVerticalAxisName) * verticalSensitivity);
			RotateHorizontally(Input.GetAxis(mouseHorizontalAxisName) * horizontalSensitivity);
		}
		float factor = Input.GetAxis (scrollAxisName) * scrollSensitivity;
		if (factor != 0) {
			Vector3 translation = target.position - transform.position;
			float distance = Mathf.Abs(translation.magnitude + factor);
			translation.Normalize ();
			translation *= factor;
			if ((factor > 0 && distance > minimalDistance) || (factor < 0 && distance < maximalDistance)) {
				transform.position += translation;
			}
		}
		transform.LookAt (target);
	}
}
