using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {


	public Transform target = null;

	void Start () {
	
	}
	

	void Update () {
		if (target != null) {
			transform.LookAt(target);
		}
	}
}
