using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour {
    public bool end = false;
    public bool isOnKey = false;
    public bool canPress = false;
    public bool failed = false;
    private int tecla;
    private int curLvlTime;
    private float curTime;
    public float startTime;
    public float upgradeTime;
    private float curVel = -10;
    public float upgradeVel;
    private char letra;
    public Rigidbody2D Q;
    public Rigidbody2D W;
    public Rigidbody2D E;
    public Rigidbody2D R;
    public Rigidbody2D U;
    public Rigidbody2D I;
    public Rigidbody2D O;
    public Rigidbody2D P;
    System.Random RandomNum = new System.Random();
    //private new Vector3 startPos = Q.transform.position; 
    public int Fase = 0;
    public static int FaseParaMonstruo;

    // Use this for initialization
    void Start() {
        curTime = startTime;
    }

    // Update is called once per frame
    void Update() {
        curTime -= Time.deltaTime;
        AssignKey();
        //Debug.Log(curTime);
        //print(curTime);
        checkClick();
    }

    void AssignKey()
    {
        while (!end && curTime <= 0)
        {
            tecla = RandomNum.Next(1, 9);
            switch (tecla)
            {
                case 1:
                    Q.velocity = new Vector3(curVel, 0);
                    isOnKey = true;
                    letra = 'q';
                    Q.transform.position = new Vector3(7.38f, -3.35f, -1);
                    break;
                case 2:
                    W.velocity = new Vector3(curVel, 0);
                    isOnKey = true;
                    letra = 'w';
                    W.transform.position = new Vector3(7.38f, -3.35f, -1);
                    break;
                case 3:
                    E.velocity = new Vector3(curVel, 0);
                    isOnKey = true;
                    letra = 'e';
                    E.transform.position = new Vector3(7.38f, -3.35f, -1);
                    break;
                case 4:
                    R.velocity = new Vector3(curVel, 0);
                    isOnKey = true;
                    letra = 'r';
                    R.transform.position = new Vector3(7.38f, -3.35f, -1);
                    break;
                case 5:
                    U.velocity = new Vector3(curVel, 0);
                    isOnKey = true;
                    letra = 'u';
                    U.transform.position = new Vector3(7.38f, -3.35f, -1);
                    break;
                case 6:
                    I.velocity = new Vector3(curVel, 0);
                    isOnKey = true;
                    letra = 'i';
                    I.transform.position = new Vector3(7.38f, -3.35f, -1);
                    break;
                case 7:
                    O.velocity = new Vector3(curVel, 0);
                    isOnKey = true;
                    letra = 'o';
                    O.transform.position = new Vector3(7.38f, -3.35f, -1);
                    break;
                case 8:
                    P.velocity = new Vector3(curVel, 0);
                    isOnKey = true;
                    letra = 'p';
                    P.transform.position = new Vector3(7.38f, -3.35f, -1);
                    break;
            }
            curTime = startTime;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tecla" && isOnKey)
        {
            canPress = true;
        }
    }
    void checkClick()
    {
        if (canPress)
        {
            if (Input.GetKeyDown(KeyCode.Q) && letra == 'q')
            {
                Q.transform.position = new Vector3(11.13f, -2.55f, -1);
                Q.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                canPress = false;
            }
            else if (Input.GetKeyDown(KeyCode.W) && letra == 'w')
            {
                W.transform.position = new Vector3(11.28f, 0.14f, -1);
                W.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                canPress = false;
            }
            else if (Input.GetKeyDown(KeyCode.E) && letra == 'e')
            {
                E.transform.position = new Vector3(14.32f, 0.13f, -1);
                E.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                canPress = false;
            }
            else if (Input.GetKeyDown(KeyCode.R) && letra == 'r')
            {
                R.transform.position = new Vector3(14.06f, -2.63f, -1);
                R.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                canPress = false;
            }
            else if (Input.GetKeyDown(KeyCode.U) && letra == 'u')
            {
                U.transform.position = new Vector3(18.13f, -0.01f, -1);
                U.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                canPress = false;
            }
            else if (Input.GetKeyDown(KeyCode.I) && letra == 'i')
            {
                I.transform.position = new Vector3(18.16f, -2.41f, -1);
                I.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                canPress = false;
            }
            else if (Input.GetKeyDown(KeyCode.O) && letra == 'o')
            {
                O.transform.position = new Vector3(21.33f, 0.03f, -1);
                O.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                canPress = false;
            }
            else if (Input.GetKeyDown(KeyCode.P) && letra == 'p')
            {
                P.transform.position = new Vector3(21.49f, -2.56f, -1);
                P.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                canPress = false;
            }

        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            //Putear al Jugador
            Debug.Log("TusMuertos");
            Fase++;
            FaseParaMonstruo = Fase;
            if (Fase == 3)
            {
                Fase = 0;
            }
        }
    }
    //void NextFase()
    //{
    //    if (failed)
    //    {
    //        Fase++;
    //        failed = false;
    //    }
    //}

    //void CheckCollision()
    //{

    //}
}
