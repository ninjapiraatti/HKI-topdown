using UnityEngine;
using System.Collections;

public class CanScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
    {
    	if(coll.gameObject.tag=="player"){   
    	GameObject initGame = GameObject.Find("InitCode");
		InitGame initGameVar = initGame.GetComponent<InitGame>();
		initGameVar.score += 1;

		GameObject getPlayer2 = GameObject.Find("Player2D");
		PlayerControl playerControlVar = getPlayer2.GetComponent<PlayerControl>();
		playerControlVar.carryWeight += 0.05f;
		}

		Object.Destroy(this.gameObject);
    }
}
