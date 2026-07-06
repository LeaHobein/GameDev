using UnityEngine;

public class OnA : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {      
            other.GetComponent<AtoB>().onB = false;
            other.GetComponent<AtoB>().StartCoroutine(other.GetComponent<AtoB>().delay(UnityEngine.Random.Range(3, 9)));
        }
    }
}
