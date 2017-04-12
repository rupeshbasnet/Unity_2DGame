using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	//two things
	//movespped and determine wheather he goes left or right

	public float moveSpeed;
	public bool moveRight;
	Animator anim;
	bool attack;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;

	public float playerRange;


	public MainPlayerController player;

	void Start () {
		 attack = false;
		anim = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {

		hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall)
			moveRight = !moveRight;


		if(moveRight) 
		{
			transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);

			GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);


		} else 
		{
			transform.localScale = new Vector3 (-1.5f, 1.5f, 1.5f);

			GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

		}


	}
}
