using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {
	//http://answers.unity3d.com/questions/559763/raycast-doesnt-hit-character-controller.html
	// need to use capsule collider on enemy to work with enemy controlled by CharacterController...

	float sps;						// time between shoot
	float line_time;				// line&light duration
	AudioSource audio;

	public AudioClip shoot_audio;

	GameObject gunEnd;
	Ray ray;
	RaycastHit hit;
	int layerMask;
	ParticleSystem particles;
	LineRenderer line;
	Light light;
	float effectsDisplayTime = 3.2f;
	float timer;
	Zombu zombu;

	// Use this for initialization
	void Start () {
		gunEnd = GameObject.Find ("GunBarrelEnd");
		particles =  GetComponentInChildren<ParticleSystem> ();
		line = GetComponentInChildren<LineRenderer> ();
		light = GetComponentInChildren<Light> ();
		audio = GetComponent<AudioSource> ();
		sps = 0.2f;
		line_time = 0.1f;
		layerMask = LayerMask.GetMask ("shootable");
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Input.GetButton ("Fire1") && timer >= sps) {
			timer=0f;
			light.enabled=true;
			particles.Play ();
			audio.clip=shoot_audio;
			audio.Play ();
			line.enabled=true;
			line.SetPosition(0, transform.position);
			ray.origin = transform.position;
			ray.direction = transform.forward;
			if(Physics.Raycast (ray, out hit, 100, layerMask)){
				// line renderer -> use World Space coordinates
				line.SetPosition (1, hit.point);
				//enemyName = hit.collider.gameObject.name;
				Zombu zombu = hit.collider.gameObject.GetComponent<Zombu> ();
				if ( zombu ){
					zombu.DecrEnergy(hit.point);
				}
			}else{
				line.SetPosition (1, ray.origin + ray.direction * 100);
			}
		}
		if (light.enabled && timer >= line_time) {
			light.enabled=false;
			line.enabled=false;
		}
	}
}
