using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monstruo : MonoBehaviour {

    public bool isOnRay;
    public int numRay = 1;
    public int Fase;
    public int numSonido;
    public float startTime;
    public float curTime;
    public int typeOfEvent;
    private int numPos;
    public Image Background;
    public Image SolidBackgronud;
    public Sprite SpriteRay;
    public Sprite SpriteDark;
    public Sprite SpriteBackgroundRay;
    public Sprite SpriteBackgroundDark;

    public SpriteRenderer Lamp;
    public SpriteRenderer Fitment;
    public SpriteRenderer Bulb;
    public SpriteRenderer Bin;

    public Sprite RayLamp;
    public Sprite RayFitment;
    public Sprite RayBulb;
    public Sprite RayBin;

    public Sprite DarkLamp;
    public Sprite DarkFitment;
    public Sprite DarkBulb;
    public Sprite DarkBin;

    public double rayTime;
    public double curRayTime;
    System.Random RandomNum = new System.Random();
    public SkinnedMeshRenderer SpriteTorso;
    public SkinnedMeshRenderer SpriteBrazoDer;
    public SkinnedMeshRenderer SpriteBrazoIzq;
    public SkinnedMeshRenderer SpriteCara;
    public AudioSource AudioRayo;
    public static int FaseParaPiano;
    public bool end;


    // Use this for initialization
    void Start () {
        curTime = startTime;
        curRayTime = rayTime;
        //SpriteMonster = GameObject.FindGameObjectWithTag("New Prefab").GetComponent<SpriteRenderer>();
        //SpriteMonster.enabled = false;
        MeshMonster(false);
    }
	
	// Update is called once per frame
	void Update () { 
        //Fase = Piano.FaseParaMonstruo;
        Monster();
        Sonidos();
        OnRay();

    }

    void MeshMonster(bool Monster)
    {
        if (!Monster)
        {
            SpriteTorso.enabled = false;
            SpriteBrazoDer.enabled = false;
            SpriteBrazoIzq.enabled = false;
            SpriteCara.enabled = false;
        }
        else if (Monster)
        {
            SpriteTorso.enabled = true;
            SpriteBrazoDer.enabled = true;
            SpriteBrazoIzq.enabled = true;
            SpriteCara.enabled = true;
        }
    }

    void Objects(bool Ray)
    {
        if (Ray)
        {
            Lamp.sprite = RayLamp;
            Fitment.sprite = RayFitment;
            Bulb.sprite = RayBulb;
            Bin.sprite = RayBin;
        }
        else if (!Ray)
        {
            Lamp.sprite = DarkLamp;
            Fitment.sprite = DarkFitment;
            Bulb.sprite = DarkBulb;
            Bin.sprite = DarkBin;
        }
    }

    void Monster()
    {
        if (curTime <= 0 && !end)
        {

                Fase = RandomNum.Next(1, 9);
                FaseParaPiano = Fase;
                //typeOfEvent = RandomNum.Next(1, 3);
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
        //if (curTime <= 0 && numSonido == 1 && typeOfEvent == 1)
        //{
        //    //Play Sound 1
        //    typeOfEvent = 0;
        //}
        //else if (curTime <= 0 && numSonido == 2 && typeOfEvent == 1)
        //{
        //    //Play Sound 2
        //    typeOfEvent = 0;
        //}
        //else if (curTime <= 0 && numSonido == 3 && typeOfEvent == 1)
        //{
        //    //Play Sound 3
        //    typeOfEvent = 0;
        end = Piano.endParaMonstruo;
        if (curTime <= 0 && !end)
        {
            //Background.sprite = Resources.Load("Ray_Room") as Sprite;
            Background.sprite = SpriteRay;
            SolidBackgronud.sprite = SpriteBackgroundRay;
            isOnRay = true;
            Objects(true);
            typeOfEvent = 0;
        }
    }
    void OnRay()
    {
        if (isOnRay)
        {
            curRayTime -= Time.deltaTime;
            if (curRayTime <= 0 && numRay == 1)
            {
                AudioRayo.Play();
                MeshMonster(true);
                Objects(false);
                SolidBackgronud.sprite = SpriteBackgroundDark;
                curRayTime = rayTime;
                Background.sprite = SpriteDark;
                numRay++;               
            }
            else if (curRayTime <= 0 && numRay == 2)
            {
                Objects(true);
                SolidBackgronud.sprite = SpriteBackgroundRay;
                curRayTime = rayTime;
                Background.sprite = SpriteRay;
                numRay++;
            }
            else if (curRayTime <= 0 && numRay == 3)
            {
                Objects(false);
                SolidBackgronud.sprite = SpriteBackgroundDark;
                curRayTime = rayTime;
                Background.sprite = SpriteDark;
                isOnRay = false;
                numRay = 1;
                MeshMonster(false);
            }
        }
    }
}
