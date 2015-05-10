using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class AlepaScript : MonoBehaviour {

	float score = 0.0F;
	float metal = 0.0F;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
    {

    	if(coll.gameObject.name == "Player2D")
        {
			GameObject initGame = GameObject.Find("InitCode");
			InitGame initGameVar = initGame.GetComponent<InitGame>();
			initGameVar.money += (initGameVar.score / 10);
			initGameVar.money += (initGameVar.metal * 4);

			score = initGameVar.score;
			if(score > 0){
				GetComponent<AudioSource>().Play();
			}

			metal = initGameVar.metal;
			if(metal > 0){
				GetComponent<AudioSource>().Play();
			}

			GameObject getPlayer2 = GameObject.Find("Player2D");
			PlayerControl playerControlVar = getPlayer2.GetComponent<PlayerControl>();
			playerControlVar.carryWeight -= (score * 0.05F);
			playerControlVar.carryWeight -= (metal * 0.5F);


			initGameVar.score = 0;
			initGameVar.metal = 0; 
        }
    }
}
