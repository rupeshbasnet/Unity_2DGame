using UnityEngine;
using System.Collections;

public class NewController : MonoBehaviour {


	public float moveSpeed;
	public float jumpHeight;
	public Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {
		rigidbody2D = this.GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
		{
			rigidbody2D.velocity = new Vector2(0, jumpHeight);

		}
	}
}
