using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monstruo : MonoBehaviour {

    public int Fase;
    public int numSonido;
    public float startTime;
    private float curTime;
    public int typeOfEvent;
    private int numPos;
    public Image Background;
    System.Random RandomNum = new System.Random();
    

    // Use this for initialization
    void Start () {
        curTime = startTime;
    }
	
	// Update is called once per frame
	void Update () { 
        //Fase = Piano.FaseParaMonstruo;
        Monster();
        Sonidos();
    }
    void Monster()
    {
        if (curTime <= 0)
        {
            Fase = RandomNum.Next(1, 9);
            typeOfEvent = RandomNum.Next(1, 3);
            curTime = startTime;
        }
        switch (Fase)
        {
            case 1:
                //Pos 1 Derecha
                gameObject.transform.position = new Vector3(-3.7f, -0.4f, 14.58f);
                gameObject.transform.localScale = new Vector3(0.3871875f, 0.3351564f, 1);
                numSonido = 1;
                break;
            case 2:
                //Pos 2 Derecha
                //Ventana
                break;
            case 3:
                //Pos 3 Derecha
                gameObject.transform.position = new Vector3(-6.0128f,0.68256f, 14.58f);
                gameObject.transform.localScale = new Vector3(0.2608676f, 0.1915104f, 1);
                break;
            case 4:
                //Pos 1 Medio
                //Close
                gameObject.transform.position = new Vector3(-7.78f, -0.4f, 14.58f);
                gameObject.transform.localScale = new Vector3(0.3871875f, 0.3351564f, 1);
                numSonido = 2;
                break;
            case 5:
                //Pos 2 Medio
                //Far
                gameObject.transform.position = new Vector3(-7.6091f, 0.40992f, 14.58f);
                gameObject.transform.localScale = new Vector3(0.1170407f, 0.08446988f, 1);
                break;
            case 6:
                //Pos 1 Izquierda
                //Close
                gameObject.transform.position = new Vector3(-12.98f, -0.4f, 14.58f);
                gameObject.transform.localScale = new Vector3(0.3871875f, 0.3351564f, 1);
                break;
            case 7:
                //Pos 2 Izquierda
                //Ventana
                numSonido = 3;
                break;
            case 8:
                //Pos 3 Izquierda
                gameObject.transform.position = new Vector3(-8.8382f, 0.35963f, 14.58f);
                gameObject.transform.localScale = new Vector3(0.1620283f, 0.1151457f, 1);
                break;
        }
        
    }
    void Sonidos()
    {
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
        else if (curTime <= 0 && typeOfEvent == 2)
        {
            Background.sprite = Resources.Load("Ray_Room.png") as Sprite;
        }

    }
}
