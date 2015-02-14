using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public Transform target;
	public float speed;
	public int start_energy;
	public int decr_energy;

	Transform [] ene;
	
	float [] inst_time;
	float step_time;
	int[,] wave_inf = new int[3, 2];
	bool enemyInScene;
	bool moreEnemy;
	
	// Use this for initialization
	void Start () {
		ene = new Transform[3];

		// Taken from the prefab in Resources folder, leave inactive Enemy GameObject in scene!!
		// Change something in the enemy in scene then press 'Apply' to apply the change in the Resources prefab
		// Remember to apply change with GameObject activated, then disable.
		ene[0] = Resources.Load<Transform>("zoombun");
		ene[1] = Resources.Load<Transform>("zoombea");
		ene[2] = Resources.Load<Transform>("hellep");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		WaveControl ();
	}
	 
	public void StartWave(int enemy, int num, int deltaTime, bool startWithEnemy){
		inst_time = new float[] {Time.time, Time.time, Time.time};
		enemyInScene = true;
		if (startWithEnemy) {
			Instantiate (ene[enemy]);
			wave_inf [enemy, 0] = num - 1;
		}else{
			wave_inf [enemy, 0] = num;
		}
		wave_inf [enemy, 1] = deltaTime;
	}

	void WaveControl(){
		int count = 0;
		for (int i = 0; i < 3; i++) {
			if (wave_inf [i,0] != 0) {
				EnemyWave(i, wave_inf [i,0], wave_inf[i,1]);
				count = 1;
			}
		}
		moreEnemy = count == 0 ? false : true;
	}
	
	void EnemyWave(int enemy, int num, int delta){
		if ((Time.time - inst_time[enemy]) >= delta) {
			inst_time[enemy] = Time.time;
			Instantiate (ene[enemy]);
			wave_inf[enemy,0] --;
		}
	}

	public void Look ( CharacterController contro, Transform target, float speed){
		transform.LookAt (target);
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		contro.SimpleMove(forward* speed * 50f * Time.deltaTime);
	}

	public bool EnemyInScene {
		get{
			if (moreEnemy){
				return true;
			}else{
				// Si potrebbe avere una var statica su Zombu che ++ ad ogni istanza su start e -- a Destroy
				GameObject[] enemy;
				enemy = GameObject.FindGameObjectsWithTag ("enemy");
				return enemy.Length != 0 ? true : false;
			}
		}
	}

}
