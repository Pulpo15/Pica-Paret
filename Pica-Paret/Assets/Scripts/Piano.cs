using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Piano : MonoBehaviour {
    public bool end = false;
    public bool isOnKey = false;
    public bool canPress = false;
    private bool failed = false;
    private bool[] boolLetras = new bool[8];
    private char[] numLetra = new char[8];
    private int curNumLetra;
    private int nextKeyToPress;
    private int tecla;

    private int curLvlTime;
    private float curTime;
    public float startTime;
    private float upgradeTime = 0.2f;
    private float upgradeVel = 1.1f;
    public float curVel = -5f;
    private float timeToWait = 5;
    private float timeLvlUp = 16f;
    public float curTimeLvlUp;
    public float curTimeToWait;
    private char letra;
    private int lastTecla;
    private float deadTime = 2.0f;
    public float curDeadTime;

    public Rigidbody2D Q;
    public Rigidbody2D W;
    public Rigidbody2D E;
    public Rigidbody2D R;
    public Rigidbody2D U;
    public Rigidbody2D I;
    public Rigidbody2D O;
    public Rigidbody2D P;

    public AudioSource Melodia;
    private bool isOnMusic;
    public AudioSource AudioMistake;
    public AudioSource Screamer;

    private float timeAudioMistake = 0.5f;
    private float curTimeAudioMistake;
    private bool musicBool;

    System.Random RandomNum = new System.Random();

    public SkinnedMeshRenderer SpriteCap;
    public SkinnedMeshRenderer SpriteTorso;
    //private new Vector3 startPos = Q.transform.position; 
    //public int Fase = 0;
    //public static int FaseParaMonstruo;

    //public Collider2D QCollider;
    //public Collider2D WCollider;
    //public Collider2D ECollider;
    //public Collider2D RCollider;
    //public Collider2D UCollider;
    //public Collider2D ICollider;
    //public Collider2D OCollider;
    //public Collider2D PCollider;

    public Text Marcador;
    private float timeToRemove;
    private float timeGame;
    public static float timeForRecord;
    private int numChungo = 1;
    private bool isHiding;
    public int Fase;
    public Animator PianoStart;
    public static bool endParaMonstruo;
    public SpriteRenderer PianoIzq;
    public SpriteRenderer PianoMid;
    public SpriteRenderer PianoDer;

    // Use this for initialization
    void Start() {
        PianoDer.enabled = false;
        PianoMid.enabled = false;
        PianoIzq.enabled = false;
        timeToRemove = Time.time;
        curTime = startTime;
        curTimeLvlUp = timeLvlUp;
        curTimeAudioMistake = timeAudioMistake;
        curDeadTime = deadTime;
        SpriteCap.enabled = false;
        SpriteTorso.enabled = false;
        for (int i = 0; i < 8; i++)
        {
            boolLetras[i] = false;
        }
    }

    // Update is called once per frame
    void Update() {
        Fase = Monstruo.FaseParaPiano;
        curTimeLvlUp -= Time.deltaTime;
        if (curTimeLvlUp <= 0 && !end)
        {
            if (startTime > 0.5f)
            {
                startTime -= upgradeTime;
            }
            curVel *= upgradeVel;
            curTimeLvlUp = timeLvlUp;
        }
        if (!end)
        {
            timeGame = Time.time - timeToRemove;
            Marcador.text = timeGame.ToString();
            curTime -= Time.deltaTime;
        }
        AssignKey();
        //Debug.Log(curTime);
        //print(curTime);
        checkClick();
        curTimeToWait -= Time.deltaTime;
        SetEndFalse();
        if (end)
        {
            endParaMonstruo = end;
            curDeadTime -= Time.deltaTime;
            if (curDeadTime <= 0 && !isHiding)
            {
                Susto();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                //Animacion 
                isHiding = true;
                PianoStart.SetBool("isHiding", true);
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    PianoDer.enabled = true;
                    PianoMid.enabled = false;
                    PianoIzq.enabled = false;
                    if (Fase == 1 || Fase == 2 || Fase == 3)
                    {
                        isHiding = false;
                        Susto();
                    }
                    Debug.Log("Derecha");
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    PianoMid.enabled = true;
                    PianoDer.enabled = false;
                    PianoIzq.enabled = false;
                    //PianoStart.SetBool("isHiding", true);
                    if (Fase == 5 || Fase == 4)
                    {
                        isHiding = false;
                        Susto();
                    }
                    Debug.Log("Centro");
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    PianoIzq.enabled = true;
                    PianoDer.enabled = false;
                    PianoMid.enabled = false;
                    //PianoStart.SetBool("isHiding", true);
                    if (Fase == 6 || Fase == 7 || Fase == 8)
                    {
                        isHiding = false;
                        Susto();
                    }
                    Debug.Log("Izquierda");
                }

            }
        }
        if (musicBool)
        {
            curTimeAudioMistake -= Time.deltaTime;
            if (curTimeAudioMistake <= 0)
            {
                AudioMistake.Play();
                curTimeAudioMistake = timeAudioMistake;
                musicBool = false;
            }
        }
    }
    
    void Susto()
    {
        SpriteCap.enabled = true;
        SpriteTorso.enabled = true;
        //Melodia.Pause();
        //AudioMistake.Stop();
        if (!Screamer.isPlaying)
        {
            Screamer.Play();
        }
        timeForRecord = timeGame;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(4);
        }
    }

    void SetEndFalse()
    {
        if (isHiding)
        {
            if (curTimeToWait <= 0)
            {
                Debug.Log("False");
                end = false;
                endParaMonstruo = end;
                isHiding = false;
                //endParaMonstruo = end;
                curDeadTime = deadTime;
                PianoDer.enabled = false;
                PianoMid.enabled = false;
                PianoIzq.enabled = false;
                PianoStart.SetBool("isHiding", false);
            }
        }
    }

    void AssignKey()
    {
        while (!end && curTime <= 0)
        {
            if (!isOnMusic)
            {
                if (numChungo == 1)
                {
                    Melodia.Play();
                }
                Melodia.UnPause();
                isOnMusic = true;
            }
            tecla = RandomNum.Next(1, 9);
            //if (lastTecla != tecla)
            //{
                switch (tecla)
                {
                    case 1:
                    if (!boolLetras[0])
                    {
                        Q.velocity = new Vector3(curVel, 0);
                        isOnKey = true;
                        letra = 'q';
                        Q.transform.position = new Vector3(7.38f, -3.5f, -1);
                        boolLetras[0] = true;
                        numLetra[curNumLetra] = letra;
                        curNumLetra++;
                    }
                    break;
                    case 2:
                    if (!boolLetras[1])
                    {
                        W.velocity = new Vector3(curVel, 0);
                        isOnKey = true;
                        letra = 'w';
                        W.transform.position = new Vector3(7.38f, -3.5f, -1);
                        boolLetras[1] = true;
                        numLetra[curNumLetra] = letra;
                        curNumLetra++;
                    }
                    break;
                    case 3:
                    if (!boolLetras[2])
                    {
                        E.velocity = new Vector3(curVel, 0);
                        isOnKey = true;
                        letra = 'e';
                        E.transform.position = new Vector3(7.38f, -3.5f, -1);
                        boolLetras[2] = true;
                        numLetra[curNumLetra] = letra;
                        curNumLetra++;
                    }
                        break;
                    case 4:
                    if (!boolLetras[3])
                    {
                        R.velocity = new Vector3(curVel, 0);
                        isOnKey = true;
                        letra = 'r';
                        R.transform.position = new Vector3(7.38f, -3.5f, -1);
                        boolLetras[3] = true;
                        numLetra[curNumLetra] = letra;
                        curNumLetra++;
                    }
                        break;
                    case 5:
                    if (!boolLetras[4])
                    {
                        U.velocity = new Vector3(curVel, 0);
                        isOnKey = true;
                        letra = 'u';
                        U.transform.position = new Vector3(7.38f, -3.5f, -1);
                        boolLetras[4] = true;
                        numLetra[curNumLetra] = letra;
                        curNumLetra++;
                    }
                        break;
                    case 6:
                    if (!boolLetras[5])
                    {
                        I.velocity = new Vector3(curVel, 0);
                        isOnKey = true;
                        letra = 'i';
                        I.transform.position = new Vector3(7.38f, -3.5f, -1);
                        boolLetras[5] = true;
                        numLetra[curNumLetra] = letra;
                        curNumLetra++;
                    }
                        break;
                    case 7:
                    if (!boolLetras[6])
                    {
                        O.velocity = new Vector3(curVel, 0);
                        isOnKey = true;
                        letra = 'o';
                        O.transform.position = new Vector3(7.38f, -3.5f, -1);
                        boolLetras[6] = true;
                        numLetra[curNumLetra] = letra;
                        curNumLetra++;
                    }
                        break;
                    case 8:
                    if (!boolLetras[7])
                    {
                        P.velocity = new Vector3(curVel, 0);
                        isOnKey = true;
                        letra = 'p';
                        P.transform.position = new Vector3(7.38f, -3.5f, -1);
                        boolLetras[7] = true;
                        numLetra[curNumLetra] = letra;
                        curNumLetra++;
                    }
                        break;
                }
                if (curNumLetra == 8)
                {
                curNumLetra = 0;
                }
                curTime = startTime;
                //lastTecla = tecla;
            //}
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tecla")
        {
            canPress = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckCol(Q);
        CheckCol(W);
        CheckCol(E);
        CheckCol(R);
        CheckCol(U);
        CheckCol(I);
        CheckCol(O);
        CheckCol(P);
    }

    void CheckCol(Rigidbody2D RB)
    {
        if (RB.gameObject.name == "Tecla")
        {
            StopAll(Q);
            StopAll(W);
            StopAll(E);
            StopAll(R);
            StopAll(U);
            StopAll(I);
            StopAll(O);
            StopAll(P);
        }
    }

    void StopAll(Rigidbody2D RB)
    {
        RB.transform.position = new Vector3(14.06f, -2.63f, -1);
        RB.velocity = new Vector3(0, 0);
        end = true;
        curTimeToWait = timeToWait;
        nextKeyToPress = 0;
        curNumLetra = 0;
        Melodia.Pause();
        numChungo = 0;
        isOnMusic = false;
        musicBool = true;
        for (int i = 0; i < 8; i++)
        {
            boolLetras[i] = false;
        }
    }



    public void checkClick()
    {
        if (canPress)
        {
            if (Input.GetKeyDown(KeyCode.Q) && boolLetras[0] && numLetra[nextKeyToPress] == 'q')
            {
                Q.transform.position = new Vector3(11.13f, -2.55f, -1);
                Q.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                isOnKey = false;
                canPress = false;
                boolLetras[0] = false;
                nextKeyToPress++;
            }
            else if (Input.GetKeyDown(KeyCode.W) && boolLetras[1] && numLetra[nextKeyToPress] == 'w')
            {
                W.transform.position = new Vector3(11.28f, 0.14f, -1);
                W.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                isOnKey = false;
                canPress = false;
                boolLetras[1] = false;
                nextKeyToPress++;
            }
            else if (Input.GetKeyDown(KeyCode.E) && boolLetras[2] && numLetra[nextKeyToPress] == 'e')
            {
                E.transform.position = new Vector3(14.32f, 0.13f, -1);
                E.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                isOnKey = false;
                canPress = false;
                boolLetras[2] = false;
                nextKeyToPress++;
            }
            else if (Input.GetKeyDown(KeyCode.R) && boolLetras[3] && numLetra[nextKeyToPress] == 'r')
            {
                R.transform.position = new Vector3(14.06f, -2.63f, -1);
                R.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                isOnKey = false;
                canPress = false;
                boolLetras[3] = false;
                nextKeyToPress++;
            }
            else if (Input.GetKeyDown(KeyCode.U) && boolLetras[4] && numLetra[nextKeyToPress] == 'u')
            {
                U.transform.position = new Vector3(18.13f, -0.01f, -1);
                U.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                isOnKey = false;
                canPress = false;
                boolLetras[4] = false;
                nextKeyToPress++;
            }
            else if (Input.GetKeyDown(KeyCode.I) && boolLetras[5] && numLetra[nextKeyToPress] == 'i')
            {
                I.transform.position = new Vector3(18.16f, -2.41f, -1);
                I.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                isOnKey = false;
                canPress = false;
                boolLetras[5] = false;
                nextKeyToPress++;
            }
            else if (Input.GetKeyDown(KeyCode.O) && boolLetras[6] && numLetra[nextKeyToPress] == 'o')
            {
                O.transform.position = new Vector3(21.33f, 0.03f, -1);
                O.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                isOnKey = false;
                canPress = false;
                boolLetras[6] = false;
                nextKeyToPress++;
            }
            else if (Input.GetKeyDown(KeyCode.P) && boolLetras[7] && numLetra[nextKeyToPress] == 'p')
            {
                P.transform.position = new Vector3(21.49f, -2.56f, -1);
                P.velocity = new Vector3(0, 0);
                Debug.Log("KeyPressed");
                isOnKey = false;
                canPress = false;
                boolLetras[7] = false;
                nextKeyToPress++;
            }
            else if (Input.anyKeyDown)
            {
                StopAll(Q);
                StopAll(W);
                StopAll(E);
                StopAll(R);
                StopAll(U);
                StopAll(I);
                StopAll(O);
                StopAll(P);
                end = true;
                //Putear al Jugador
                Debug.Log("TusMuertos");
                //Fase++;
                //FaseParaMonstruo = Fase;
                //if (Fase == 7)
                //{
                //    Fase = 0;
                //}
            }
            if (nextKeyToPress == 8)
            {
                nextKeyToPress = 0;
            }
        }
        else if (!canPress)
        { 
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StopAll(Q);
                StopAll(W);
                StopAll(E);
                StopAll(R);
                StopAll(U);
                StopAll(I);
                StopAll(O);
                StopAll(P);
                end = true;
                //Putear al Jugador
                Debug.Log("TusMuertos");
                //Fase++;
                //FaseParaMonstruo = Fase;
                //if (Fase == 7)
                //{
                //    Fase = 0;
                //}
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                StopAll(Q);
                StopAll(W);
                StopAll(E);
                StopAll(R);
                StopAll(U);
                StopAll(I);
                StopAll(O);
                StopAll(P);
                end = true;
                //Putear al Jugador
                Debug.Log("TusMuertos");
                //Fase++;
                //FaseParaMonstruo = Fase;
                //if (Fase == 7)
                //{
                //    Fase = 0;
                //}
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                StopAll(Q);
                StopAll(W);
                StopAll(E);
                StopAll(R);
                StopAll(U);
                StopAll(I);
                StopAll(O);
                StopAll(P);
                end = true;
                //Putear al Jugador
                Debug.Log("TusMuertos");
                //Fase++;
                //FaseParaMonstruo = Fase;
                //if (Fase == 7)
                //{
                //    Fase = 0;
                //}
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StopAll(Q);
                StopAll(W);
                StopAll(E);
                StopAll(R);
                StopAll(U);
                StopAll(I);
                StopAll(O);
                StopAll(P);
                end = true;
                //Putear al Jugador
                Debug.Log("TusMuertos");
                //Fase++;
                //FaseParaMonstruo = Fase;
                //if (Fase == 7)
                //{
                //    Fase = 0;
                //}
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                StopAll(Q);
                StopAll(W);
                StopAll(E);
                StopAll(R);
                StopAll(U);
                StopAll(I);
                StopAll(O);
                StopAll(P);
                end = true;
                //Putear al Jugador
                Debug.Log("TusMuertos");
                //Fase++;
                //FaseParaMonstruo = Fase;
                //if (Fase == 7)
                //{
                //    Fase = 0;
                //}
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                StopAll(Q);
                StopAll(W);
                StopAll(E);
                StopAll(R);
                StopAll(U);
                StopAll(I);
                StopAll(O);
                StopAll(P);
                end = true;
                //Putear al Jugador
                Debug.Log("TusMuertos");
                //Fase++;
                //FaseParaMonstruo = Fase;
                //if (Fase == 7)
                //{
                //    Fase = 0;
                //}
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                StopAll(Q);
                StopAll(W);
                StopAll(E);
                StopAll(R);
                StopAll(U);
                StopAll(I);
                StopAll(O);
                StopAll(P);
                end = true;
                //Putear al Jugador
                Debug.Log("TusMuertos");
                //Fase++;
                //FaseParaMonstruo = Fase;
                //if (Fase == 7)
                //{
                //    Fase = 0;
                //}
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                StopAll(Q);
                StopAll(W);
                StopAll(E);
                StopAll(R);
                StopAll(U);
                StopAll(I);
                StopAll(O);
                StopAll(P);
                end = true;
                //Putear al Jugador
                Debug.Log("TusMuertos");
                //Fase++;
                //FaseParaMonstruo = Fase;
                //if (Fase == 7)
                //{
                //    Fase = 0;
                //}
            }
        }
    }
}
