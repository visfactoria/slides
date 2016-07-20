using System;

namespace Math {

	public class Permutation {
		
		// contains definition of permutation: i ==> definition[i]
		protected int[] definition = new int[0];
		
		public Permutation (params int[] definition) {
			if (definition == null) { throw new ArgumentException("The definition cannot be null."); }
			bool[] taken = new bool[definition.Length];		
			for (int i = 0; i < definition.Length; i++) { taken[i] = false; }		
			foreach (int i in definition) {
				if (i < 0 || i >= definition.Length || taken[i]) {
					throw new ArgumentException("The given argument does not define a permutation.");
				}
				taken[i] = true;
			}		
			this.definition = definition;
		}
		
		public Permutation(int length) {
			if (length < 0) {
				throw new ArgumentException("The length cannot be negative.");
			}
			this.definition = new int[length];
			for (int i = 0; i < length; i++) {
				this.definition[i] = i;
			}
		}
		
		public int Length {
			get { return definition.Length; }
		}
		
		public int this[int index] {
			get { return definition [index]; }
		}

		public int At (int index) {
			return this[index];
		}
		
		public override string ToString () {
			if (Length == 0) { return "[ ]"; }
			if (Length == 1) { return "[0]"; }
			String result = "[";
			for (int i = 0; i < Length - 1; i++) {
				result += this[i] + ", ";
			}
			return result + this[Length - 1] + "]";
		}

		public int InverseAt (int index) {
			for (int i = 0; i < Length; i++) {
				if (this[i] == index) { return i; }
			}
			throw new ArgumentException("The index given is not valid.");
		}
		
		public Permutation Inverse () {		
			int[] definition = new int[Length];
			for (int i = 0; i < Length; i++) {
				definition[this[i]] = i;
			}
			return new Permutation(definition);
		}

		public static Permutation operator *(Permutation left, Permutation right) {
			if (left == null || right == null || left.Length != right.Length) {
				return null;
			}
			int[] result = new int[left.Length];
			for (int i = 0; i < left.Length; i++) {
				result[i] = left[right[i]];
			}
			return new Permutation(result);
		}

		public static Permutation operator -(Permutation sigma) {
			if (sigma == null) { return null; }
			return sigma.Inverse ();
		}

		public static Permutation operator /(Permutation left, Permutation right) {
			return left * (-right);
		}

		public static Permutation operator ^(Permutation sigma, int power) {
			if (sigma == null) { return null; }
			power = power % sigma.Length;
			if (power == 0) { return new Permutation (sigma.Length); }
			if (power < 0) {
				power = -power;
				sigma = -sigma;
			}
			Permutation temp = new Permutation(sigma.definition);
			Permutation result = new Permutation (sigma.Length);
			int m = power;
			while (m > 0) {
				if (m % 2 == 0) {
					m /= 2;
					temp = temp * temp;
				} else {
					m -= 1;
					result = temp * result;
				}
			}
			return result;
		}

		public bool IsFixed(int index) {
			return this[index] == index;
		}
		
	}
}