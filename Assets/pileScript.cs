using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class pileScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void restart(){
		gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
    {
    	
    	if(coll.gameObject.tag=="player"){
	    	GameObject initGame = GameObject.Find("InitCode");
			InitGame initGameVar = initGame.GetComponent<InitGame>();
			GameObject getPlayer2 = GameObject.Find("Player2D");
			PlayerControl playerControlVar = getPlayer2.GetComponent<PlayerControl>();
			if(playerControlVar.hasTools == true){
				initGameVar.metal += 1;
				GetComponent<AudioSource>().Play();
				playerControlVar.carryWeight += 0.5f;
				gameObject.SetActive(false);
			} else {
				//initGameVar.showToolstip = true;
			}
		}
		
		
    }
}

/*
-2.3 2.5
-1.1 0.9
-3.3 -3.3
2.8 2.5
5.3 4.8*/
