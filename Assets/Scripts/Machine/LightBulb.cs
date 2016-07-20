using UnityEngine;
using System.Collections;

public class LightBulb : MonoBehaviour {
	
	public string letterString;
	private Material[] litMaterial;
	private Material[] unlitMaterial;
	private bool on = false;
	public GameObject bulb;
	private Component halo;
	private System.Reflection.PropertyInfo haloEnabled;

	// Use this for initialization
	void Start () {
		litMaterial = new Material[] { GetComponent<Renderer>().materials [0] };
		unlitMaterial = new Material[] { GetComponent<Renderer>().materials[1] };
		SwitchOff ();
		halo = bulb.GetComponent("Halo");
		this.haloEnabled = halo.GetType ().GetProperty ("enabled");
		haloEnabled.SetValue(halo, false, null);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public bool On {
		get { return on; }
	}
	
	public char Letter {
		get { return letterString[0]; }
	}
	
	public int Index {
		get { return Math.StringHelper.Index(Letter); }
	}
	
	public void SetOn (bool on) {
		if (on) {
			SwitchOn ();
		} else {
			SwitchOff ();
		}
	}
	
	public void SwitchOff () {
		on = false;
		GetComponent<Renderer>().materials = unlitMaterial;
		if (haloEnabled != null) {
			haloEnabled.SetValue(halo, on, null);
		}
	}
	
	public void SwitchOn () {
		on = true;
		GetComponent<Renderer>().materials = litMaterial;
		if (haloEnabled != null) {
			haloEnabled.SetValue(halo, on, null);
		}
	}
}
