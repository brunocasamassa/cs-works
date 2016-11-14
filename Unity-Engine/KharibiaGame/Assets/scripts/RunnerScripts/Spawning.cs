using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

    public GameObject[] barreiraPrefab;
    public float minSeg, maxSeg; //tempo para cada objeto instanciado
    public float currentTime;
    private int posicao;
	private float y, randomRateSpawn;
    public float posA, posB;

    // Use this for initialization

    void Start(){
		SetRandomTime ();
		currentTime = minSeg;
    }

    // Update is called once per frame

    void Update(){

        currentTime += Time.deltaTime;

		if (currentTime >= randomRateSpawn){
			SpawnObject ();
			SetRandomTime ();
        }

    }

	void SetRandomTime(){
		randomRateSpawn = Random.Range (minSeg, maxSeg);
	}

	void SpawnObject(){
		GameObject objeto;

		currentTime = 0;

		objeto = barreiraPrefab[Random.Range(0, barreiraPrefab.Length)];

		Instantiate(objeto);

		if (objeto.gameObject.tag == "Rock"){
			y = posA;
			objeto.transform.position = new Vector3(transform.position.x, y, transform.position.z);
		}

		if (objeto.gameObject.tag == "Bird"){
			y = posB;
			objeto.transform.position = new Vector3(transform.position.x, y, transform.position.z);
		}
	}

}
