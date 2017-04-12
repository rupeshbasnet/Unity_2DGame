using UnityEngine;
using System.Collections;

public class EnemyBehavoiur : MonoBehaviour {

	public float playerRange;

	public MainPlayerController player;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<MainPlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (new Vector3 (transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3 (transform.position.x + playerRange, transform.position.y, transform.position.z));
	}
}
