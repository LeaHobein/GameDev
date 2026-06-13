using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            print("Enter");

            var movement = other.GetComponentInParent<PlayerMovement>();
            if (movement != null)
                movement.Stun(1f); //Stun duration

            other.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            print("Exit");
            other.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f);
        }
    }
}
