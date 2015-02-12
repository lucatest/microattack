using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	public AudioClip death;
	public AudioClip hurt;

	Animator anim;
	int energy;			// amount of energy
	bool live;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		energy = 100;
		live = true;
		audio = GetComponent<AudioSource> ();
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Death (){
		anim.SetTrigger("Die");
	}

	public void DecrEnergy (int dec){
		energy -= dec;
		audio.clip = hurt;
		audio.Play ();
		if (energy <= 0) {
			live=false;
			audio.clip = death;
			audio.Play ();
			Death ();
		}
	}

	public bool PlayerStat(){
		return live;
	}
}
