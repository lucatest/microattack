using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	public AudioClip death;

	Animator anim;
	int energy;			// amount of energy
	int sps;			// shoot per second
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
		Debug.Log ("DEATH");
		anim.SetTrigger("Die");
	}

	public void DecrEnergy (int dec){
		energy = energy - dec;
		audio.Play ();
		Debug.Log (energy);
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
