using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InitGame : MonoBehaviour {

	public Transform Can;
	public float score = 0F;
	public float money = 0F;
	public Text moneyString;
	public Text timeString;
	public float initTime = 20F;
	public bool running = true;
	public int level = 1;

	// Use this for initialization
	void Start () {
		for (int y = -1; y < 2; y++) {
        	for (int x = -2; x < 2; x++) {
            Instantiate(Can, new Vector3(x, y, 0), Quaternion.identity);
        	}
    	}
    // Initialize timer. Invokerepeater makes the function start at second one and runs every second.
    	{
    		InvokeRepeating("decreaseTimeRemaining", 1, 1.0F);
 		}

 	// Initialize money
    	GameObject moneyObjectVar = GameObject.Find("moneyObject");
    	moneyString = moneyObjectVar.GetComponent<Text>();
        moneyString.text="Money : DEM" + money;
	// Initialize time text
		GameObject timeObjectVar = GameObject.Find("timeObject");
    	timeString = timeObjectVar.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(level);
		moneyString.text="Money : DEM " + money;
		timeString.text="time left : " + initTime;
		if (initTime < 1){
			timeOut();
		}
	}

	// Function to count down time and to stop when it reaches 0.
	void decreaseTimeRemaining(){
		if (running == true){
    	initTime --;
    	}
    }

    void timeOut () {
    	running = false;
    	if(level > 4){
    		gameOver();
    	}
    	else{
    	restart(level);
    	}
    }
    
    void restart (int levelArg){
    	running = true;
    // Function to reduce score/cans on restart. Never goes below 0.
    	score = Mathf.Clamp((score - levelArg), 0, 100);
    	initTime = 20F;
    	level ++;
    	for (int y = -1; y < 2; y++) {
        	for (int x = -2; x < 2; x++) {
            Instantiate(Can, new Vector3(x, y, 0), Quaternion.identity);
        	}
    	}

    }

    void gameOver () {

    }
}
