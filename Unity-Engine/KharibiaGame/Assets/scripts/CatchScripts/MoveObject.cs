using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

	public Camera cam;
	private float maxWidth;
	[SerializeField] AudioSource source;
	[SerializeField] AudioClip[] audios;
	[SerializeField] TextMesh score_texture;
	int score = 0;


	// Use this for initialization
	void Start () {
		
		if (cam == null) {
			cam = Camera.main;
		}

		Vector3 upC = new Vector3 (Screen.width, Screen.height);
		Vector3 tgWidth = cam.ScreenToWorldPoint (upC);
		float objWidth = GetComponent<Renderer> ().bounds.extents.x;
		maxWidth = tgWidth.x - objWidth;	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float tgWidth;
		Vector3 objPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		Vector3 tgPosition = new Vector3 (objPosition.x, transform.position.y, 0.0f);

		tgWidth = Mathf.Clamp (tgPosition.x, -maxWidth, maxWidth);
		tgPosition = new Vector3 (tgWidth, tgPosition.y, tgPosition.z);
		GetComponent<Rigidbody2D> ().MovePosition (tgPosition);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Bomb") {
			Timer.tempo.time -= Timer.tempo.MoreLessTime;
			source.PlayOneShot(audios[0]);
			score -= 2;
		}

		if (col.gameObject.tag == "Food") {
			Timer.tempo.time += Timer.tempo.MoreLessTime;
			source.PlayOneShot(audios[1]);
			score += 2;
		
		}

		score_texture.text = "Your Score: " + score.ToString(); //score number to texture in display
		Destroy (col.gameObject);
	}
}
