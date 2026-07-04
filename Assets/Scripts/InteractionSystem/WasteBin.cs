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
        gameObject.GetComponent<Animator>().SetTrigger("throw");

        if (player.GetComponent<InteractionController>().holding)
        {
            player.transform.Find("robot_arms_full").gameObject.transform.Rotate(0f,0f,90f);
            player.transform.Find("robot_arms_full").gameObject.transform.Translate(1f,-1f,0f);
        }
        player.transform.Find("hold1").GetComponent<MeshRenderer>().enabled = false;
        player.transform.Find("hold2").GetComponent<MeshRenderer>().enabled = false;
        player.transform.Find("hold3").GetComponent<MeshRenderer>().enabled = false;
        player.transform.Find("hold4").GetComponent<MeshRenderer>().enabled = false;
        player.transform.Find("hold5").GetComponent<MeshRenderer>().enabled = false;
        player.transform.Find("hold6").GetComponent<MeshRenderer>().enabled = false;
        player.GetComponent<InteractionController>().holding = false;
    }


    public void Interact(GameObject player)
    {
       DestroyItem(player);
    }
}
