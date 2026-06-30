using UnityEngine;
using System.Collections;
using System;
using UnityEditor.Experimental.GraphView;

public class AtoB : MonoBehaviour
{
    public GameObject Mover;
    public GameObject A;
    public GameObject B;
    public float defaultSpeed;
    public float speed; //private float defaultspeed
    public TimeManager timeManager;
    //private float distance;
    public bool goal = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeManager = GameObject.Find("timerText").GetComponent<TimeManager>();
        Mover.transform.position = A.transform.position;
        speed = defaultSpeed;
        //Mover.transform.Rotate(0f, 180f, 0f);
    }

    // Update is called once per frame
    void Update() //public moveToPoint Methode stattdessen, ziel gameobject �bergeben
    {
        bool inGame = timeManager.gamePlaying;
        if(GameObject.Find("Player1").GetComponent<UI_Notfalloptionen_Manager>().NotfallOptionenActive) speed = 0f;
        
        //trigger Volumes benutzen!!!
        //UND eigene Coroutine!!!
        else if(goal == false && inGame)
        {
            tob();
        }else if(goal == true && inGame)
        {
            toa();
        }

        /*
        if(goal == false)
        {
            if(Mover.transform.position == B.transform.position)
            {
                goal = true;
                Mover.transform.Rotate(0f, 180f, 0f);
                StartCoroutine(delay(3f));
                Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, A.transform.position, speed);
            }else
            {
                tob();
            }
        }
        else if(goal == true)
        {
            if(Mover.transform.position == A.transform.position)
            {
                goal = false;
                Mover.transform.Rotate(0f, 180f, 0f);
                StartCoroutine(delay(3f));
                Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, B.transform.position, speed);
            }else
            {
                toa(); 
            }
        }
        */
    }

    private void toa(){
        Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, A.transform.position, speed * Time.deltaTime);
    }
    private void tob(){
        Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, B.transform.position, speed * Time.deltaTime);
    }

    public IEnumerator delay(float duration)
    {
        Debug.Log("Coroutine executed");
        speed = 0f;
        yield return new WaitForSeconds(duration);
        speed = defaultSpeed;
        //speed = 10;
        AudioManager.Instance.Play(AudioManager.SoundType.ForkliftSwoosh);

        Mover.transform.Rotate(0f, 180f, 0f);
    }
}
