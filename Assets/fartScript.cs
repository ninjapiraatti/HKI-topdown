using UnityEngine;
using System.Collections;

public class fartScript : MonoBehaviour {
 
    private IEnumerator KillOnAnimationEnd() {
        yield return new WaitForSeconds (0.967f);
        Destroy (gameObject);
    }

    void start(){

    }
 
    void Update () {
        StartCoroutine (KillOnAnimationEnd ());
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
    	

        if(coll.gameObject.tag=="beast")
        {
            Destroy(coll.gameObject);
            Debug.Log("Collision");
        }

    }
}