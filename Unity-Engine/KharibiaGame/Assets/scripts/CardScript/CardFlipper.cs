using UnityEngine;
using System.Collections;

public class CardFlipper : MonoBehaviour {
	
	SpriteRenderer spriteRenderer;
	CardModel2 model;

	public AnimationCurve scaleCurve;
	public float duration = 0.5f;

	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		model = GetComponent<CardModel2> (); // equals CardModel2 model = new CardModel2();



	}


	public void FlipCard(Sprite startImage , Sprite endImage, int idCard){
		StopCoroutine (Flip(startImage, endImage, idCard));
		StartCoroutine (Flip(startImage, endImage, idCard));

	}


	IEnumerator Flip(Sprite starImage, Sprite endImage, int idCard)
	{
		spriteRenderer.sprite = starImage;

		float time = 0f;
		while (time <= 1f) 
		{

			float scale = scaleCurve.Evaluate (time);
			time = time * Time.deltaTime / duration;
		
			Vector3 localScale = transform.localScale;
			localScale.x = scale;
			transform.localScale = localScale;


			if (time >= 0.5f) 
			{
				
				spriteRenderer.sprite = endImage;

			}

			yield return new WaitForFixedUpdate ();
		}

		if (idCard == -1) {
		
			model.ToggleFace (false);
		} 
		else 
		{
			model.idCard = idCard;
			model.ToggleFace (true);
		}
	}
}
