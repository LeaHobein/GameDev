using UnityEngine;

public class CtoD : MonoBehaviour
{
    //public GameObject Mover;
    public GameObject C;
    public GameObject D;
    public float speed;
    public float tempo;
    public bool goal = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.transform.position = C.transform.position;
        tempo = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(goal == false)
        {
            tempo = 0f;
        }else
        {
            tempo = speed;
            tod();
        }
    }

    private void tod(){
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, D.transform.position, tempo);
    }
}
