using UnityEngine;
using System.Collections;

public class DebugChangeCard : MonoBehaviour{

	public CardModel2[] cardsInTable = new CardModel2[3];
	public CardModel2[] cardsInHand = new CardModel2[2];
	int idCard, i, cont, tableScore, handScore, totalScore , target= 0;
	int[] newId = new int[3];
	[SerializeField] AudioSource source;
	[SerializeField] AudioClip[] audios ;
	[SerializeField] TextMesh[] texture_numbers;


	void Start(){	
		
	//GENERATING HAND CARDS
		while (cont < 2) {
			idCard=Random.Range(1,52);
			newId [cont] = idCard;
			cardsInHand [cont].idCard = newId[cont];
			cardsInHand [cont].ToggleFace (true);
			handScore += cardsInHand[cont].valueCards[idCard];  
			cont++;
			texture_numbers[1].text = handScore.ToString();
		}
		target = Random.Range (handScore + 5, handScore + 25);  //Melhor range de targets
		texture_numbers[0].text = target.ToString();

		cont = 0;
		while (cont < 3) {
			cardsInTable [cont] = cardsInTable[cont];
			cont++;
		}

	}
	//BUTTON TREATMENTS	
	void OnGUI(){
		if (GUI.Button (new Rect (10, 10, 150, 28), "ONE MORE CARD")) {
			idCard = Random.Range (1, 52);
			newId [i] = idCard;
			cardsInTable [i].idCard = newId [i];
			cardsInTable [i].ToggleFace (true);
			source.PlayOneShot (audios [0]);
			tableScore += cardsInTable [i].valueCards [idCard];	
			i++;
			totalScore = tableScore + handScore;
			texture_numbers[1].text = totalScore.ToString();
			if (totalScore == target) {
				print ("Rock On");
				//TODO implementar paradas
			}
			if (totalScore > target) {
				print("Better Next Time");
				//TODO implementar parada
			}
				

		}
		if (GUI.Button (new Rect (200, 10, 100, 28), "HOLD UP")) {
			
				print ("Right Choice");
				//TODO implementar parada
			}

		}
	}
