using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class InternalLoading : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.LoadSceneAsync(StaticLoading.levelToLoad);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
