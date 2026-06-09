using UnityEngine;
using UnityEngine.InputSystem;

public class DeliverySpot : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Find("spawnee").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("spawnee2").transform.Rotate(0f, 1f, 0f, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("spawnee").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("spawnee2").transform.Rotate(0f, 1f, 0f, Space.World);
    }

    void deliver(GameObject player)
    {
        player.GetComponent<InteractionController>().holding = false;
        if(player.transform.Find("hold1").GetComponent<MeshRenderer>().enabled == true){
            player.transform.Find("hold1").GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.Find("spawnee").GetComponent<MeshRenderer>().enabled = true;
            print("player delivered: spawnee");
        }
        else if(player.transform.Find("hold2").GetComponent<MeshRenderer>().enabled == true){
            player.transform.Find("hold2").GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.Find("spawnee2").GetComponent<MeshRenderer>().enabled = true;
            print("player delivered: spawnee2");
        }
        else{
            print("nothing to deliver/pickup");
        }
    }

    void pickup(GameObject player)
    {
        player.GetComponent<InteractionController>().holding = true;
        if(transform.Find("spawnee").GetComponent<MeshRenderer>().enabled == true){
            transform.Find("spawnee").GetComponent<MeshRenderer>().enabled = false;
            player.transform.Find("hold1").GetComponent<MeshRenderer>().enabled = true;
            print("player picked up: spawnee");
        }
        else if(transform.Find("spawnee2").GetComponent<MeshRenderer>().enabled == true){
            transform.Find("spawnee2").GetComponent<MeshRenderer>().enabled = false;
            player.transform.Find("hold2").GetComponent<MeshRenderer>().enabled = true;
            print("player picked up: spawnee2");
        }
        else{
            print("nothing to pick up...");
        }
    }

    public void Interact(GameObject player)
    {
        if(player.GetComponent<InteractionController>().holding == true){
            deliver(player);
        }else if(player.GetComponent<InteractionController>().holding == false){
            pickup(player);
        }
    }
}
