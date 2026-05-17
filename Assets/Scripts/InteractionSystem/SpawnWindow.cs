using UnityEngine;

public class SpawnWindow : MonoBehaviour, IInteractable
{
    [SerializeField]
    GameObject spawnPrefab;

    void Spawn()
    {
        var spawnedObject = Instantiate(spawnPrefab, transform.position + Vector3.up, Quaternion.identity);

        var randomSize = Random.Range(0.1f, 1f);
        spawnedObject.transform.localScale *= randomSize;
    }

    public void Interact()
    {
        Spawn();
    }
}
