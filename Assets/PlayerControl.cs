using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour {

	// Use this for initialization

	public float initSpeed = 1.1F;
	public float speed = 1.1F;
	public bool playerRunning = true;
	public float health = 1.0F;
	public Text healthString;
	public float carryWeight = 0.0F;
	
	void Start () {
    	InvokeRepeating("checkRunning", 0, 1.0F);
    	InvokeRepeating("checkHealth", 0, 4.0F);	
    	// Initialize health text
		GameObject healthObjectVar = GameObject.Find("healthObject");
    	healthString = healthObjectVar.GetComponent<Text>();
	}

	// Get running variable from InitGame. Doesn't have to be every frame.
	void checkRunning(){
		GameObject initGame = GameObject.Find("InitCode");
		InitGame initGameVar = initGame.GetComponent<InitGame>();
		playerRunning = initGameVar.running;
	}

	// Check health and reduce speed accordingly
	void checkHealth(){
		if(playerRunning == true){
			speed = health - carryWeight;
		}
	}

	
	// Update is called once per frame
	void Update () {
		healthString.text= "Stamina: " + health;
		if(playerRunning == true){
			float translationY = Input.GetAxis("Vertical") * speed;
	        float translationX = Input.GetAxis("Horizontal") * speed;
	        translationY *= Time.deltaTime;
	        translationX *= Time.deltaTime;
	        transform.Translate(0, translationY, 0);
	        transform.Translate(translationX, 0, 0);
	        health -= 0.0001F;
	    } else {

	    }
	}
}
