using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class DeliverySpot : MonoBehaviour, IInteractable
{
    public bool occupado = false;
    public bool isBlocked = false;
    public static System.Collections.Generic.List<DeliverySpot> allSpots = new();
    void Start()
    {
        allSpots.Add(this);
    }
    void Update()
    {
        transform.Find("spawnee").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("spawnee2").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("spawnee3").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("spawnee4").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("spawnee5").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("spawnee6").transform.Rotate(0f, 1f, 0f, Space.World);
    }

    void deliver(GameObject player)
    {
        if (player.transform.Find("hold1").GetComponent<MeshRenderer>().enabled == true)
        {
            player.transform.Find("hold1").GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.Find("spawnee").GetComponent<MeshRenderer>().enabled = true;
            player.GetComponent<InteractionController>().holding = false;
        }
        else if (player.transform.Find("hold2").GetComponent<MeshRenderer>().enabled == true)
        {
            player.transform.Find("hold2").GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.Find("spawnee2").GetComponent<MeshRenderer>().enabled = true;
            player.GetComponent<InteractionController>().holding = false;
        }
        else if (player.transform.Find("hold3").GetComponent<MeshRenderer>().enabled == true)
        {
            player.transform.Find("hold3").GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.Find("spawnee3").GetComponent<MeshRenderer>().enabled = true;
            player.GetComponent<InteractionController>().holding = false;
        }
        else if (player.transform.Find("hold4").GetComponent<MeshRenderer>().enabled == true)
        {
            player.transform.Find("hold4").GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.Find("spawnee4").GetComponent<MeshRenderer>().enabled = true;
            player.GetComponent<InteractionController>().holding = false;
        }
        else if (player.transform.Find("hold5").GetComponent<MeshRenderer>().enabled == true)
        {
            player.transform.Find("hold5").GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.Find("spawnee5").GetComponent<MeshRenderer>().enabled = true;
            player.GetComponent<InteractionController>().holding = false;
        }
        else if (player.transform.Find("hold6").GetComponent<MeshRenderer>().enabled == true)
        {
            player.transform.Find("hold6").GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.Find("spawnee6").GetComponent<MeshRenderer>().enabled = true;
            player.GetComponent<InteractionController>().holding = false;
        }
        player.transform.Find("robot_arms_full").gameObject.transform.Rotate(0f, 0f, 90f);
        player.transform.Find("robot_arms_full").gameObject.transform.Translate(1f, -1f, 0f);
    }

    void pickup(GameObject player)
    {
        if (transform.Find("spawnee").GetComponent<MeshRenderer>().enabled == true)
        {
            transform.Find("spawnee").GetComponent<MeshRenderer>().enabled = false;
            player.transform.Find("hold1").GetComponent<MeshRenderer>().enabled = true;
            player.GetComponent<InteractionController>().holding = true;
        }
        else if (transform.Find("spawnee2").GetComponent<MeshRenderer>().enabled == true)
        {
            transform.Find("spawnee2").GetComponent<MeshRenderer>().enabled = false;
            player.transform.Find("hold2").GetComponent<MeshRenderer>().enabled = true;
            player.GetComponent<InteractionController>().holding = true;
        }
        else if (transform.Find("spawnee3").GetComponent<MeshRenderer>().enabled == true)
        {
            transform.Find("spawnee3").GetComponent<MeshRenderer>().enabled = false;
            player.transform.Find("hold3").GetComponent<MeshRenderer>().enabled = true;
            player.GetComponent<InteractionController>().holding = true;
        }
        else if (transform.Find("spawnee4").GetComponent<MeshRenderer>().enabled == true)
        {
            transform.Find("spawnee4").GetComponent<MeshRenderer>().enabled = false;
            player.transform.Find("hold4").GetComponent<MeshRenderer>().enabled = true;
            player.GetComponent<InteractionController>().holding = true;
        }
        else if (transform.Find("spawnee5").GetComponent<MeshRenderer>().enabled == true)
        {
            transform.Find("spawnee5").GetComponent<MeshRenderer>().enabled = false;
            player.transform.Find("hold5").GetComponent<MeshRenderer>().enabled = true;
            player.GetComponent<InteractionController>().holding = true;
        }
        else if (transform.Find("spawnee6").GetComponent<MeshRenderer>().enabled == true)
        {
            transform.Find("spawnee6").GetComponent<MeshRenderer>().enabled = false;
            player.transform.Find("hold6").GetComponent<MeshRenderer>().enabled = true;
            player.GetComponent<InteractionController>().holding = true;
        }
        player.transform.Find("robot_arms_full").gameObject.transform.Translate(-1f, 1f, 0f);
        player.transform.Find("robot_arms_full").gameObject.transform.Rotate(0f, 0f, -90f);
    }

    public void Interact(GameObject player)
    {
        if (isBlocked)
        {
            AudioManager.Instance.Play(AudioManager.SoundType.Fail);
            return;
        }

        if (player.GetComponent<InteractionController>().holding == true && occupado == false)
        {
            deliver(player);
            occupado = true;
        }
        else if (player.GetComponent<InteractionController>().holding == false && occupado == true)
        {
            pickup(player);
            occupado = false;
        }
    }

    public void BlockForSeconds(float duration)
    {
        StartCoroutine(BlockCoroutine(duration));
    }

    private IEnumerator BlockCoroutine(float duration)
    {
        isBlocked = true;

        yield return new WaitForSeconds(duration);

        isBlocked = false;
    }

    void OnDestroy()
    {
        allSpots.Remove(this);
    }
}
