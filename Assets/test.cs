using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	public Transform target;
	public float speed;
	//public Transform zoombun;
	//public Transform zoombea;
	//public Transform helleph;
	
	public Transform[] ene;
	
	float inst_time;
	float step_time;
	int[,] wave_inf = new int[3, 2];
	
	
	// Use this for initialization
	void Start () {
		inst_time = Time.time;
		//start an enemy wave with 5 enemy, create every 2 second
		start_wave (5, 2);
		//wave_inf [0,0] = 0;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (wave_inf [0,0] != 0) {
			//Debug.Log("ggg");
			EnemyWave(wave_inf [0,0], wave_inf[0,1]);
		}
	}
	
	// aggiungere int enemy e poi si cicla 
	void start_wave(int num, int delta){
		Instantiate (ene[0]);
		//wave_inf = new int[2];
		wave_inf [0,0] = num - 1;
		wave_inf [0,1] = delta;
		
	}
	
	void EnemyWave( int num, int delta){
		if ((Time.time - inst_time) >= delta) {
			inst_time = Time.time;
			Instantiate (ene[0]);
			wave_inf[0,0] --;
		}
	}
	
	
	public void Look (Transform target, float step){
		transform.LookAt (target);
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
