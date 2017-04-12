using UnityEngine;
using System.Collections;

public class MainPlayerController : MonoBehaviour 
{
	public float maxSpeed = 10f;


	bool facingright = true;

	public Rigidbody2D rigidbody2D;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;


	public Transform firePoint;
	public GameObject bullet;
	public Transform MuzzelFlashPrefab;


	public float shotDelay;
	private float shotDelayCounter;


	public float knockback;
	public float knockbackLength;
	public float knockbackCount;

	float move; 
	//knock to the left or right
	public bool knockFromRight;

	private HealthManager playerH;

	// Use this for initialization
	void Start () 
	{
		rigidbody2D = this.GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		playerH = FindObjectOfType<HealthManager>();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		//move = Input.GetAxis ("Horizontal");
		Move (Input.GetAxis ("Horizontal"));

		anim.SetFloat ("Speed", Mathf.Abs(move)); 



		if(knockbackCount <= 0)
		{
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		} else {
			if(knockFromRight)
				rigidbody2D.velocity = new Vector2 (-knockback, knockback);
			if (!knockFromRight)
				rigidbody2D.velocity = new Vector2(knockback, knockback);
			knockbackCount -= Time.deltaTime;


		} 

		if (move > 0 && !facingright)
			Flip();
		else if (move < 0 && facingright)
			Flip();

	}

	void Update ()


	{
		

		if(anim.GetBool("Dead"))
			anim.SetBool("Dead", false);


		if (playerH.isDead)
		{
			anim.SetBool ("Dead", true);

		}
		#if UNITY_STANDALONE || UNITY_WEBPLAYER

		if(grounded && Input.GetKeyDown(KeyCode.UpArrow))
		{
			anim.SetBool ("Ground", false);

			Jump(); 
			//rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}


		if(Input.GetKeyDown(KeyCode.Return))
		{
			FireBullet();
			//Instantiate (bullet, firePoint.position, firePoint.rotation);
			shotDelayCounter = shotDelay;
			Transform clone = Instantiate (MuzzelFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
			clone.parent = firePoint;
			float size = Random.Range (0.1f, 0.1f);  //with minimum size and max size random
			clone.localScale = new Vector3 (size, size, size);
			//wait 1 frame and destroy
			Destroy (clone.gameObject, 0.02f);
		}

		if(Input.GetKey(KeyCode.Return))
		{
			shotDelayCounter -= Time.deltaTime;

			if(shotDelayCounter <= 0)
			{
				FireBullet();

				shotDelayCounter = shotDelay;
				//Instantiate (bullet, firePoint.position, firePoint.rotation);
				Transform clone = Instantiate (MuzzelFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
				clone.parent = firePoint;
				float size = Random.Range (0.1f, 0.1f);  //with minimum size and max size random
				clone.localScale = new Vector3 (size, size, size);
				//wait 1 frame and destroy
				Destroy (clone.gameObject, 0.02f);

			}
		}

		#endif

	}
	public void Move (float moveInput)
	{
		move = moveInput;
	}

	public void FireBullet() 

	{
		Instantiate (bullet, firePoint.position, firePoint.rotation);

	}

	public void Jump() 
	{
		if(grounded)
		{
			anim.SetBool ("Ground", false);


			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}

		//rigidbody2D.AddForce(new Vector2(0, jumpForce));

	}


	void Flip () 
	{
		facingright = !facingright;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
