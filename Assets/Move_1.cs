using UnityEngine;
using System.Collections;

public class Move_1 : MonoBehaviour {

	public float speed = 3.0F;
	public float rotateSpeed = 3.0F;
	public int ang;

	Animator anim;
	CharacterController controller;
	Vector3 movement;
	Quaternion quat;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		controller = GetComponent<CharacterController>();
		quat = Quaternion.AngleAxis (ang, Vector3.up);
	}
	
	// Update is called once per frame
	void Update () {
		// remove from update when ang is set 
		quat = Quaternion.AngleAxis (ang, Vector3.up);

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		movement.Set (h, 0f, v);
		// .normalized -> return vector with magnitude=1, avoid magnitude increase when two coord=1
		movement = movement.normalized * speed * 50 * Time.deltaTime;
		// rotate vector
		movement = quat * movement;
		//Debug.DrawLine(Vector3.zero, movement, Color.red);

		controller.SimpleMove(movement);
		
		//if (!((h) == 0) || !((v) == 0)) {
		if ( h != 0f || v != 0f ) {
			anim.SetBool ("isWalking", true);
		} else {
			anim.SetBool ("isWalking", false);
		}

		//transform.Rotate(0, f, 0);

	}
}
