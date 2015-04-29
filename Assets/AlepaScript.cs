using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class AlepaScript : MonoBehaviour {

	float score = 0.0F;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
    {
    	
    	GameObject initGame = GameObject.Find("InitCode");
		InitGame initGameVar = initGame.GetComponent<InitGame>();
		initGameVar.money = initGameVar.money + (initGameVar.score / 10);
	// Convert score to float
		score = initGameVar.score;
		if(score > 0){
			GetComponent<AudioSource>().Play();
		}

		GameObject getPlayer2 = GameObject.Find("Player2D");
		PlayerControl playerControlVar = getPlayer2.GetComponent<PlayerControl>();
		playerControlVar.carryWeight -= (score * 0.05F);

		initGameVar.score = 0;
    }
}
