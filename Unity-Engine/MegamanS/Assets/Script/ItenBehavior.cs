using UnityEngine;
using System.Collections;

public class ItenBehavior : MonoBehaviour {
	public SpriteRenderer mySprite;
	public Material blinkMat;
	Material originalMat;
	public GameObject explosion;
	public int lives=1;


	void Start(){
		originalMat = mySprite.material;
	}

	void ReturnToColor(){
		mySprite.material = originalMat;
		//mySprite.color = Color.white;
	}
	void OnCollisionEnter2D(Collision2D col){
		if (lives < 0) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
		if (col.relativeVelocity.magnitude > 10) {
			lives--;	
			mySprite.material = blinkMat;
			//mySprite.color = Color.red;
			Invoke ("ReturnToColor", 0.1f);

		}
	}
}
