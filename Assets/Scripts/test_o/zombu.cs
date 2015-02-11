using UnityEngine;
using System.Collections;

public class Zombu : Enemy {
	GameObject player;
	Life life;
	Animator anim;
	
	float step;
	bool start = false;
	bool live = true;
	float att_time;		//min time between two attack
	float time;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		anim = GetComponent <Animator> ();
		target = player.GetComponent <Transform> ();
		life = player.GetComponent <Life> ();
		step = speed * Time.deltaTime;
		anim.SetBool ("isWalking", true);
		time = Time.time;
		att_time = 2f;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate (){
		Follow ();
	}

	void Follow(){
		if (life.PlayerStat()){
			if (start && live){
				// follow the player
				Look (target, step);
			} else{
				// go out from the base, defined in start_pos
				transform.position = Vector3.MoveTowards(transform.position, start_pos, step);
				if (transform.position == start_pos){
					start=true;
				}
			}
		}else{
			anim.SetTrigger("idle");
		}

	}

	void OnCollisionStay(Collision coll){
		if (Time.time - time > att_time && coll.gameObject.name == "Player" && live) {
			life.DecrEnergy (30);
			time=Time.time;
		}
		/*
		if (coll.gameObject.name == "Player") {
			live=false;
			anim.SetTrigger("die");
			//Destroy(gameObject);	
		}
		*/
	}


	void end(){
		Destroy(gameObject);
	}

}