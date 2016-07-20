using UnityEngine;
using System.Collections;

public class RotorBehaviour : MonoBehaviour {

	public event SimpleAnimator.StepHandler BeforeStep;
	public event SimpleAnimator.StepHandler AfterStep;

	private float time = 0.22f;
	private SimpleAnimator rotator;

	void Start () {
		rotator = gameObject.AddComponent<SimpleAnimator> ();
		rotator.Duration = time;
		rotator.Animations += AnimateSingleClick;
		rotator.BeforeStep += () => GetComponent<AudioSource>().Play ();
		rotator.BeforeStep += () => {
			if (BeforeStep != null) {
				BeforeStep ();
			}
		};
		rotator.AfterStep += () => {
			if (AfterStep != null) {
				AfterStep ();
			}
		};
	}
	
	public bool Rotate (int times) {
		return rotator.Play (times);
	}

	public bool Rotate () {
		return Rotate (1);
	}

	private void PerformRotation (float clicks) {
		transform.RotateAround (transform.position, Vector3.right, 360 * clicks / 26);
	}
	
	private void AnimateSingleClick (float delta) {
		PerformRotation(delta);
	}
	
	public void Set (Math.Rotor logic) {
		transform.rotation = new Quaternion();
		PerformRotation (Math.StringHelper.Index(logic.Offset));
	}
	
}