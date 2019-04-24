using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour {
    public bool end = false;
    public bool isOnKey = false;
    public bool canPress = false;
    private int tecla;
    private int curLvlTime;
    private float curTime;
    public float startTime;
    public float upgradeTime;

    private float curVel = -10;
    public float upgradeVel;
    private char letra;
    public Rigidbody2D Q;
    //public Rigidbody2D W;
    //public Rigidbody2D E;
    //public Rigidbody2D R;
    //public Rigidbody2D U;
    //public Rigidbody2D I;
    //public Rigidbody2D O;
    //public Rigidbody2D P;
    System.Random RandomNum = new System.Random();



    // Use this for initialization
    void Start() {
        startTime = curTime;
    }

    // Update is called once per frame
    void Update() {
        curTime -= Time.deltaTime;
        AssignKey();
        print(curTime);
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
                    break;
                //case 2:
                //    W.velocity = new Vector3(curVel, 0);
                //    isOnKey = true;
                //    letra = 'w';
                //    break;
                //case 3:
                //    E.velocity = new Vector3(curVel, 0);
                //    isOnKey = true;
                //    letra = 'e';
                //    break;
                //case 4:
                //    R.velocity = new Vector3(curVel, 0);
                //    isOnKey = true;
                //    letra = 'r';
                //    break;
                //case 5:
                //    U.velocity = new Vector3(curVel, 0);
                //    isOnKey = true;
                //    letra = 'u';
                //    break;
                //case 6:
                //    I.velocity = new Vector3(curVel, 0);
                //    isOnKey = true;
                //    letra = 'i';
                //    break;
                //case 7:
                //    O.velocity = new Vector3(curVel, 0);
                //    isOnKey = true;
                //    letra = 'o';
                //    break;
                //case 8:
                //    P.velocity = new Vector3(curVel, 0);
                //    isOnKey = true;
                //    letra = 'p';
                //    break;
            }
            startTime = curTime;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tecla" && isOnKey)
        {
            canPress = true;
            checkClick();
        }
    }
    void checkClick()
    {
        if (canPress)
        {
            if (Input.GetKeyDown(KeyCode.Q) && letra == 'q')
            {
                Q.transform.position = new Vector3(7.38f, -3.35f);
                print("KeyPressed");
            }
            else if (Input.GetKeyDown(KeyCode.W) && letra == 'w')
            {

            }
            else if (Input.GetKeyDown(KeyCode.E) && letra == 'e')
            {

            }
            else if (Input.GetKeyDown(KeyCode.R) && letra == 'r')
            {

            }
            else if (Input.GetKeyDown(KeyCode.U) && letra == 'u')
            {

            }
            else if (Input.GetKeyDown(KeyCode.I) && letra == 'i')
            {

            }
            else if (Input.GetKeyDown(KeyCode.O) && letra == 'o')
            {

            }
            else if (Input.GetKeyDown(KeyCode.P) && letra == 'p')
            {

            }
        }
    }
    //void CheckCollision()
    //{

    //}
}
