using UnityEngine;
using System.Collections;

public class transf : MonoBehaviour {
	public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Con un controllo così, se il player collide lo puo spingere lontano

		transform.LookAt (target);
		transform.position = Vector3.MoveTowards(transform.position, target.position, 1f*Time.deltaTime);
	}
}
