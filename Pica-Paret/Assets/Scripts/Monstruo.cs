using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstruo : MonoBehaviour {

    public int Fase;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Monster();
        Fase = Piano.FaseParaMonstruo;
    }
    void Monster()
    {
        if (Fase == 1)
        {
            Debug.Log("1");
            //Sound 1
        }
        else if (Fase == 2)
        {
            Debug.Log("2");
            //Sound 2
        }
        else if (Fase == 3)
        {
            Debug.Log("3");
            //Sound 3
            //After 2 seconds if player does not hide behind "Piano" JumpScare
            Fase = 0;
        }
    }
}
