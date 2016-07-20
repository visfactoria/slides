using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface CanBeOpenedClosedHandler {
	bool CanBeOpened(SimpleCover cover);
	bool CanBeClosed(SimpleCover cover);
}

public class SimpleCover : MonoBehaviour, CanBeOpenedClosedHandler, ShowCursorHandler {

	public delegate void CoverStartedOpening();
	public delegate void CoverOpened();
	public delegate void CoverStartedClosing();
	public delegate void CoverClosed();

	public event CoverStartedOpening StartedOpening;
	public event CoverStartedClosing StartedClosing;
	public event CoverOpened Opened;
	public event CoverClosed Closed;
	
	public string mouseHorizontalAxisName = "Mouse X";
	public string mouseVerticalAxisName = "Mouse Y";
	public int mouseButton = 0;

	protected string openAnimationName;
	protected string closeAnimationName;

	protected OpenCloseState state;
	
	private IList<CanBeOpenedClosedHandler> canBeOpenedClosedHandlers = new List<CanBeOpenedClosedHandler>();

	private bool down = false;
	
	public string openLabel;
	public string closeLabel;
	
	protected SimpleCursor cursor;
	
	public AudioClip openAudio;
	public AudioClip shutAudio;

	public SimpleCover () {
		AddCanBeOpenedClosedHandler (this);
	}

	protected virtual void Start () {
		if (cursor == null) {
			cursor = GetComponent<SimpleCursor> ();
		}
		Opened += GotOpened;
		Closed += GotClosed;
		StartedOpening += () => cursor.Refresh(false);
		StartedClosing += () => cursor.Refresh(false);
		cursor += this;

		Closed += () => {
			if (GetComponent<AudioSource>() != null && shutAudio != null) {
				GetComponent<AudioSource>().PlayOneShot(shutAudio);
			}
		};
		StartedOpening += () => {
			if (GetComponent<AudioSource>() != null && openAudio != null) {
				GetComponent<AudioSource>().PlayOneShot(openAudio);
			}
		};
		StartedClosing += () => {
			if (GetComponent<AudioSource>() != null && openAudio != null) {
				GetComponent<AudioSource>().PlayOneShot(openAudio);
			}
		};

		InitialState = OpenCloseState.closed;
	}

	protected OpenCloseState InitialState {
		set {
			state = value;
			if (IsClosed) {
				cursor.Info = openLabel;
			} else if (IsOpened) {
				cursor.Info = closeLabel;
			}
		}
	}
	
	protected virtual void OnMouseDown() {
		if (Input.GetMouseButtonDown (mouseButton)) {
			down = true;
		}
	}
	
	protected virtual void OnMouseUp() {
		if (down && Input.GetMouseButtonUp (mouseButton)) {
			if (CanBeOpened()) {
				state = OpenCloseState.opening;
				if (StartedOpening != null) {
					StartedOpening();
				}
				GetComponent<Animation>().Play(openAnimationName);
				StartCoroutine("Open");
			} else if (CanBeClosed()) {
				state = OpenCloseState.closing;
				if (StartedClosing != null) {
					StartedClosing();
				}
				GetComponent<Animation>().Play(closeAnimationName);
				StartCoroutine("Close");
			}
			down = false;
		}
	}
	
	void LateUpdate () {
		if (Input.GetAxis(mouseVerticalAxisName) != 0 || Input.GetAxis(mouseHorizontalAxisName) != 0) {
			down = false;
		}
	}
	
	protected IEnumerator Open () {
		do {
			yield return null;
		} while (GetComponent<Animation>().isPlaying);
		state = OpenCloseState.open;
		if (Opened != null) {
			Opened();
		}
	}
	
	protected IEnumerator Close () {
		do {
			yield return null;
		} while (GetComponent<Animation>().isPlaying);
		state = OpenCloseState.closed;
		if (Closed != null) {
			Closed();
		}
	}
	
	public void AddCanBeOpenedClosedHandler(CanBeOpenedClosedHandler h) {
		canBeOpenedClosedHandlers.Add(h);
	}
	
	public static SimpleCover operator+(SimpleCover cover, CanBeOpenedClosedHandler handler) {
		cover.AddCanBeOpenedClosedHandler(handler);
		return cover;
	}
	
	private bool CanBeOpened() {
		foreach (CanBeOpenedClosedHandler h in canBeOpenedClosedHandlers) {
			if (!h.CanBeOpened (this)) {
				return false;
			}
		}
		return true;
	}
	
	private bool CanBeClosed() {
		foreach (CanBeOpenedClosedHandler h in canBeOpenedClosedHandlers) {
			if (!h.CanBeClosed (this)) {
				return false;
			}
		}
		return true;
	}
	
	public bool CanBeOpened(SimpleCover cover) {
		return IsClosed;
	}
	
	public bool CanBeClosed(SimpleCover cover) {
		return IsOpened;
	}
	
	public bool IsClosed {
		get { return state == OpenCloseState.closed; }
	}
	
	public bool IsOpened {
		get { return state == OpenCloseState.open; }
	}
	
	public bool InMotion {
		get { return !(IsOpened || IsClosed); }
	}
	
	void GotOpened() {
		cursor.Info = closeLabel;
		cursor.Refresh ();
	}
	
	void GotClosed() {
		cursor.Info = openLabel;
		cursor.Refresh ();
	}
	
	public bool ShowCursor(bool mouseover) {
		return !InMotion && (CanBeOpened() || CanBeClosed());
	}
	
	public bool ForceShowCursor(bool mouseover) {
		return false;
	}
}

public class CanBeOpenedClosed : CanBeOpenedClosedHandler {
	
	public delegate bool CanBeOpenedHandler (SimpleCover cover);
	public delegate bool CanBeClosedHandler (SimpleCover cover);
	
	public event CanBeOpenedHandler Opened;
	public event CanBeClosedHandler Closed;

	public bool CanBeOpened(SimpleCover cover) {
		return Opened == null || Opened (cover);
	}

	public bool CanBeClosed(SimpleCover cover) {
		return Closed == null || Closed (cover);
	}
}