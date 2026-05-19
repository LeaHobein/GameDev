using UnityEngine;
using System.Collections;

public class AtoB : MonoBehaviour
{

    public GameObject Mover;
    public GameObject A;
    public GameObject B;
    public float speed;
    private float tempo;
    private float goal = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Mover.transform.position = A.transform.position;
        tempo = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(goal == 0f)
        {
            StartCoroutine(delayona(3f));
        }
        else if(goal == 1f)
        {
            StartCoroutine(delayonb(3f));
        }
    }

    private IEnumerator delayona(float duration){
        if(Mover.transform.position == A.transform.position)
            {
                tempo = 0f;
                yield return new WaitForSeconds(duration);
                tempo = speed;
            }

        Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, B.transform.position, tempo);
        if(Mover.transform.position == B.transform.position)
        {
            goal = 1f;
        }
    }
    private IEnumerator delayonb(float duration){
        if(Mover.transform.position == B.transform.position)
            {
                tempo = 0f;
                yield return new WaitForSeconds(duration);
                tempo = speed;
            }
        
        Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, A.transform.position, tempo);
        if(Mover.transform.position == A.transform.position)
        {
            goal = 0f;
        }
    }
}
