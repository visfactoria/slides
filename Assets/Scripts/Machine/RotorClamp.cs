using UnityEngine;
using System.Collections;

public class RotorClamp : MonoBehaviour {

	public RotorBehaviour rotor;

	void Start () {
		rotor.BeforeStep += () => GetComponent<Animation>().Play("RotorClampFlick");
	}
}