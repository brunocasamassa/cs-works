using UnityEngine;
using System.Collections;

public class MoveTexture : MonoBehaviour {

	public float speed = 0, aumentaSpeed = 0;
    private float offset, tempo;
	private Material material;

	// Use this for initialization
	void Start () {
        material = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		tempo = Timer.tempo.time;

		if (tempo > 0) {
			offset += Sincronia.instancia.tempo * speed;
			material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
		}
	}
}
