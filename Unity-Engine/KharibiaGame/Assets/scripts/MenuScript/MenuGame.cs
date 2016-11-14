using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour {

	GameObject[] option;


	void Start(){
		option = GameObject.FindGameObjectsWithTag ("ShowOptions");
		HideOptions ();
	}

	void Update(){
		
	}

	public void StartGame(){
		SceneManager.LoadScene ("loading");
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void MenuOptions(){
		ShowOptions ();
	}

	public void ExitOptions(){
		HideOptions ();
	}

	public void ShowOptions(){
		foreach(GameObject g in option){
			g.SetActive (true);
		}
	}

	public void HideOptions(){
		foreach(GameObject g in option){
			g.SetActive (false);
		}
	}
}
