using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerControl : MonoBehaviour {


	// Use this for initialization

	public float initSpeed = 1.1F;
	public float speed = 1.1F;
	public bool playerRunning = true;
	public bool hasTools = false;
	public bool hasBooze= false;
	public bool hasPeaSoup = false;
	public float health = 1.0F;
	public Text healthString;
	public float carryWeight = 0.0F;
	private Animator animator;
	public Transform fartObject;
	
	public void Start () {
    	InvokeRepeating("checkRunning", 0, 1.0F);
    	InvokeRepeating("checkHealth", 0, 1.0F);	
    	// Initialize health text
		GameObject healthObjectVar = GameObject.Find("healthObject");
    	healthString = healthObjectVar.GetComponent<Text>();
    	animator = this.GetComponent<Animator>();
    	initSpeed = 1.1F;
		speed = 1.1F;
		playerRunning = true;
		health = 1.0F;
		carryWeight = 0.0F;
		hasTools = false;
		hasBooze= false;
		hasPeaSoup = false;
		resetPosition();
	}

	void resetPosition(){
    	transform.position = new Vector2(1.25F, -2.5F);
	}

	// Get running variable from InitGame. Doesn't have to be every frame.
	void checkRunning(){
		GameObject initGame = GameObject.Find("InitCode");
		InitGame initGameVar = initGame.GetComponent<InitGame>();
		playerRunning = initGameVar.running;
		if(initGameVar.score < 0.01){
			speed = 1.0F;
		}
		if(carryWeight < 0){
			carryWeight = 0;
		}
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
		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");
		if (horizontal > 0)
        {
            animator.SetInteger("Direction", 2);
        }
        else if (horizontal < 0)
        {
            animator.SetInteger("Direction", 1);
        }
        else if (horizontal == 0 && vertical == 0)
        {
            animator.SetInteger("Direction", 0);
        }
		if(playerRunning == true){
			float translationY = Input.GetAxis("Vertical") * speed * 1.3F;
	        float translationX = Input.GetAxis("Horizontal") * speed * 1.3F;
	        translationY *= Time.deltaTime;
	        translationX *= Time.deltaTime;
	        transform.Translate(0, translationY, 0);
	        transform.Translate(translationX, 0, 0);
	        if(!hasPeaSoup){
	        	health -= 0.0001F;
	        }
	        else{
	        	float fartOrNot = (Random.Range(0F, 500.0F));
	        		if(fartOrNot < 1){
	        			speed = 3;
	        			GetComponent<AudioSource>().Play();
	        			Instantiate(fartObject, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
	        			//this.GetComponent<Rigidbody2D>().AddForce(-transform.right * 0);
	        		}
	        }
	    } else {

	    }
	}
}
