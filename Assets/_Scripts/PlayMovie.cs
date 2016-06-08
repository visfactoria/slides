using UnityEngine;
using System.Collections;

public class PlayMovie : MonoBehaviour {

	public void ShowMovie(){

		Application.ExternalCall( "SayHello", "The game says hello!" );
	}
}
