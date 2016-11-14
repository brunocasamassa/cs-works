using UnityEngine;
using System.Collections;

public class MegaCam : MonoBehaviour {
	public GameObject player;
	public Vector3 ajust;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 postogo =  new Vector3 (player.transform.position.x,
			player.transform.position.y, transform.position.z);
		
		//modofixo
		//transform.position = Vector3.Lerp (transform.position, 
			//postogo+ajust, Time.deltaTime);

		//progressivo
		transform.position+=((postogo+ajust)-transform.position)*Time.deltaTime;
	}

}
