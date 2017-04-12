using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {


	public GameObject currentCheckpoint;

	private MainPlayerController player;

	public float respawnDelay;
	public GameObject deathParticle;
	public int pointPenaltyOnDeath;
	public float deathanimDelay;



	public HealthManager healthManager;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<MainPlayerController>();

		healthManager = FindObjectOfType<HealthManager>();
	}
	// Update is called once per frame
	void Update () {

	}
	public void RespawnPlayer () 
	{
		StartCoroutine("RespawnPlayerCo");
	}
	public IEnumerator RespawnPlayerCo() 
	{
		//added this
		yield return new WaitForSeconds(respawnDelay);
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds(respawnDelay);
		player.transform.position = currentCheckpoint.transform.position;
		ScoreManager.AddPoints(-pointPenaltyOnDeath);
		player.enabled = true;
		player.GetComponent<Renderer>().enabled = true;
		healthManager.FullHealth();
		healthManager.isDead = false;
	}
}
