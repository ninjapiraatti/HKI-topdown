using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InitGame : MonoBehaviour {

	public Transform Can;
	public float score = 0F;
	public float metal = 0F;
	public float money = 0F;
	public Text moneyString;
	public Text timeString;
	public Text cansString;
	public Text metalString;
	public float initTime = 60F;
	public bool running = true;
	public bool gameOverBool = false;
	public int level = 1;
	public bool showButton = false;
	public bool showStartButton = true;
	public Texture btnTexture;
	public GameObject beast2;
	public GameObject[] pileobjects;

	// Use this for initialization
	void Start () {
		for (int y = -4; y < 3; y++) {
       		//float yPos = -3.5f + y;
        	for (int x = -3; x < 7; x++) {
        		//float xPos = -2.5f + x;
        		float spawnOrNot = (Random.Range(-1.0F, 1.0F));
        		if(spawnOrNot > 0){
        			float deviateX = (Random.Range(-0.7F, 0.7F));
        			float deviateY = (Random.Range(-0.7F, 0.7F));
        			Instantiate(Can, new Vector3(x + deviateX, y + deviateY, 0), Quaternion.identity);
        		} else {

        		}            	
        	}
    	}
    // Initialize timer. Invokerepeater makes the function start at second one and runs every second.
    	{
    		InvokeRepeating("decreaseTimeRemaining", 1, 1.0F);
 		}

 	// Initialize money
    	GameObject moneyObjectVar = GameObject.Find("moneyObject");
    	moneyString = moneyObjectVar.GetComponent<Text>();
	// Initialize time text
		GameObject timeObjectVar = GameObject.Find("timeObject");
    	timeString = timeObjectVar.GetComponent<Text>();
	// Initialize cans text
		GameObject cansObjectVar = GameObject.Find("cansObject");
    	cansString = cansObjectVar.GetComponent<Text>();
    // Initialize metal text
    	GameObject metalObjectVar = GameObject.Find("metalObject");
    	metalString = metalObjectVar.GetComponent<Text>();
    // Init metal piles
    	pileobjects = GameObject.FindGameObjectsWithTag("pile");
   	}
	// Update is called once per frame
	void Update () {
		//Debug.Log(level);
		moneyString.text="Money : DEM " + money;
		timeString.text="time left : " + initTime;
		cansString.text= "Cans: " + score;
		metalString.text= "Metal: " + metal;
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
    	if(level > 3){
    		gameOverBool = true;
    		showButton = false;
    	}
    	else{
    		showButton = true;
    	}
    }

    void OnGUI () {
    	if(showButton == true){
    		if(score > 0){
	    		GUI.contentColor = Color.black;
	    		GUI.Label(new Rect(200, 230, 230, 20), ("Over the night you lost some cans."));
    		} else if(metal > 0){
    			GameObject getPlayer2 = GameObject.Find("Player2D");
				PlayerControl playerControlVar = getPlayer2.GetComponent<PlayerControl>();
    			playerControlVar.carryWeight = (metal * 0.5F);
    		} else {
    			GameObject getPlayer2 = GameObject.Find("Player2D");
				PlayerControl playerControlVar = getPlayer2.GetComponent<PlayerControl>();
    			playerControlVar.carryWeight = 0;
    		}
	    	if (GUI.Button(new Rect(200,200,160,30), "Next Level")){
	    	// Restore speed according to lost cans
	    		if(score > (level * 2)){
	    			GameObject getPlayer2 = GameObject.Find("Player2D");
					PlayerControl playerControlVar = getPlayer2.GetComponent<PlayerControl>();
					playerControlVar.carryWeight -= (level * 0.1F);
	    		}
				nextLevel(level);
			}
				
		}
		if(showStartButton == true){
			running = false;
			if (GUI.Button(new Rect(200,200,160,30), "start game")){
		    	running = true;
		    	showStartButton = false;
			}

		}
		if(gameOverBool == true){
			running = false;
			GUI.contentColor = Color.black;
			GUI.Label(new Rect(0, 30, 290, 20), ("Game over! You collected DEM " + money + " worth of cans."));
			if (GUI.Button(new Rect(0,0,160,30), "Try again!")){
				
				GameObject getPlayer2 = GameObject.Find("Player2D");
				PlayerControl playerControlVar = getPlayer2.GetComponent<PlayerControl>();
    			playerControlVar.Start();

    			
    			for(int i = 0; i < pileobjects.Length; i++)
		        {
		            Debug.Log("Pile "+i );
		            pileobjects[i].SetActive(true);
		        }

				score = 0F;
				money = 0F;
				metal = 0F;
				initTime = 60F;
				level = 1;
				showButton = false;
				showStartButton = false;
				running = true;
				gameOverBool = false;

			}
		}
    }
    
    void nextLevel (int levelArg){
    // Remove cans
    	GameObject[] objects = GameObject.FindGameObjectsWithTag("canTag");
    	for (int i=0; i<objects.Length; i++){
    		Destroy(objects[i]);
		}
	// Resets
    	showButton = false;
    	running = true;
    // Function to reduce score/cans on nextLevel. Never goes below 0.
    	score = Mathf.Clamp((score - levelArg * 2), 0, 100);
    // More resets on next level
    	initTime = 60F;
    	level ++;
    // Create cans

       	for (int y = -4; y < 3; y++) {
       		//float yPos = -3.5f + y;
        	for (int x = -3; x < 7; x++) {
        		//float xPos = -2.5f + x;
        		float spawnOrNot = (Random.Range(-1.0F, 1.0F));
        		if(spawnOrNot > 0){
        			float deviateX = (Random.Range(-0.7F, 0.7F));
        			float deviateY = (Random.Range(-0.7F, 0.7F));
        			Instantiate(Can, new Vector3(x + deviateX, y + deviateY, 0), Quaternion.identity);
        		} else {

        		}            	
        	}
    	}
    // Add beast
    	if(level > 1){
    		//GameObject beast2 = GameObject.Find("Beast2");
    		beast2.SetActive(true);
    	}
    }

    void gameOver () {

    }
}
