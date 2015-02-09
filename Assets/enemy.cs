using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	public Transform target;
	public float speed;



	// Use this for initialization
	void Start () {
		//target = GameObject.Find("Player").GetComponent <Transform> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Look (Transform target, float step){
		transform.LookAt (target);
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
