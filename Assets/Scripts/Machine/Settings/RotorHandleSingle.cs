using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotorHandleSingle : MonoBehaviour {

	public interface CanBeMovedHandler {
		bool CanBeMoved (RotorHandleSingle handle);
	}

	public delegate void OnClickHandler();
	public event OnClickHandler OnClick;

	private IList<CanBeMovedHandler> canBeMovedHandlers = new List<CanBeMovedHandler>();
	
	void OnMouseDown () {
		if (OnClick != null && CanBeMoved()) {
			OnClick();
		}
	}
	
	private bool CanBeMoved() {
		foreach (CanBeMovedHandler h in canBeMovedHandlers) {
			if (!h.CanBeMoved (this)) {
				return false;
			}
		}
		return true;
	}
	
	public void AddCanBePressedHandler(CanBeMovedHandler h) {
		canBeMovedHandlers.Add(h);
	}

	public static RotorHandleSingle operator+ (RotorHandleSingle handle, CanBeMovedHandler h) {
		handle.AddCanBePressedHandler (h);
		return handle;
	}
}