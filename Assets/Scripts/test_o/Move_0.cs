using UnityEngine;
using System.Collections;

// Horizontal contol (a-d) -> rotate
// Vertical control (w-s) -> move 

public class Move_0 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		Debug.Log (anim.applyRootMotion);
	}

	public float speed = 3.0F;
	public float rotateSpeed = 3.0F;
	Animator anim;
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(Input.GetAxis("Vertical"));
		CharacterController controller = GetComponent<CharacterController>();
		transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
		Vector3 forward = transform.TransformDirection(Vector3.forward);

		float curSpeed = speed * Input.GetAxis("Vertical");
		controller.SimpleMove(forward * curSpeed);

		if (!(Input.GetAxis ("Vertical") == 0)) {
			//Debug.Log("asd");
			anim.SetBool ("isWalking", true);
		} else {
			anim.SetBool ("isWalking", false);
		}

	}
}
