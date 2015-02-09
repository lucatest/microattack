using UnityEngine;
using System.Collections;

public class ray_test : MonoBehaviour {
	public Transform target;

	// Use this for initialization
	void Start () {
		//target = GetComponent <Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		ray1 ();
		ray2 ();
		ray4 ();
		ray5 ();
	}
	
	void ray1 (){
		// draw a 5pt. line from Player to a DIRECTION, not a point!!
		Ray ray = new Ray (transform.position, new Vector3(1,0,0));
		Debug.DrawLine(ray.origin, ray.GetPoint (5), Color.red);
	}
	
	void ray2(){
		// yellow ray from Mouse to (0,0,0)
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawLine(ray.origin, new Vector3(0,0,0), Color.yellow);
	}

	void ray4(){
		// green ray from Player to Mouse pointer
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawLine(ray.origin, transform.position, Color.green);
	}
	void ray5(){
		// draw a line from a Object to Player, no need to ray
		Debug.DrawLine(transform.position, target.position, Color.blue);
		target.LookAt (transform);
	}
}
