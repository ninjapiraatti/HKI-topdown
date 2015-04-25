using UnityEngine;
using System.Collections;

public class BeastScript : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	
	}
	void OnTriggerEnter2D(Collider2D coll)
    {
    	GameObject initGame = GameObject.Find("InitCode");
		InitGame initGameVar = initGame.GetComponent<InitGame>();
		initGameVar.score += 10;

        if(coll.gameObject.name == "Player2D")
        {
            Destroy(coll.gameObject);
            Debug.Log("Collision");
        }
    }
}
