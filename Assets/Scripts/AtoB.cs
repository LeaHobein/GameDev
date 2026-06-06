using UnityEngine;
using System.Collections;
using System;

public class AtoB : MonoBehaviour
{

    public GameObject Mover;
    public GameObject A;
    public GameObject B;
    public float speed;
    private float tempo;
    //private float distance;
    private bool goal = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Mover.transform.position = A.transform.position;
        tempo = speed;
        Mover.transform.Rotate(0f, 180f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(goal == false)
        {
            if(Mover.transform.position == B.transform.position)
            {
                goal = true;
                Mover.transform.Rotate(0f, 180f, 0f);
                StartCoroutine(delay(3f));
                Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, A.transform.position, tempo);
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
                Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, B.transform.position, tempo);
            }else
            {
                toa(); 
            }
        }
        
    }

    private void toa(){
        Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, A.transform.position, tempo);
    }
    private void tob(){
        Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, B.transform.position, tempo);
    }

    private IEnumerator delay(float duration)
    {
        tempo = 0f;
        yield return new WaitForSeconds(duration);
        tempo = speed;
    }
}
