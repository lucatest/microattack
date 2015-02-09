using UnityEngine;
using System.Collections;

public class zombu : enemy {
	float step;
	Animator anim;
	bool start = false;
	Vector3 start_pos;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		target = GameObject.Find("Player").GetComponent <Transform> ();
		step = speed * Time.deltaTime;
		anim.SetBool ("isWalking", true);
		start_pos.Set (19.5f, 0.1f, 12.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (start){
			Look (target, step);
		} else{
			transform.position = Vector3.MoveTowards(transform.position, start_pos, step);
			if (transform.position == start_pos){
				start=true;
			}
		}
	}
}