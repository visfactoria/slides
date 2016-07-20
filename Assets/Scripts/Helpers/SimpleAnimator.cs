using UnityEngine;
using System.Collections;

public class SimpleAnimator : MonoBehaviour {
	
	public delegate void Animate(float delta);
	public event Animate Animations;
	public delegate void StepHandler();
	public event StepHandler BeforeStep;
	public event StepHandler AfterStep;
	
	private float duration;
	private int times;
	private int factor = 1;
	private float started;
	private float last;
	
	void Start () {
		enabled = false;
		AfterStep += () => Play (times);
	}
	
	void LateUpdate () {
		float now = Time.time;
		if (now - started < duration) {
			Animations (factor * (now - last) / duration);
		} else {
			Animations (factor * (started + duration - last) / duration);
			enabled = false;
			times -= factor;
			AfterStep();
		}
		last = now;
	}

	public bool Play (float duration, int times) {
		if (enabled) { return false; }
		this.duration = duration;
		this.times = times;
		factor = (int) Mathf.Sign (times);
		started = Time.time;
		last = started;
		enabled = times != 0;
		if (enabled && BeforeStep != null) {
			BeforeStep ();
		}
		return true;
	}
	
	public bool Play (float duration) {
		return Play (duration, 1);
	}
	
	public bool Play (int times) {
		return Play (duration, times);
	}
	
	public bool Play () {
		return Play (1);
	}
	
	public float Duration {
		get { return duration; }
		set { duration = value; }
	}
	
	public bool IsPlaying {
		get { return enabled; }
	}
}
