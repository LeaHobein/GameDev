using UnityEngine;

public class Spawner : MonoBehaviour, IInteractable
{
    void Spawn(GameObject player)
    {
        // Enable Mesh Renderer of Coin in Player Prefab that interacted with this box
        //player. //.GetComponent<MeshRenderer>().enabled = true;
        if(gameObject.name == "box1"){
            player.transform.Find("hold1").GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Animator>().SetTrigger("picking1");
        }else if(gameObject.name == "box2"){
            player.transform.Find("hold2").GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Animator>().SetTrigger("picking2");
        }else if (gameObject.name == "box3"){
            player.transform.Find("hold3").GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Animator>().SetTrigger("picking3");
        }else if (gameObject.name == "box4"){
            player.transform.Find("hold4").GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Animator>().SetTrigger("picking4");
        }else if (gameObject.name == "box5"){
            player.transform.Find("hold5").GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Animator>().SetTrigger("picking5");
        }else if (gameObject.name == "box6"){
            player.transform.Find("hold6").GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Animator>().SetTrigger("picking6");
        }
        player.transform.Find("robot_arms_full").gameObject.transform.Translate(-1f,1f,0f);
        player.transform.Find("robot_arms_full").gameObject.transform.Rotate(0f,0f,-90f);
    }

    public void Interact(GameObject player)
    {
        if(player.GetComponent<InteractionController>().holding == false){
            Spawn(player);
            player.GetComponent<InteractionController>().holding = true;
        }
    }
}
