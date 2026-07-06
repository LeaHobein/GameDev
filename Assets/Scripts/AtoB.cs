using System.Collections;
using UnityEngine;

public class AtoB : MonoBehaviour
{
    public GameObject Mover;
    public GameObject A;
    public GameObject B;
    public float defaultSpeed;
    public float speed;
    public TimeManager timeManager;
    public bool onB = false;
    public bool isOnAB;
    void Start()
    {
        timeManager = GameObject.Find("timerText").GetComponent<TimeManager>();
        Mover.transform.position = A.transform.position;
        speed = defaultSpeed;
    }
    void Update()
    {
        bool inGame = timeManager.gamePlaying;
        if(GameObject.Find("Player1").GetComponent<UI_Notfalloptionen_Manager>().NotfallOptionenActive) speed = 0f;

        else if(onB == false && inGame)
        {
            tob();
        }else if(onB == true && inGame)
        {
            toa();
        }
    }
    private void toa(){
        Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, A.transform.position, speed * Time.deltaTime);
    }
    private void tob(){
        Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, B.transform.position, speed * Time.deltaTime);
    }

    public IEnumerator delay(float duration)
    {
        speed = 0f;
        isOnAB = true;
        yield return new WaitForSeconds(duration);
        speed = defaultSpeed;
        Mover.transform.Rotate(0f, 180f, 0f);
        isOnAB = false;
    }
}
