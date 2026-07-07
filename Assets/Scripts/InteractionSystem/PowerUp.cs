using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void Start()
    {
        powerUpSpawner = GameObject.Find("PowerUp_SpawnPoints").GetComponent<PowerUpSpawner>();
        timeManager = FindAnyObjectByType<TimeManager>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
        deliverySpot = FindAnyObjectByType<DeliverySpot>();
    }
    public enum PowerUpType
    {
        AddTime,
        SpeedBoost,
        DoubleScore,
        DecreaseTime,
        SlowDown,
        DisableDeliverySpot
    }

    public PowerUpType type;
    public float amount = 10f;
    public float duration = 10f;
    public float speed = 6.0f;

    public PowerUpSpawner powerUpSpawner;
    public TimeManager timeManager;
    public ScoreManager scoreManager;
    public DeliverySpot deliverySpot;


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
                AudioManager.Instance.Play(AudioManager.SoundType.PosPowerUp);
                //Debug.Log("POWERUP TIME MANAGER ID: " + timeManager.GetInstanceID());
                break;

            case PowerUpType.SpeedBoost:
                if (player != null)
                {
                    player.ActivateSpeedBoost(duration);
                    AudioManager.Instance.Play(AudioManager.SoundType.PosPowerUp);
                }
                break;

            case PowerUpType.DoubleScore:
                scoreManager.ActivateDoubleScore(duration);
                AudioManager.Instance.Play(AudioManager.SoundType.PosPowerUp);
                break;

            // DEBUFFS
            case PowerUpType.DecreaseTime:
                timeManager.DecreaseTime(amount * 0.5f);
                AudioManager.Instance.Play(AudioManager.SoundType.NegPowerUp);
                //Debug.Log("POWERUP TIME MANAGER ID: " + timeManager.GetInstanceID());
                break;

            case PowerUpType.SlowDown:
                if (player != null)
                {
                    player.ActivateSlowDown(duration);
                    AudioManager.Instance.Play(AudioManager.SoundType.NegPowerUp);
                }
                break;

            case PowerUpType.DisableDeliverySpot:
                foreach (var spot in DeliverySpot.allSpots)
                {
                    spot.BlockForSeconds(duration); 
                }
                AudioManager.Instance.Play(AudioManager.SoundType.NegPowerUp);
                break;
        }
        Destroy(gameObject);
        powerUpSpawner.ClearCurrentPowerUp();
    }
}


