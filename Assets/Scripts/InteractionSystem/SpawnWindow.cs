using UnityEngine;

public class SpawnWindow : MonoBehaviour, IInteractable
{
    [SerializeField]
    GameObject spawnPrefab;

    [SerializeField]
    GameObject spawner;

    void Spawn()
    {
        var spawnedObject = Instantiate(spawnPrefab, spawner.transform.position + Vector3.up, Quaternion.identity);

        var randomSize = Random.Range(0.1f, 1f);
        spawnedObject.transform.localScale *= randomSize;
    }

    public void Interact()
    {
        Spawn();
    }
}
