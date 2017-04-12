using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {


	public float speed;

	public MainPlayerController mainplayer;

	public GameObject enemyDeathEffect;

	public int pointsForKill;

	public int damageToGive;
	// Use this for initialization
	void Start () {
		mainplayer = FindObjectOfType<MainPlayerController>();
	

		if (mainplayer.transform.localScale.x < 0)
		{
			Flip();
			//transform.localScale = (-transform.localscale.x, transform.localscale.y, transform.localscale.z);
			speed = -speed;
		}
	}
	
	// Update is called once per frame
	void Update () {



		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		//check for the enemy

		if (other.tag == "Enemy")
		{

			//Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy(other.gameObject);
			//ScoreManager.AddPoints(pointsForKill); 
			other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
		
		}


		Destroy (gameObject);

	}





	void Flip () 
	{

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
