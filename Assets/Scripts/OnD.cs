using UnityEngine;

public class OnD : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            other.GetComponent<CtoD>().goal = false;
            other.transform.position = other.GetComponent<CtoD>().C.transform.position;
        }
    }
}
