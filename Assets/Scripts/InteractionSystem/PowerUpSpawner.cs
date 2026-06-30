using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), 10f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }


    [System.Serializable]
    public class PowerUpEntry
    {
        public GameObject prefab;
        public PowerUp.PowerUpType type;
    }

    public PowerUpEntry[] powerUps;

    public Transform[] spawnPoints;

    public float spawnInterval = 10f;

    private GameObject currentPowerUp;

    public TimeManager timeManager;
    //public InteractionController interactionController;
    public bool PowerUpOnField = false;

    private void SpawnPowerUp()
    {
        if (/*currentPowerUp != null &&*/PowerUpOnField || timeManager.gamePlaying == false)
            return;

        int powerUpIndex = Random.Range(0, powerUps.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        GameObject obj = Instantiate(
            powerUps[powerUpIndex].prefab,
            spawnPoints[spawnIndex].position,
            Quaternion.identity
        );

        obj.GetComponent<PowerUp>().type = powerUps[powerUpIndex].type;
        PowerUpOnField = true;
        currentPowerUp = obj;
    }

}
