using UnityEngine;
using System.Collections;
using Math;

public class Enigma3D : MonoBehaviour {

	private Enigma logic = new Enigma();
	private Result result = null;
	
	public Keyboard keyboard;
	public Lights lights;
	public RotorBehaviour[] rotors;
	public PlugboardBehaviour plugboard;

	public TopWoodenCover topCover;
	public FrontWoodenCover frontCover;
	public MetalCoverBehaviour rotorsCover;
	public MechanismCoverBehaviour metalBoxCover;

	public event Enigma.OnCipheringResult OnResult;

	public RotorHandle[] rotorSetters;

	public Enigma3D () {
		logic.Plugboard = new Plugboard ();
		logic.Plugboard.Connect('E', 'N');
		logic.Plugboard.Connect('I', 'G');
		logic.Plugboard.Connect('M', 'A');
		logic.EntryWheel = EntryWheel.CreateEntryWheelQWERTY ();
		logic.Rotors [0] = Rotor.CreateRotorI ();
		logic.Rotors [0].Offset = 'M';
		logic.Rotors [1] = Rotor.CreateRotorII ();
		logic.Rotors [1].Offset = 'A';
		logic.Rotors [2] = Rotor.CreateRotorIII ();
		logic.Rotors [2].Offset = 'U';
		logic.Reflector = Reflector.CreateReflectorB ();
	}

	public void BindViewToLogic() {
		for (int i = 0; i < logic.Rotors.Length; i++) {
			rotors[i].Set(logic.Rotors[i]);
		}
		plugboard.Set (logic.Plugboard);
	}

	void Start () {
		BindViewToLogic ();
		{
			keyboard.KeyPressed += HandleKeyPressed;
			keyboard.KeyDown += HandleKeyDown;
			keyboard.KeyReleased += HandleKeyReleased;
		}
		{
			CanBeOpenedClosed h = new CanBeOpenedClosed ();
			h.Closed += (SimpleCover cover) => frontCover.IsClosed && metalBoxCover.IsClosed && rotorsCover.IsClosed;
			topCover.AddCanBeOpenedClosedHandler (h);
			
			h = new CanBeOpenedClosed ();
			h.Opened += (SimpleCover cover) => topCover.IsOpened;
			frontCover.AddCanBeOpenedClosedHandler (h);
			
			h = new CanBeOpenedClosed ();
			h.Opened += (SimpleCover cover) => rotorsCover.IsClosed;
			metalBoxCover.AddCanBeOpenedClosedHandler (h);
			
			h = new CanBeOpenedClosed ();
			h.Opened += (SimpleCover cover) => metalBoxCover.IsClosed && topCover.IsOpened;
			rotorsCover.AddCanBeOpenedClosedHandler (h);
		}
		for (int i = 0; i < rotorSetters.Length; i++) {
			RotorHandle h = rotorSetters[i];
			RotorPositionChanger c = new RotorPositionChanger(this, i);
			h.forward += c;
			h.backward += c;
			h.OnBackward += () => c.ChangeRotorPosition(-1);
			h.OnForward += () => c.ChangeRotorPosition(1);
		}
	}

	void Update () { }
	
	void HandleKeyPressed (Key key) {
		result = logic + key.Letter;
		for (int i = 0; i < result.Shift.Length; i++) {
			if (result.Shift[i]) {
				rotors[i].Rotate();
			}
		}
	}
	
	void HandleKeyDown (Key key) {
		if (OnResult != null) {
			OnResult (result);
		}
		lights[result.Output].SwitchOn();
	}
	
	void HandleKeyReleased (Key key)	{
		lights[result.Output].SwitchOff();
	}

	private class RotorPositionChanger : RotorHandleSingle.CanBeMovedHandler {

		private Enigma3D enigma;
		private int index;

		public RotorPositionChanger (Enigma3D enigma, int index) {
			this.enigma = enigma;
			this.index = index;
		}
		
		public void ChangeRotorPosition (int clicks) {
			RotorBehaviour mesh = enigma.rotors [index];
			if (mesh.Rotate (clicks)) {
				Rotor math = enigma.logic.Rotors [index];
				math += clicks;
			}
		}
		
		public bool CanBeMoved (RotorHandleSingle handle) {
			return enigma.rotorsCover.IsOpened || enigma.metalBoxCover.IsOpened;
		}

	}

	public Enigma Logic {
		get { return logic; }
	}
}
