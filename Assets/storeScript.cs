using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class storeScript : MonoBehaviour {

	public bool showStore = false;
	public GameObject menu;
	
	

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
        	showStore = true;
        	GameObject initGame = GameObject.Find("InitCode");
			InitGame initGameVar = initGame.GetComponent<InitGame>();
			initGameVar.running = false;
        }
    }

	void OnGUI () {
    	if(showStore == true){
    		menu.SetActive(true);
    	} else {
    		menu.SetActive(false);
    	}
    }

    public void hideStore(){
    	showStore = false;
    	GameObject initGame = GameObject.Find("InitCode");
		InitGame initGameVar = initGame.GetComponent<InitGame>();
		initGameVar.running = true;
    }

    public void buyTools(){
    	GameObject getPlayer2 = GameObject.Find("Player2D");
		PlayerControl playerControlVar = getPlayer2.GetComponent<PlayerControl>();

		GameObject initGame = GameObject.Find("InitCode");
		InitGame initGameVar = initGame.GetComponent<InitGame>();
		if(initGameVar.money >= 5){
			playerControlVar.hasTools = true;
			GetComponent<AudioSource>().Play();
			initGameVar.money -= 5.0F;
		}		
    }

    public void buyBooze(){
    	GameObject getPlayer2 = GameObject.Find("Player2D");
		PlayerControl playerControlVar = getPlayer2.GetComponent<PlayerControl>();
		
		GameObject initGame = GameObject.Find("InitCode");
		InitGame initGameVar = initGame.GetComponent<InitGame>();
		if(initGameVar.money >= 1 && playerControlVar.hasPeaSoup == false){
			playerControlVar.hasPeaSoup = true;
			GetComponent<AudioSource>().Play();
			initGameVar.money -= 1;
		}		
    }

    public void buyPeaSoup(){
    	GameObject getPlayer2 = GameObject.Find("Player2D");
		PlayerControl playerControlVar = getPlayer2.GetComponent<PlayerControl>();
		
		GameObject initGame = GameObject.Find("InitCode");
		InitGame initGameVar = initGame.GetComponent<InitGame>();
		if(initGameVar.money >= 1 && !playerControlVar.hasPeaSoup){
			playerControlVar.hasPeaSoup = true;
			GetComponent<AudioSource>().Play();
			initGameVar.money -= 1;
		}		
    }
}
