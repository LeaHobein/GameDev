using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerUpSpawner = GameObject.Find("PowerUp_SpawnPoints").GetComponent<PowerUpSpawner>();
        timeManager = FindAnyObjectByType<TimeManager>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
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
    public float duration = 10f;
    public float speed = 5.0f;

    public PowerUpSpawner powerUpSpawner;
    public TimeManager timeManager;
    public ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        switch (type)
        {
            case PowerUpType.AddTime:
                timeManager.AddTime(amount);
                Debug.Log("AddTime-PowerUp benutzt");
                break;

            case PowerUpType.SpeedBoost:

                PlayerMovement player = other.GetComponent<PlayerMovement>();

                if (player != null)
                {
                    player.ActivateSpeedBoost(duration);
                    Debug.Log("SpeedBoost-PowerUp benutzt");
                }

                break;

            case PowerUpType.DoubleScore:
                scoreManager.ActivateDoubleScore(duration);
                Debug.Log("DoubleScore-PowerUp benutzt");
                break;
        }

        Destroy(gameObject);
        powerUpSpawner.ClearCurrentPowerUp();


    }
}


