using UnityEngine;
using System.Collections;

public class Parallex : MonoBehaviour {


	public Transform[] foregrounds;
	private float [] parallaxScales;
	public float smoothing;

	private Transform cam;

	private Vector3 previousCamPos;


	// Use this for initialization
	void Start () {
		cam = Camera.main.transform;

		previousCamPos = cam.position;


		parallaxScales = new float[foregrounds.Length];

		for(int i = 0; i < foregrounds.Length; i++)
		{

			parallaxScales [i] = foregrounds[i].position.z * -1;

		}
			

	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		for (int i = 0; i < foregrounds.Length; i++)
		{
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			float foregroundTargetPosX = foregrounds[i].position.x + parallax;

			Vector3 foregroundTargetPos = new Vector3 (foregroundTargetPosX, foregrounds[i].position.y, foregrounds[i].position.z);

			foregrounds[i].position = Vector3.Lerp (foregrounds[i].position, foregroundTargetPos, smoothing * Time.deltaTime);
		}
		previousCamPos = cam.position;

	}
}
