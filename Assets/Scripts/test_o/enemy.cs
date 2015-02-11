using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public Transform target;
	public float speed;
	
	public Transform[] ene;
	public Vector3 start_pos;

	
	float inst_time;
	float step_time;
	int[,] wave_inf = new int[3, 2];
	
	
	// Use this for initialization
	void Start () {
		inst_time = Time.time;
		//start an enemy wave with 5 enemy, create every 2 second
		start_wave (0, 5, 2);
		start_wave (2, 1, 2);
		//ene = new Transform[3];
		//wave_inf [0,0] = 0;
		//ene [0] = Resources.Load<Transform> ("zoombu");
		//ene [1] = Resources.Load<GameObject> ("zoombe");
		//ene [2] = Resources.Load<GameObject> ("helle");
		//ene [0] = GameObject.Find ("zoombun").GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		WaveControl ();
	}
	 
	public void start_wave(int enemy, int num, int delta){
		Instantiate (ene[enemy]);
		//Instantiate (Resources.Load<Transform> ("zoombu"));
		wave_inf [enemy, 0] = num - 1;
		wave_inf [enemy, 1] = delta;
	}

	void WaveControl(){
		for (int i = 0; i < 3; i++) {
			if (wave_inf [i,0] != 0) {
				EnemyWave(i, wave_inf [i,0], wave_inf[i,1]);
			}
		}
	}
	
	void EnemyWave(int enemy, int num, int delta){
		if ((Time.time - inst_time) >= delta) {
			inst_time = Time.time;
			Instantiate (ene[enemy]);
			wave_inf[enemy,0] --;
		}
	}
	
	
	public void Look (Transform target, float step){
		transform.LookAt (target);
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
