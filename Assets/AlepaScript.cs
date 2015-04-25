using UnityEngine;
using System.Collections;

public class AlepaScript : MonoBehaviour {

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
		initGameVar.score = 0;


		GameObject getPlayer2 = GameObject.Find("Player2D");
		PlayerControl playerControlVar = getPlayer2.GetComponent<PlayerControl>();
		playerControlVar.speed = 1.0f;

		Debug.Log(initGameVar.money);
    }
}
