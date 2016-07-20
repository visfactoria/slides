   using System;

namespace Math {
	
	public class Rotor : MachinePart {
		
		public enum ModelType { custom, I, II, III, IV, V, VI, VII, VIII }

		public static String I = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
		public static String II = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
		public static String III = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
		public static String IV = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
		public static String V = "VZBRGITYUPSDNHLXAWMJQOFECK";
		public static String VI = "JPGVOUMFYQBENHZRDKASXLICTW";
		public static String VII = "NZJHGRCXMYSWBOUFAIVLPEKQDT";
		public static String VIII = "FKQHTLXOCBJSPDZRAMEWNIUYGV";

		public static int NOTCH_I = 16;
		public static int NOTCH_II = 4;
		public static int NOTCH_III = 21;
		public static int NOTCH_IV = 9;
		public static int NOTCH_V = 24;
		public static int NOTCH_VI = 0;
		public static int NOTCH_VII = 0;
		public static int NOTCH_VIII = 0;
		
		public static Rotor CreateRotorI () {
			Rotor result = new Rotor (I, NOTCH_I);
			result.Name = "I";
			result.type = ModelType.I;
			return result;
		}
		
		public static Rotor CreateRotorII () {
			Rotor result = new Rotor (II, NOTCH_II);
			result.Name = "II";
			result.type = ModelType.II;
			return result;
		}
		
		public static Rotor CreateRotorIII () {
			Rotor result = new Rotor (III, NOTCH_III);
			result.Name = "III";
			result.type = ModelType.III;
			return result;
		}
		
		public static Rotor CreateRotorIV () {
			Rotor result = new Rotor (IV, NOTCH_IV);
			result.Name = "IV";
			result.type = ModelType.IV;
			return result;
		}
		
		public static Rotor CreateRotorV () {
			Rotor result = new Rotor (V, NOTCH_V);
			result.Name = "V";
			result.type = ModelType.V;
			return result;
		}
		
		public static Rotor CreateRotorVI () {
			Rotor result = new Rotor (VI, NOTCH_VI);
			result.Name = "VI";
			result.type = ModelType.VI;
			return result;
		}
		
		public static Rotor CreateRotorVII () {
			Rotor result = new Rotor (VII, NOTCH_VII);
			result.Name = "VII";
			result.type = ModelType.VII;
			return result;
		}

        public static Rotor CreateRotorVIII() {
            Rotor result = new Rotor(VIII, NOTCH_VIII);
            result.Name = "VIII";
            result.type = ModelType.VIII;
            return result;
        }

        public static Rotor CreateRotor(int index) {
            switch (index) {
                case 1: return CreateRotorI();
                case 2: return CreateRotorII();
                case 3: return CreateRotorIII();
                case 4: return CreateRotorIV();
                case 5: return CreateRotorV();
                case 6: return CreateRotorVI();
                case 7: return CreateRotorVII();
                case 8: return CreateRotorVIII();
            }
            return new Rotor(DEFAULT_LENGTH, 0);
        }
		
		private int notch;
		private int ring = 0;
		private int offset = 0;
		
		private ModelType type = ModelType.custom;
		
		public Rotor (int length, int notch) : base (length) {
			this.notch = notch;
		}
		
		public Rotor (int notch) : this (DEFAULT_LENGTH, notch) { }
		
		public Rotor (int[] definition, int notch) : base (definition) {
			this.notch = notch;
		}
		
		public Rotor (string definition, int notch) : this (StringHelper.FromString(definition), notch) { }
		
		public char Notch {
			get { return StringHelper.Letter (notch); }
		}
		
		public char Ring {
			get { return StringHelper.Letter (ring); }
			set { ring = StringHelper.Index (value); }
		}
		
		public char Offset {
			get { return StringHelper.Letter (offset); }
			set { offset = StringHelper.Index (value); }
		}

		public bool Notched {
			get { return notch == offset; }
		}

		public int Shift {
			get { return ring - offset; }
		}
		
		public override char this[char letter, int power] {
			get {
				power = power % Length;
				Permutation sigma = this;
				if (power < 0) {
					power = -power;
					sigma = Inverse();
				}
				int index = (StringHelper.Index(letter) - Shift + Length) % Length;
				for (int i = 0; i < power; i++) {
					index = sigma [index];
				}
				return StringHelper.Letter ((index + Shift + Length) % Length);
			}
		}

		public void Rotate () {
			offset = (offset + 1) % Length;
		}

		public static Rotor operator+ (Rotor rotor, int shift) {
			rotor.offset = (rotor.offset + shift % rotor.Length + rotor.Length) % rotor.Length;
			return rotor;
		}
		
		public ModelType Type {
			get { return type; }
		}

	}

}