	using System;
using UnityEngine;
//card bridge display script 

public class CardModel2 : MonoBehaviour {

	/*
	 * VALORES DOS IDs
	0 = [0]
	1 = [52,13,26,39]
	2 = [1,14,27,40]
	3 = [2,15,28,41]
	4 = [3,16,29,42]
	5 = [4,17,30,43]
	6 = [5,18,31,44]
	7 = [6,19,32,45]
	8 = [7,20,33,46]
	9 = [8,21,34,47]
	10= [9,22,35,48,10,11,12,23,24,25,36,37,38,49,50,51]
	*/
	public int[] valueCards = new int[53];
	public Sprite[] faces;
	public Sprite cardBack;
	SpriteRenderer spriteRenderer;
	public int idCard;

	void Start(){
		for (int i = 0; i < 53; i++) {
		
			if (i < 9) {
				valueCards [i] = i + 1; 
			} else if (i > 12 && i <= 22) {
				valueCards [i] = i - 12; 
			} else if (i > 25 && i <= 35) {
				valueCards [i] = i - 25; 
			} else if (i > 38 && i <= 48) {
				valueCards [i] = i - 38; 
			} else if (i == 52 || i == 13 || i == 26 || i == 39) {
				valueCards [i] = 1;
			} else {
				valueCards [i] = 10;
			}
		

		}
	}

	public void ToggleFace(bool showFace) {
		if (showFace) {

			//mostra a face da carta
			spriteRenderer.sprite = faces[idCard];


		} else {
			
			//mostra as costas da carta
			spriteRenderer.sprite = cardBack;
		
		}
	}

	void Awake (){
		spriteRenderer = GetComponent<SpriteRenderer> ();
	
	}
}
