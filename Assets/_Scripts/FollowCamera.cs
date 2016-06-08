using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public Transform target = null;
	public float speed = 5.0f;
	public float zoomspeed = 0.1f;

	void Start () {
	
	}//Start
	

	void Update () {
		
		if (target != null) {
			transform.LookAt (target);

			if (Input.GetMouseButton(1)) {
				transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X")*speed);
				transform.RotateAround(target.position, Vector3.right, Input.GetAxis("Mouse Y")*speed);
			}
			if(Input.GetAxis("Mouse ScrollWheel")>0){
				transform.Translate (Vector3.forward * zoomspeed);
			}
			if(Input.GetAxis("Mouse ScrollWheel")<0){
				transform.Translate (Vector3.back * zoomspeed);
			}
		}
	}//Update
}
