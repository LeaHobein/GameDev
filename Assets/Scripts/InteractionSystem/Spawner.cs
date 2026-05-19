using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour, IInteractable
{
    [SerializeField]
    GameObject spawnPrefab;

    [SerializeField]
    GameObject spawner;

    [SerializeField]
    GameObject spot;

    private GameObject hold;
    private bool holding;

    void Start()
    {
        
    }

    void Update()
    {
        if(holding == true){
            Debug.Log("Spawner position:" + spawner.transform.position);
            hold.transform.position = spawner.transform.position;
        }

        if(Keyboard.current.hKey.wasPressedThisFrame){
            hold.transform.position = spot.transform.position;
            holding = false;
            print("object is gone");
        }
    }

    void Spawn()
    {
        holding = true;
        print("player is holding object");
        hold = Instantiate(spawnPrefab, spawner.transform.position + Vector3.up, Quaternion.identity);

        var randomSize = Random.Range(0.1f, 1f);
        hold.transform.localScale *= randomSize;
    }

    public void Interact()
    {
        if(holding == false){
            Spawn();
        }
    }
}
