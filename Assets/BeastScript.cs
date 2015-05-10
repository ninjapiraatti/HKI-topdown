using UnityEngine;
using System.Collections;

public class BeastScript : MonoBehaviour {

	public float startPosX;
	public float startPosY;
	public Transform target; //set target from inspector instead of looking in Update
    public float speed = 0.02f;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
        //move towards the player

		GameObject initGame = GameObject.Find("InitCode");
		InitGame initGameVar = initGame.GetComponent<InitGame>();
       
        if(initGameVar.running == true)
		{
			transform.position += (target.transform.position - transform.position).normalized * speed * Time.deltaTime;
		}
		if(initGameVar.gameOverBool == true){
			transform.position = new Vector2(startPosX, startPosY);
		}
	}
	void OnTriggerEnter2D(Collider2D coll)
    {
    	

        if(coll.gameObject.name == "Player2D")
        {
        	GameObject initGame = GameObject.Find("InitCode");
			InitGame initGameVar = initGame.GetComponent<InitGame>();
            initGameVar.gameOverBool = true;
            //Debug.Log("Collision");
        }
    }
}
