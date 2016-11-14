using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonIsland : MonoBehaviour {

	GameObject[] pause;

	// Use this for initialization
	void Start(){
		Time.timeScale = 1;
		pause = GameObject.FindGameObjectsWithTag ("ShowOnPause");
		HidePaused ();
	}

	void Update(){
		
	}

	public void PauseControl(){
		if(Time.timeScale == 1){
			Time.timeScale = 0;
			ShowPaused ();
		}
		else if(Time.timeScale == 0){
			Time.timeScale = 1;
			HidePaused ();
		}
	}

	public void ShowPaused(){
		foreach(GameObject g in pause){
			g.SetActive (true);
		}
	}

	public void HidePaused(){
		foreach(GameObject g in pause){
			g.SetActive (false);
		}
	}
}
