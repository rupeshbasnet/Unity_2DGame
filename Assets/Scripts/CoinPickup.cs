using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public int pointsToAdd;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<MainPlayerController>() == null)  //if tht is not other
			return;												//for eg enemy then they wont be able to collect the coin and the script will return

		ScoreManager.AddPoints(pointsToAdd);
	
		Destroy (gameObject);
	
	}
}
