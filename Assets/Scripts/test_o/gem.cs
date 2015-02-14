using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gem : MonoBehaviour {
	Logic logic;

	// Use this for initialization
	void Start () {
		logic = new Logic ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(){
		PlayerPrefs.SetInt ("score", PlayerPrefs.GetInt ("score")+1);
		logic.UpdateScore ();
		Destroy(gameObject);
	}
}
