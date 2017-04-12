using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {

	private MainPlayerController thePlayer;


	public float moveSpeed;

	public float playerRange;
	public LayerMask playerLayer;

	public bool playerInRange;

	Animator anim;

	// Use this for initialization

	void Start () {
		thePlayer = FindObjectOfType<MainPlayerController>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);

		if(anim.GetBool("Attack"))
			anim.SetBool("Attack", false);
		
		if (playerInRange)
		{
			anim.SetBool("Attack", true);
		}
		if (!playerInRange)
		{
			anim.SetBool("Attack", false);
		}
		transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
	
		if(thePlayer.transform.position.x < transform.position.x )
		{
			transform.localScale = new Vector3 (-1.5f, 1.5f, 1.5f);
		}
		if(thePlayer.transform.position.x > transform.position.x )
		{
			transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
		}

		//if(thePlayer.transform.position.x < transform.position.x )
		//{
		//	Flip();
		//}
	}

	void OnDrawGizmosSelected () {
	
		Gizmos.DrawSphere (transform.position, playerRange);
	
	}


}
