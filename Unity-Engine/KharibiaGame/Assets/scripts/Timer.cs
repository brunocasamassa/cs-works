using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public static Timer tempo;
	public Text cronometro;
	public float time = 0, MoreLessTime;
	int minutos, segundos;

	void Awake(){
		tempo = this;
	}

	void FixedUpdate(){
		time -= Time.deltaTime;
	}

	// Update is called once per frame
	void Update () {

		minutos = (int)time / 60;
		segundos = (int)time % 60;

		if (time > 0) {
			cronometro.text = string.Format ("{0:00}:{1:00}", minutos, segundos);
		}

		if (time <= 0) {
			cronometro.text = "Game Over";
		}
	}

}
