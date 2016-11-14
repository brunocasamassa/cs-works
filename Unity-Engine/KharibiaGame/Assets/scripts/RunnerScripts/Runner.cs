using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

    public LayerMask whatIsGround;
    public Transform colisor, groundColisor;
    public Animator animator;
    public Transform GroundCheck;
    public Rigidbody2D playerRigidbody;
    public int forceJump;
    public float dashTemp;
    bool dash;
    bool grounded;   
    private float timeTemp;
	[SerializeField] AudioSource source;
	[SerializeField] AudioClip[] audios;
	[SerializeField] TextMesh score_texture;
	float score;


    // Use this for initialization
    void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		score += Timer.tempo.time / 1000;

		//converting to an int variable (remove decimals)
		int int_score = (int)score;
		score_texture.text = "Prize: " + int_score.ToString();
        
		if (Input.GetButtonDown("Jump") && grounded){
            playerRigidbody.AddForce(new Vector2(0, forceJump));
			source.PlayOneShot (audios [0]);	
            if (dash){
                colisor.position = new Vector3(colisor.position.x, (colisor.position.y + 0.298f), colisor.position.z);
                groundColisor.position = new Vector3(groundColisor.position.x, (groundColisor.position.y - 0.3f), groundColisor.position.z);
                dash = false;
            }
            
        }

        if (Input.GetButtonDown("Dash") && grounded && !dash){
			colisor.position = new Vector3(colisor.position.x, (colisor.position.y - 0.298f), colisor.position.z);
            groundColisor.position = new Vector3(groundColisor.position.x, (groundColisor.position.y + 0.3f), groundColisor.position.z);
            dash = true;
            timeTemp = 0;
        }

        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.02f, whatIsGround);

        if (dash){
            timeTemp += Time.deltaTime;
            if (timeTemp >= dashTemp) {
				colisor.position = new Vector3(colisor.position.x, (colisor.position.y + 0.298f), colisor.position.z);
                groundColisor.position = new Vector3(groundColisor.position.x, (groundColisor.position.y - 0.3f), groundColisor.position.z);
                dash = false;
            }
        }

        animator.SetBool("jump", !grounded);
        animator.SetBool("dash", dash);

    }

    void OnTriggerEnter2D(){
		print ("bateu");
		source.PlayOneShot (audios [1]);
		Timer.tempo.time -= 5;
		score -= 5;
		//Application.LoadLevel ("gameover");
    }


}
