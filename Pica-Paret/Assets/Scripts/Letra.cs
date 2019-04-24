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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EndPiano")
        {
            gameObject.transform.position = new Vector3(7.38f, -3.35f, -1);
            rigidbody2D.velocity = new Vector2(0, 0);

        }
    }
}
