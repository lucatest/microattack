using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	Animator anim;
	public Life life;

	public float restartDelay = 5f;
	float restartTimer;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!life.PlayerStat){
			anim.SetTrigger("GameOver");
			restartTimer += Time.deltaTime;
			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel("test_0");
				//Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
