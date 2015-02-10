using UnityEngine;
using System.Collections;

public class ray_test : MonoBehaviour {
	public Transform target;
	Quaternion quat;

	// Use this for initialization
	void Start () {
		//target = GetComponent <Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		ray1 ();
		ray2 ();
		ray3 ();
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

	void ray3 (){
		// draw a 2pt black line from Player to forward direction and a red one with 90 degree angle
		Ray ray = new Ray (transform.position, transform.forward);
		Debug.DrawLine(ray.origin, ray.GetPoint (2), Color.black);
		quat = Quaternion.AngleAxis (90, Vector3.up);
		Ray ray2 = new Ray (transform.position, quat * transform.forward );
		Debug.DrawLine(ray2.origin, ray2.GetPoint (2), Color.red);
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
