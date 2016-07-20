using UnityEngine;
using System.Collections;
using Math;

public class MathsTest : MonoBehaviour {

	void Start () {
		MachinePart m = new MachinePart ("BAFEDC");
		string s = "";
		for (int l = 0; l < m.Length; l ++) {
			char c = StringHelper.Letter(l);
			for (int i = 1; i <= m.Length; i ++) {
				s += "[" + c + ", " + i + "] -> " + m[c, i] + "; ";
			}
			s += "\n";
		}
		print (s);
	}
}
