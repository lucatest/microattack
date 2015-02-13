using UnityEngine;
using System.Collections;

public class raycast_from_player : MonoBehaviour {
	Ray ray;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") ) {

			ray.origin = transform.position;
			ray.direction = transform.forward;
			Debug.DrawRay(ray.origin, ray.direction, Color.red, 10f, false);
		}
	}
}
