using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	public Transform target;
	public float speed;
	public Transform zoombun;

	float inst_time;
	float step_time;
	int[] wave_inf;


	// Use this for initialization
	void Start () {
		inst_time = Time.time;
		//start an enemy wave with 5 enemy, create every 2 second
		start_wave (5, 2);
	}
	
	// Update is called once per frame
	void Update () {

		if (wave_inf [0] != 0) {
			EnemyWave(wave_inf[0],wave_inf[1]);
		}

	}

	void start_wave( int num, int delta){
		wave_inf = new int[2];
		wave_inf [0] = num;
		wave_inf [1] = delta;
	}

	void EnemyWave( int num, int delta){
		if ((Time.time - inst_time) >= delta) {
			inst_time = Time.time;
			Instantiate (zoombun);
			wave_inf[0] --;
		}

	}


	public void Look (Transform target, float step){
		transform.LookAt (target);
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
