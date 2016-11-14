using UnityEngine;
using System.Collections;

public class Sincronia : MonoBehaviour {

	public static Sincronia instancia;
	public float tempo, speed, aumentaSpeed; 
	// Use this for initialization
	void Awake () {
		instancia = this;
	}
	
	// Update is called once per frame
	void Update () {
		speed += aumentaSpeed * Time.deltaTime;
		tempo = speed * Time.deltaTime;
	}
}
