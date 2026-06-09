using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour, IInteractable
{
    //[SerializeField]
    //GameObject spawnPrefab;

    //[SerializeField]
    //GameObject spawner;

    //[SerializeField]
    //GameObject spot;

    //private GameObject hold;
    //private bool holding;

    void Start()
    {
        
    }

    void Update()
    {
        /*
        if(holding == true){
            //Debug.Log("Spawner position:" + spawner.transform.position);
            //hold.transform.position = spawner.transform.position;
        }

        if(Keyboard.current.hKey.wasPressedThisFrame){
            //hold.transform.position = spot.transform.position;
            holding = false;
            print("object is gone");
        }
        */
    }

    void Spawn(GameObject player)
    {
        // Enable Mesh Renderer of Coin in Player Prefab that interacted with this box
        //player. //.GetComponent<MeshRenderer>().enabled = true;
        if(gameObject.name == "box1"){
            player.transform.Find("hold1").GetComponent<MeshRenderer>().enabled = true;
        }else if(gameObject.name == "box2"){
            player.transform.Find("hold2").GetComponent<MeshRenderer>().enabled = true;
        }else if (gameObject.name == "box3"){
            player.transform.Find("hold3").GetComponent<MeshRenderer>().enabled = true;
        }else if (gameObject.name == "box4"){
            player.transform.Find("hold4").GetComponent<MeshRenderer>().enabled = true;
        }else if (gameObject.name == "box5"){
            player.transform.Find("hold5").GetComponent<MeshRenderer>().enabled = true;
        }else if (gameObject.name == "box6"){
            player.transform.Find("hold6").GetComponent<MeshRenderer>().enabled = true;
        }

        //holding = true;
        print("player is holding object");
        /*
        hold = Instantiate(spawnPrefab, spawner.transform.position + Vector3.up, Quaternion.identity);

        var randomSize = Random.Range(0.1f, 1f);
        hold.transform.localScale *= randomSize;
        */
    }

    public void Interact(GameObject player)
    {
        if(player.GetComponent<InteractionController>().holding == false){
            Spawn(player);
            player.GetComponent<InteractionController>().holding = true;
        }
        else
        {
            player.GetComponent<InteractionController>().holding = false;
            transform.Find("hold1").GetComponent<MeshRenderer>().enabled = false;
            transform.Find("hold2").GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
