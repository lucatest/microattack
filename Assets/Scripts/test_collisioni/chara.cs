using UnityEngine;
using System.Collections;

public class chara : MonoBehaviour {

	CharacterController controller;
	public Transform target;
	Vector3 movement;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Settare bene le dimensioni del Character controller e Del Collider, altrimenti si muove male
		// o si aggancia al player al contatto

		transform.LookAt (target);
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		
		controller.SimpleMove(forward*20f*Time.deltaTime);
	}
}
