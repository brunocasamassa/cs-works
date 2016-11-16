using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public Camera cam;
	public GameObject[] objetos;
	GameObject obj;
	public float minSeg = 0, maxSeg = 0, currentTime = 0;
	private float maxWidth, rateSpawn, objWidth, tempo;

	// Use this for initialization
	void Start () {
		if(cam == null){
			cam = Camera.main;
		}

		Vector3  uC = new Vector3 (Screen.width, Screen.height);
		Vector3 tgWidth = cam.ScreenToWorldPoint (uC);

		objWidth = objetos[0].GetComponent<Renderer> ().bounds.extents.x;
		maxWidth = tgWidth.x - objWidth;

		SetRandomTime ();
		currentTime = minSeg;
	}

	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;

		if (currentTime >= rateSpawn) {
			Spawn ();
			SetRandomTime ();
		}
	}

	void SetRandomTime(){
		rateSpawn = Random.Range (minSeg, maxSeg);
	}

	void Spawn(){
		currentTime = 0;
		tempo = Timer.tempo.time;
		obj = objetos [Random.Range (0, objetos.Length)];

		if (tempo >= 0.5f) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth, maxWidth), transform.position.y);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (obj, spawnPosition, spawnRotation);

				
		}
	}
}
