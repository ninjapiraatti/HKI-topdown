using UnityEngine;
using System.Collections;


public class PlayerControl : MonoBehaviour {

	// Use this for initialization

	public float speed = 1.25F;
	public bool playerRunning = true;
	
	void Start () {
    	InvokeRepeating("checkRunning", 0, 1.0F);	
	}

	// Get running variable from InitGame. Doesn't have to be every frame.
	void checkRunning(){
		GameObject initGame = GameObject.Find("InitCode");
		InitGame initGameVar = initGame.GetComponent<InitGame>();
		playerRunning = initGameVar.running;
	}

	
	// Update is called once per frame
	void Update () {
		if(playerRunning == true){
			float translationY = Input.GetAxis("Vertical") * speed;
	        float translationX = Input.GetAxis("Horizontal") * speed;
	        translationY *= Time.deltaTime;
	        translationX *= Time.deltaTime;
	        transform.Translate(0, translationY, 0);
	        transform.Translate(translationX, 0, 0);
	        Debug.Log(playerRunning);
	    } else {

	    }
	}
}
