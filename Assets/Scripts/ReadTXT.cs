using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class ReadTXT : MonoBehaviour {

	Text slideText;
	//public string filepath = "sample.txt";
	public TextAsset ta;



	void Start () {
		//print ("fetching resources from " + filepath);
		//ta = Resources.Load (filepath, typeof(TextAsset)) as TextAsset;
		//StreamReader reader = new StreamReader(filepath);	
		//print ("getting text component");
		slideText = GetComponent<Text> ();
		slideText.text = "Switched out the text to this\n";
		//slideText.text += reader.ReadLine ();
		//print ("concatenating text from " + filepath);
		slideText.text += ta.text;
	}



	void Update () {
	
	}
}
