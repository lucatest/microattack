using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Life : MonoBehaviour {

	public AudioClip death;
	public AudioClip hurt;

	public Slider healthSlider;
	public Image damageImage;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public float flashSpeed = 5f;
	bool damage;

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
		healthSlider.value = energy;
	}
	
	// Update is called once per frame
	void Update () {

		DamageImage ();
	}

	void DamageImage(){
		if (damage) {
			damageImage.color = flashColour;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime); 
		}
		damage = false;
	}

	void Death (){
		anim.SetTrigger("Die");
	}

	public void DecrEnergy (int dec){
		damage = true;
		energy -= dec;
		healthSlider.value = energy;
		audio.clip = hurt;
		audio.Play ();
		if (energy <= 0) {
			live=false;
			audio.clip = death;
			audio.Play ();
			Death ();
		}
	}


	public bool PlayerStat{
		get{
			return live;
		}
	}
}
