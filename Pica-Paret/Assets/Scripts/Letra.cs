using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letra : MonoBehaviour {

    public Rigidbody2D rigidbody2D;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Piano")
        {
            gameObject.transform.position = new Vector3(11.38f, -3.35f, -1);
            rigidbody2D.velocity = new Vector2(0, 0);
            //Piano.

        }
    }
}
