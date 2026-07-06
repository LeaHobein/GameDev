using UnityEngine;

public class CtoD : MonoBehaviour
{
    public GameObject C;
    public GameObject D;
    public float speed;
    public float tempo;
    public bool goal = false;
    void Start()
    {
        gameObject.transform.position = C.transform.position;
        tempo = 0f;
    }
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
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, D.transform.position, tempo * Time.deltaTime);
    }
}
