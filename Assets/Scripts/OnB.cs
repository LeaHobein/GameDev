using UnityEngine;

public class OnB : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            print("Enter on B");

            other.GetComponent<AtoB>().goal = true;
            other.GetComponent<AtoB>().StartCoroutine(other.GetComponent<AtoB>().delay(UnityEngine.Random.Range(3, 9)));
        }
    }
}
