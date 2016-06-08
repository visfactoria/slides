using UnityEngine;
using System.Collections;

public class RotateCogs : MonoBehaviour {
	public Transform largeCog;
	public Transform[] smallCogsA;
	public Transform[] smallCogsB;
	public Transform[] smallCogsC;
	public float rotationSpeed = 100;
	private float mainRotation = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mainRotation = rotationSpeed * Time.deltaTime;
		largeCog.Rotate (new Vector3 (mainRotation,0,0));
		for (int i = 0; i < smallCogsA.Length; i++) {
			smallCogsA[i].Rotate(new Vector3 (mainRotation*1.6f,0,0));
			smallCogsB[i].Rotate(new Vector3 (mainRotation*1.6f*0.04f,0,0));
			smallCogsC[i].Rotate(new Vector3 (mainRotation*1.6f*0.04f*0.4f,0,0));
		}
	}
}
