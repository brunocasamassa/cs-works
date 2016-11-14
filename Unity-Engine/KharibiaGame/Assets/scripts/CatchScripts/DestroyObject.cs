using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
	}
}
