using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Logic : MonoBehaviour {

	Enemy enemy;

	public int startZoombunny;
	public int startZoombear;
	public int startHellephant;
	public int incrZoombunny;
	public int incrZoombear;
	public int incrHellephant;
	bool gem;
	bool startedWave;
	int score;
	bool gemCreated;
	float waitTime;
	float gemTime;
	Transform gemObject;

	// Use this for initialization
	void Start () {
		enemy = GameObject.Find ("enemy_class").GetComponent<Enemy> ();
		gem = false;
		gemCreated = false;
		startedWave = false;
		score = 0;
		PlayerPrefs.SetInt("score", score);
		gemObject = Resources.Load<Transform>("sphere");
		waitTime = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		if (gem) {
			ManageGem();
		} else {
			ManageEnemy();
		}
	}

	void ManageGem(){
		if (gemCreated) {
			if (GemInScene () ){
				//wait
				if (Time.time >= waitTime + gemTime){
					GameObject[] gemInScene;
					gemInScene = GameObject.FindGameObjectsWithTag ("gem");
					foreach (GameObject gemObj in gemInScene) {
						Destroy (gemObj);
					}
					IncreaseEnemyWave();
				}
			}else{
				// all gem taked, start new enemy wave
				IncreaseEnemyWave();
			}
		}else {
			CreateGem (1);
		}
	}

	void ManageEnemy(){
		if (startedWave){
			if ( !enemy.EnemyInScene) {
				gem = true;
				startedWave = false;
			}
		}else{
			startedWave=true;
			enemy.StartWave (0, startZoombunny, 3, true);
			enemy.StartWave (1, startZoombear, 5, true);
			enemy.StartWave (2, startHellephant, 10, false);
		}
	}

	void IncreaseEnemyWave(){
		startZoombunny += incrZoombunny;
		startZoombear += incrZoombear;
		startHellephant += incrHellephant;
		gem = false;
		gemCreated = false;
	}

	void CreateGem(int num){
		gemCreated = true;
		gemTime = Time.time;
		// manage gem creation with num!!
		Instantiate (gemObject, new Vector3(-3f, 0.8f, 1.5f), Quaternion.identity);
		Instantiate (gemObject, new Vector3(-3f, 0.8f, 3.5f), Quaternion.identity);
	}

	bool GemInScene (){
		GameObject[] gemInScene;
		gemInScene = GameObject.FindGameObjectsWithTag ("gem");
		return gemInScene.Length != 0 ? true : false;
	}

	public void UpdateScore(){
		Text scoreTextObject;
		scoreTextObject = GameObject.Find ("ScoreText").GetComponent<Text> ();
		scoreTextObject.text = "Score: " + PlayerPrefs.GetInt ("score");
	}
}