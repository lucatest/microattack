using UnityEngine;
using System.Collections;

public class Zombu : Enemy {

	// Inherited from Enemy:
	//
	// Transform target;
	// float speed;
	// int start_energy;
	// int decr_energy;
	// Vector3 start_pos;
	// Look(CharacterController, Transform, float)
	// start_wave(int, int, int)

	public AudioClip death;

	GameObject player;
	Life life;
	Animator anim;
	CharacterController contr;
	
	float step;
	bool start = false;
	bool live = true;
	float att_time;		//min time between two attack
	float time;

	AudioSource audio;

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
		audio = GetComponent<AudioSource> ();
		contr = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Follow ();
	}

	void FixedUpdate (){
		//Follow ();
	}

	void Follow(){
		if (life.PlayerStat()){
			if (live){
				Look (contr, target, speed);
			}
		}else{
			anim.SetTrigger("idle");
		}
	}

	void OnCollisionStay(Collision coll){
		if (Time.time - time > att_time && coll.gameObject.name == "Player" && live && life.PlayerStat()) {
			Debug.Log ("ASD");
			life.DecrEnergy (30);
			time=Time.time;
		}
	}


	void end(){
		Destroy(gameObject);
	}

	public void DecrEnergy (){
		start_energy -= decr_energy;
		audio.Play ();
		if (start_energy <= 0) {
			contr.enabled=false;
			Death ();
		}
	}

	void Death(){
		live = false;
		audio.clip = death;
		audio.Play ();
		anim.SetTrigger("die");
	}

}