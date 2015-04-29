using UnityEngine;
using System.Collections;

public class BeastScript : MonoBehaviour {

	public Transform target; //set target from inspector instead of looking in Update
    public float speed = 0.01f;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
        //move towards the player

		GameObject initGame = GameObject.Find("InitCode");
		InitGame initGameVar = initGame.GetComponent<InitGame>();
       
        if(Vector2.Distance(transform.position,target.position) >= 1 && initGameVar.running == true)
		{
			transform.position += (target.transform.position - transform.position).normalized * speed * Time.deltaTime;
		}	
	}
	void OnTriggerEnter2D(Collider2D coll)
    {
    	

        if(coll.gameObject.name == "Player2D")
        {
            Destroy(coll.gameObject);
            Debug.Log("Collision");
        }
    }
}
