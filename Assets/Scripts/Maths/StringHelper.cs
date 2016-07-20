using System;
using System.Collections;
using UnityEngine;

namespace Math {
	public class StringHelper {
		
		public static char A = 'A';
		public static char B = 'B';
		public static char C = 'C';
		public static char D = 'D';
		public static char E = 'E';
		public static char F = 'F';
		public static char G = 'G';
		public static char H = 'H';
		public static char I = 'I';
		public static char J = 'J';
		public static char K = 'K';
		public static char L = 'L';
		public static char M = 'M';
		public static char N = 'N';
		public static char O = 'O';
		public static char P = 'P';
		public static char Q = 'Q';
		public static char R = 'R';
		public static char S = 'S';
		public static char T = 'T';
		public static char U = 'U';
		public static char V = 'V';
		public static char W = 'W';
		public static char X = 'X';
		public static char Y = 'Y';
		public static char Z = 'Z';
		
		public static char a = 'a';
		public static char b = 'b';
		public static char c = 'c';
		public static char d = 'd';
		public static char e = 'e';
		public static char f = 'f';
		public static char g = 'g';
		public static char h = 'h';
		public static char i = 'i';
		public static char j = 'j';
		public static char k = 'k';
		public static char l = 'l';
		public static char m = 'm';
		public static char n = 'n';
		public static char o = 'o';
		public static char p = 'p';
		public static char q = 'q';
		public static char r = 'r';
		public static char s = 's';
		public static char t = 't';
		public static char u = 'u';
		public static char v = 'v';
		public static char w = 'w';
		public static char x = 'x';
		public static char y = 'y';
		public static char z = 'z';
		
		private static char[] LETTERS = new char[] {A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z};
		private static char[] letters = new char[] {a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z};
		
		public static StringHelper ALL = new StringHelper (false);
		public static StringHelper all = new StringHelper (true);

		public static int Count = LETTERS.Length;
		
		public static int Index (char letter) {
			return (int) (char.ToUpper(letter) - A);
		}
		
		public static char Letter (int index) {
			return (char) (A + index);
		}

		public static int[] FromString (string definition) {
			int[] result = new int[definition.Length];
			for (int i = 0; i < definition.Length; i++) {
				result[i] = Index(definition [i]);
			}
			return result;
		}

		public static char Coerce (string text) {
			if (text == null || "".Equals(text)) {
				return A;
			}
			return Letter (Mathf.Clamp(Index (text[0]), 0, Count));
		}

		private char[] array;

		public StringHelper (bool lowercase) {
			this.array = lowercase ? letters : LETTERS;
		}

		public int Length {
			get { return array.Length; }
		}

		public char this[int index] {
			get { return array [index]; }
		}

	}
}

