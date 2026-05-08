using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Enter");
            other.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f);
            //Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        print("Exit");
        other.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f);
    }
}
