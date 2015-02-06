using UnityEngine;
using System.Collections;

// Horizontal & Vertical axis (w-a-s-d) to move
// Mouse to rotate

public class Move_1 : MonoBehaviour {

	public float speed = 3.0F;
	public int ang;
	public float ang_speed;

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
		move ();
		rotate ();
	}

	void move (){
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		movement.Set (h, 0f, v);

		// .normalized -> return vector with magnitude=1, avoid magnitude increase when two coord=1
		movement = movement.normalized * speed * 50 * Time.deltaTime;

		// rotate vector
		movement = quat * movement;

		//Debug.DrawLine(Vector3.zero, movement, Color.red);
		
		controller.SimpleMove(movement);
		if ( h != 0f || v != 0f ) {
			anim.SetBool ("isWalking", true);
		} else {
			anim.SetBool ("isWalking", false);
		}
	}

	void rotate (){
		// http://wiki.unity3d.com/index.php?title=LookAtMouse

		// Generate a plane that intersects the transform's position with an upwards normal.
		Plane playerPlane = new Plane(Vector3.up, transform.position);
		
		// Generate a ray from the cursor position
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		// Determine the point where the cursor ray intersects the plane.
		// This will be the point that the object must look towards to be looking at the mouse.
		// Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
		//   then find the point along that ray that meets that distance.  This will be the point
		//   to look at.
		float hitdist = 0.0f;
		// If the ray is parallel to the plane, Raycast will return false.
		if (playerPlane.Raycast (ray, out hitdist)) 
		{
			// Get the point along the ray that hits the calculated distance.
			Vector3 targetPoint = ray.GetPoint(hitdist);
			
			// Determine the target rotation.  This is the rotation if the transform looks at the target point.
			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			
			// Smoothly rotate towards the target point.
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, ang_speed * Time.deltaTime);
		}
	}
	
}
