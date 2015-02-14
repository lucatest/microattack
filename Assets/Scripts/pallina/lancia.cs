using UnityEngine;
using System.Collections;

public class lancia : MonoBehaviour {
	bool a=true;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(a){
			rigidbody.AddExplosionForce(80f, transform.position + new Vector3(0.1f,-0.2f,1f), 0.3f);
			//Debug.Log("asd");
			a=false;
		}
	}
}
