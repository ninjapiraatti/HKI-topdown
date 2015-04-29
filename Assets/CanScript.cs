using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CanScript : MonoBehaviour {

	//public AudioClip canSound;
	//public AudioSource audio;

	// Use this for initialization
	void Start () {
		//audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D coll)
    {
    	//audio.PlayOneShot(canSound, 1.0F);
    	
    	if(coll.gameObject.tag=="player"){
    	GameObject initGame = GameObject.Find("InitCode");
		InitGame initGameVar = initGame.GetComponent<InitGame>();
		initGameVar.score += 1;
		GetComponent<AudioSource>().Play();

		GameObject getPlayer2 = GameObject.Find("Player2D");
		PlayerControl playerControlVar = getPlayer2.GetComponent<PlayerControl>();
		playerControlVar.carryWeight += 0.05f;
		}
		
		Object.Destroy(this.gameObject,0.1F);
    }
}
