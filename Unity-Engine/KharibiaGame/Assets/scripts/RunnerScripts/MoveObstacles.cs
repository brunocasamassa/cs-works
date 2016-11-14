using UnityEngine;
using System.Collections;

public class MoveObstacles : MonoBehaviour {

    public float speed;
    private float x;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        x = transform.position.x;
		x += Sincronia.instancia.tempo;
		transform.position = new Vector3(x, transform.position.y, transform.position.z);

		if (x <= -10){
            Destroy(transform.gameObject);
        }
	}
}
