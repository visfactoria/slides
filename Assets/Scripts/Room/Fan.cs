using UnityEngine;
using System.Collections;

public class Fan : MonoBehaviour, ShowCursorHandler {
	
	public int mouseButton = 0;
	public FanMotor motor;
	public FanPropeller propeller;
	private bool on = true;
	
	private SimpleAnimator starter;
	private SimpleCursor cursor;
	
	void Start () {
		starter = gameObject.AddComponent<SimpleAnimator>();
		starter.Duration = 2f;
		starter.AfterStep += () => {
			float speed = on ? 1 : 0;
			motor.Speed = speed;
			propeller.Speed = 2 * speed;
		};
		starter.Animations += Animate;
		cursor = GetComponent<SimpleCursor> ();
		cursor.AddCanCursorBeShownHandler (this);
	}
	
	void OnMouseDown() {
		if (Input.GetMouseButtonDown (mouseButton) && !starter.IsPlaying) {
			On = !on;
			cursor.Refresh(false);
		}
	}

	bool On {
		set {
			on = value;
			if (on) {
				starter.Play(1);
				motor.TurnOn ();
				propeller.TurnOn ();
			} else {
				starter.Play(-1);
				motor.TurnOff ();
				propeller.TurnOff ();
			}
		}
	}

	void Animate(float delta) {
		motor.Speed += delta;
		propeller.Speed += 2 * delta;
	}

	public bool ShowCursor (bool mouseover) {
		return !starter.IsPlaying;
	}

	public bool ForceShowCursor (bool mouseover) {
		return false;
	}
}
