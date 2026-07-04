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
        DoubleScore,
        DecreaseTime,
        SlowDown
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

        PlayerMovement player = other.GetComponent<PlayerMovement>();

        AudioManager.Instance.Play(AudioManager.SoundType.PowerUpPop);

        switch (type)
        {
            // POWERUPS
            case PowerUpType.AddTime:
                timeManager.AddTime(amount);
                Debug.Log("AddTime-PowerUp benutzt");
                AudioManager.Instance.Play(AudioManager.SoundType.PosPowerUp);
                break;

            case PowerUpType.SpeedBoost:
                if (player != null)
                {
                    player.ActivateSpeedBoost(duration);
                    Debug.Log("SpeedBoost-PowerUp benutzt");
                    AudioManager.Instance.Play(AudioManager.SoundType.PosPowerUp);
                }
                break;

            case PowerUpType.DoubleScore:
                scoreManager.ActivateDoubleScore(duration);
                Debug.Log("DoubleScore-PowerUp benutzt");
                AudioManager.Instance.Play(AudioManager.SoundType.PosPowerUp);
                break;

            // DEBUFFS
            case PowerUpType.DecreaseTime:
                timeManager.DecreaseTime(amount * 0.5f);
                Debug.Log("DecreaseTime-Debuff benutzt");
                AudioManager.Instance.Play(AudioManager.SoundType.NegPowerUp);
                break;

            case PowerUpType.SlowDown:
                if (player != null)
                {
                    player.ActivateSlowDown(duration);
                    Debug.Log("SlowDown-Debuff benutzt");
                    AudioManager.Instance.Play(AudioManager.SoundType.NegPowerUp);
                }
                break;
        }

        Destroy(gameObject);
        powerUpSpawner.ClearCurrentPowerUp();
    }
}


