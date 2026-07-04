using UnityEngine;
using System.Collections;

public class AtoB : MonoBehaviour
{
    public GameObject Mover;
    public GameObject A;
    public GameObject B;
    public float defaultSpeed;
    public float speed; //private float defaultspeed
    public TimeManager timeManager;
    //private float distance;
    public bool onB = false;
    public bool isOnAB;

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
        else if(onB == false && inGame)
        {
            tob();
        }else if(onB == true && inGame)
        {
            toa();
        }

        /*
        if(onB == false)
        {
            if(Mover.transform.position == B.transform.position)
            {
                onB = true;
                Mover.transform.Rotate(0f, 180f, 0f);
                StartCoroutine(delay(3f));
                Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, A.transform.position, speed);
            }else
            {
                tob();
            }
        }
        else if(onB == true)
        {
            if(Mover.transform.position == A.transform.position)
            {
                onB = false;
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
        isOnAB = true;
        yield return new WaitForSeconds(duration);
        speed = defaultSpeed;
        //speed = 10;
        AudioManager.Instance.Play(AudioManager.SoundType.ForkliftSwoosh);

        Mover.transform.Rotate(0f, 180f, 0f);

        isOnAB = false;
    }
}
