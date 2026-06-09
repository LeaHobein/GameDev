using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class WasteBin : MonoBehaviour, IInteractable
{
    //public GameObject other;
   /*void Update()
    {
        if(Keyboard.current.xKey.wasPressedThisFrame)
        {
        Destroy(other);
        Debug.Log("Item deleted");
        }

    }*/


    void DestroyItem(GameObject player)
    {
        player.transform.Find("hold1").GetComponent<MeshRenderer>().enabled = false;
        player.transform.Find("hold2").GetComponent<MeshRenderer>().enabled = false;
    }


    public void Interact(GameObject player)
    {
       DestroyItem(player);
    }
}
