using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchToScene : MonoBehaviour {

	public void SwitchToCyclometer(){
		SceneManager.LoadScene (1);
	}

	public void GoToScene(int sceneN){
		SceneManager.LoadScene(sceneN);	
	}

	public void UnloadScene(int n){
		SceneManager.UnloadScene (n);
	}
}
