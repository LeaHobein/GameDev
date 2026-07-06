using UnityEngine;

public class OnB : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<AtoB>().onB = true;
            other.GetComponent<AtoB>().StartCoroutine(other.GetComponent<AtoB>().delay(UnityEngine.Random.Range(3, 9)));
        }
    }
}
