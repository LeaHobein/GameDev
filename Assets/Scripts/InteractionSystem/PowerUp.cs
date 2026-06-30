using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerUpSpawner = GameObject.Find("PowerUp_SpawnPoints").GetComponent<PowerUpSpawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public enum PowerUpType
    {
        AddTime,
        SpeedBoost,
        DoubleScore
    }

    public PowerUpType type;

    public float amount = 10f;
    public float duration = 5f;
    public float speed = 5.0f;

    public PowerUpSpawner powerUpSpawner;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        switch (type)
        {
            case PowerUpType.AddTime:
                FindFirstObjectByType<TimeManager>().AddTime(amount);
                Debug.Log("AddTime-PowerUp benutzt");
                break;

            case PowerUpType.SpeedBoost:

                PlayerMovement player = other.GetComponent<PlayerMovement>();

                if (player != null)
                {
                    player.ActivateSpeedBoost(duration);
                }

                break;

            case PowerUpType.DoubleScore:
                break;
        }

        Destroy(gameObject);
        powerUpSpawner.PowerUpOnField = false;

    }
}


