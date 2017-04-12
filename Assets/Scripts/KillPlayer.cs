using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {


	public LevelManager levelManager;   //creates an empty levelmanager of the 
										//type levelmanager

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>(); //finds any objects in the game that has LevelManager on it and puts it into the levelManager
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "MainPlayer")
		{
			levelManager.RespawnPlayer();

		}

	}

}
