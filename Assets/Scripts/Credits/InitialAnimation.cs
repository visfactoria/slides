using UnityEngine;
using System.Collections;

public class InitialAnimation : MonoBehaviour {

	public float speed;

	void Start () {
	
	}

	void LateUpdate () {
		Vector3 pos = transform.position;
		pos.x += + Time.deltaTime * speed;
		transform.position = pos;
	}
}
