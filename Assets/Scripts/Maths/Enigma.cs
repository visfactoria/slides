using System;

namespace Math {

	public class Enigma {

		public delegate void OnCipheringResult (Result result);

		public static int DEFAULT_ROTORS_NUMBER = 3;

		private Plugboard plugboard = new Plugboard ();
		private EntryWheel entrywheel = new EntryWheel ();
		private Rotor[] rotors = new Rotor [DEFAULT_ROTORS_NUMBER];
		private Reflector reflector = new Reflector ();

		public Enigma () {
			for (int i = 0; i < Rotors.Length; i++) {
				Rotors[i] = new Rotor (0);
			}
		}
		
		public Plugboard Plugboard {
			get { return plugboard; }
			set { plugboard = value; }
		}
		
		public EntryWheel EntryWheel {
			get { return entrywheel; }
			set { entrywheel = value; }
		}
		
		public Rotor[] Rotors {
			get { return rotors; }
			set { rotors = value; }
		}
		
		public Reflector Reflector {
			get { return reflector; }
			set { reflector = value; }
		}
		
		public int Length {
			get { return 2 * (rotors.Length + 2) + 1; }
		}

		public MachinePart this[int index] {
			get {
				if (index == 0 || index == Length - 1) {
					return Plugboard;
				} else if (index == 1 || index == Length - 2) {
					return EntryWheel;
				} else if (2 * index == Length - 1) {
					return Reflector;
				} else if (2 * index < Length - 1) {
					return Rotors[index - 2];
				} else {
					return Rotors[Length - index - 3];
				}
			}
		}

		public int Sign (int index) {
			return 2 * index <= Length - 1 ? 1 : -1;
		}
		
		public char this[char plaintext] {
			get {
				char c = plaintext;
				for (int i = 0; i < Length; i++) {
					c = this[i][c, Sign (i)];
				}
				return c;
			}
		}
		
		public bool Irregular (int index) {
			return 0 < index && index < Rotors.Length;
		}

		private bool[] RotorsShift () {
			bool[] shift = new bool[Rotors.Length];
			if (Rotors.Length > 0) {
				shift[0] = true;
				for (int i = 1; i < Rotors.Length; i++) {
					shift[i] = (shift[i - 1] && Rotors[i - 1].Notched) || (Irregular(i) && Rotors[i].Notched);
				}
			}
			return shift;
		}

		public static Result operator+ (Enigma enigma, char plaintext) {
			bool[] shift = enigma.RotorsShift ();
			for (int i = 0; i < shift.Length; i++) {
				if (shift[i]) {
					enigma.Rotors[i].Rotate();
				}
			}
			Result result = new Result(plaintext, shift);
			for (int i = 0; i < enigma.Length; i++) {
				result += enigma[i][result.Output, enigma.Sign (i)];
			}
			return result;
		}
	}

}

