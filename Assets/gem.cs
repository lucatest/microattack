using UnityEngine;
using System.Collections;

public class gem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){
		int score;
		score = PlayerPrefs.GetInt ("score");
		PlayerPrefs.SetInt ("score", score+1);
		Debug.Log(PlayerPrefs.GetInt ("score"));
		Destroy(gameObject);
	}
}
