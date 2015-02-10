using UnityEngine;
using System.Collections;

public class hellep : Enemy {
	float step;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		target = GameObject.Find("Player").GetComponent <Transform> ();
		step = speed * Time.deltaTime;
		anim.SetBool ("isWalking", true);
	}
	
	// Update is called once per frame
	void Update () {
		Look (target, step);
	}
}
