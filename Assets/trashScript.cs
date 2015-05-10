using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class trashScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
    {
    	if(coll.gameObject.name == "Player2D"){
    		GameObject getPlayer2 = GameObject.Find("Player2D");
			PlayerControl playerControlVar = getPlayer2.GetComponent<PlayerControl>();
			playerControlVar.health = 1.0f;
			GetComponent<AudioSource>().Play();
		}
	}
}
