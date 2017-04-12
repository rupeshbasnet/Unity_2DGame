using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {


	public int damageToGive;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "MainPlayer")
		{
			HealthManager.HurtPlayer(damageToGive);
			other.GetComponent<AudioSource>().Play();

			var MainPlayer = other.GetComponent<MainPlayerController>();

			MainPlayer.knockbackCount = MainPlayer.knockbackLength;

			if(other.transform.position.x < transform.position.x)
				MainPlayer.knockFromRight = true;
			else 
				MainPlayer.knockFromRight = false;

		}

	}
}
