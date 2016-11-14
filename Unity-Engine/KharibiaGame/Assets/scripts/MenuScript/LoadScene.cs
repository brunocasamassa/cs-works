using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

	private bool load = false;
	[SerializeField] private int scene;
	public Text loadingText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!load) {
			load = true;
			loadingText.text = "LOADING";
			StartCoroutine ("Loading");
		}
		if (load) {
			loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 0.5f));
		}
	}

	IEnumerator Loading(){
		yield return new WaitForSeconds (2f);

		AsyncOperation async = SceneManager.LoadSceneAsync (scene);

		while(!async.isDone){
			print ("progresso: " + async.progress);
			yield return null;
		}
	}
}
