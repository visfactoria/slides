using System;

namespace Math {

	public class MachinePart : Permutation {

		public static int DEFAULT_LENGTH = 26;

		private string name;
		
		public MachinePart (int length) : base (length) { }
		
		public MachinePart () : this (DEFAULT_LENGTH) { }
		
		public MachinePart (int[] definition) : base (definition) { }
		
		public MachinePart (string definition) : this (StringHelper.FromString(definition)) { }
		
		public virtual char this[char letter, int power] {
			get {
				power = power % Length;
				Permutation sigma = this;
				if (power < 0) {
					power = -power;
					sigma = Inverse();
				}
				int index = StringHelper.Index (letter);
				for (int i = 0; i < power; i++) {
					index = sigma [index];
				}
				return StringHelper.Letter (index);
			}
		}
		
		public char this[char letter] {
			get { return this [letter, 1]; }
		}

		public string Name {
			get { return name != null ? name : ToString(); }
			set { name = value; }
		}
		
		public bool IsFixed(char letter) {
			return IsFixed(StringHelper.Index(letter));
		}

	}

}