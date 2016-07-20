using System;
using System.Collections;
using System.Collections.Generic;
namespace Math {
	
	public class Result {
		
		private IList<char> path = new List<char>();
		private bool[] shift;

		public Result (char input, bool[] shift) {
			path.Add (input);
			this.shift = shift;
		}

		public char Input {
			get { return path[0]; }
		}
		
		public char Output {
			get { return path[Length - 1]; }
		}
		
		public bool[] Shift {
			get { return shift; }
		}

		public int Length {
			get { return path.Count; }
		}
		
		public char this[int index] {
			get { return path[index]; }
		}

		public static Result operator+(Result r, char c) {
			r.path.Add (c);
			return r;
		}
	}
}