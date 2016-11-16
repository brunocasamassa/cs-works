using UnityEngine;
using System.Collections;

public class Megamove : MonoBehaviour {
	int cont=0;
	public GameObject obj; 
	[SerializeField] private Animator anim;
	float inputX=0;
	[SerializeField] Rigidbody2D rdb;
	[SerializeField] float velocity=4;
	[SerializeField] GameObject prefabShoot;
	bool walkMotion=true;	
	float rayGround=0;
	float rayWall=0;
	float tempo=0.3f;
	int life =5;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] audios;
	[SerializeField] TextMesh texture_numbers;
	// Use this for initialization


	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		SpawnEnemy();

		inputX = Input.GetAxis ("Horizontal");
		anim.SetFloat ("velocity",Mathf.Abs(inputX));
		Flip ();

		if (Input.GetKeyDown ("x")&&
			anim.GetCurrentAnimatorStateInfo(0).IsName("walk")) {
			anim.SetTrigger ("dash");
			Dash ();
            source.PlayOneShot(audios[0]);
		}

	    //anim.SetBool("shoot",Input.GetButton ("Fire1"));

		if (Input.GetKeyDown ("v")) {
			anim.SetTrigger ("sword");
			walkMotion = false;
			rdb.velocity = Vector3.zero; 
			Invoke ("WalkMotionOn",1f);
			Invoke ("Shoot", 0.3f);
            source.PlayOneShot(audios[1]);
		}
		if (Input.GetButtonDown ("Jump")&&rayGround<0.6f) {
			anim.SetTrigger ("jump");
			rdb.AddForce (Vector2.up * 8, ForceMode2D.Impulse);
            source.PlayOneShot(audios[2]);

        }

		if (Input.GetButtonDown ("Jump")&&rayWall<1f&&rayWall>0) {
			anim.SetTrigger ("jump");
			rdb.AddForce (transform.right * -8, ForceMode2D.Impulse);
			rdb.AddForce (Vector2.up * 8 , ForceMode2D.Impulse);
			walkMotion = false;
			Invoke ("WalkMotionOn",0.4f);
            source.PlayOneShot(audios[2]);
		}
			

	}

	void Shoot(){
		GameObject instance =(GameObject) Instantiate (prefabShoot, transform.position+
			Vector3.up,transform.rotation);
		instance.GetComponent<Rigidbody2D>().AddForce (transform.right*30,
			ForceMode2D.Impulse);
		Destroy (instance, 1);
	}
	void WalkMotionOn(){
		walkMotion = true;
	
	}
	void Dash(){
		velocity = 10;
		Invoke("DashOver", 0.6f);
	}
	void DashOver(){
		velocity = 4;
	}
	void Flip(){
		

		if (inputX > 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}
		if (inputX < 0) {
			transform.rotation = Quaternion.Euler (0, 180, 0);

		}

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (walkMotion) {
			rdb.velocity = new Vector2 (inputX * velocity, rdb.velocity.y);
		}
		
		RaycastHit2D ray =new RaycastHit2D();
		ray = Physics2D.Raycast (transform.position, Vector2.down);
		rayGround = ray.distance;
		anim.SetFloat ("distance", ray.distance);

		RaycastHit2D ray2 =new RaycastHit2D();
		ray2 = Physics2D.Raycast (transform.position, transform.right);
		rayWall = ray2.distance;
		anim.SetFloat ("distWall", ray2.distance);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag  == "MONSTER" ) {
			life--;
			texture_numbers.text = "LIFE: " + life;
			if (life == 0) {
				Destroy (gameObject);
			}

		} 

		

	}


	void SpawnEnemy()
	{	
		
		tempo -= Time.deltaTime;	
		if (tempo < 0) {
			Vector3 spawnPosition = new Vector3 (Random.Range (inputX, 130), 25);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (obj, spawnPosition, spawnRotation);
			tempo = tempo + (float)(0.5f);
		}
	}


}
