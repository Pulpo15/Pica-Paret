using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstruo : MonoBehaviour {

    public int Fase;
    public int numSonido;
    public float startTime;
    private float curTime;
    private int typeOfEvent;
    System.Random RandomNum = new System.Random();
    

    // Use this for initialization
    void Start () {
        curTime = startTime;
    }
	
	// Update is called once per frame
	void Update () { 
        Fase = Piano.FaseParaMonstruo;
        Monster();
        Sonidos();
    }
    void Monster()
    {

        switch (Fase)
        {
            case 1:
                //Pos 1
                numSonido = 1;
                break;
            case 2:
                //Pos 2
                break;
            case 3:
                //Pos 3
                break;
            case 4:
                //Pos 4
                numSonido = 2;
                break;
            case 5:
                //Pos 5
                break;
            case 6:
                //Pos 6
                break;
            case 7:
                numSonido = 3;
                //After 2 seconds if player does not hide behind "Piano" JumpScare
                break;
        }
    }
    void Sonidos()
    {
        typeOfEvent = RandomNum.Next(1, 9);
        curTime -= Time.deltaTime;
        if (curTime <= 0 && numSonido == 1 && typeOfEvent == 1)
        {
            //Play Sound 1
        }
        else if (curTime <= 0 && numSonido == 2 && typeOfEvent == 1)
        {
            //Play Sound 2
        }
        else if (curTime <= 0 && numSonido == 3 && typeOfEvent == 1)
        {
            //Play Sound 3
        }
        else if (curTime <= 0 && numSonido == 3 && typeOfEvent == 2)
        {
            //Play Ray
        }
        else if (curTime <= 0 && numSonido == 3 && typeOfEvent == 3)
        {
            //Play Sound ????
        }

    }
}
