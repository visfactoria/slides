using System;
using System.Collections;
using System.Collections.Generic;

namespace Math {

	public class Plugboard : MachinePart {
		
		public Plugboard (int length) : base (length) { }
		
		public Plugboard () : this (DEFAULT_LENGTH) { }
		
		public Plugboard (int[] definition) : base (definition) {
			for (int i = 0; i < Length; i++) {
				if (this[this[i]] != i) {
					throw new ArgumentException("The given argument does not define an involution permutation.");
				}
			}
		}
		
		public Plugboard (string definition) : this (StringHelper.FromString(definition)) { }

		public bool Connects (char left, char right) {
			return this [left] == right && this [right] == left;
		}
		
		public bool Connect (char left, char right) {
			int l = StringHelper.Index(left);
			int r = StringHelper.Index(right);
			if (IsFixed (l) && IsFixed (r)) {
				definition[l] = r;
				definition[r] = l;
				return true;
			}
			return false;
		}
		
		public bool Disconnect (char letter) {
			int i = StringHelper.Index(letter);
			if (!IsFixed (i)) {
				definition[definition[i]] = definition[i];
				definition[i] = i;
				return true;
			}
			return false;
		}
		
		public bool Disconnect (char left, char right) {
			return Connects (left, right) && Disconnect (left);
		}

		public char[,] Pairs {
			get {
				IList<int> list = new List<int>();
				for (int i = 0; i < Length; i++) {
					if (!IsFixed(i) && i < this[i]) {
						list.Add (i);
					}
				}
				char[,] array = new char[list.Count,2];
				for (int i = 0; i < list.Count; i++) {
					array[i,0] = StringHelper.Letter(list[i]);
					array[i,1] = this[array[i,0]];
				}
				return array;
			}
		}

	}

}