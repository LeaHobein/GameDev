using UnityEngine;

public class AtoB : MonoBehaviour
{

    public GameObject Mover;
    public GameObject A;
    public GameObject B;
    public float speed;
    private float goal = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Mover.transform.position = A.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(goal == 0f)
        {
            Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, B.transform.position, speed);
            if(Mover.transform.position == B.transform.position)
            {
                goal = 1f;
            }
        }
        else if(goal == 1f)
        {
            Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, A.transform.position, speed);
            if(Mover.transform.position == A.transform.position)
            {
                goal = 0f;
            }
        }
    }
}
