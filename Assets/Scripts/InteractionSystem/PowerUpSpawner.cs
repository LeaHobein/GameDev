using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour
{
    public Material m_addTimeSymbol;
    public Material m_speedBoostSymbol;
    public Material m_doubleScoreSymbol;
    public Material m_decreaseTimeSymbol;
    public Material m_slowDownSymbol;
    public Material m_disableSymbol;
    public Material m_powerUpOrb;
    public Material m_powerDownOrb;
    public Material m_powerUpOutline;
    public Material m_powerDownOutline;
    [SerializeField] private UI_Notfalloptionen_Manager pauseManager;
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

    public bool PowerUpOnField = false;

    private void SpawnPowerUp()
    {
        if (PowerUpOnField || timeManager.gamePlaying == false)
            return;

        int powerUpIndex = Random.Range(0, powerUps.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        GameObject obj = Instantiate(
            powerUps[powerUpIndex].prefab,
            spawnPoints[spawnIndex].position,
            Quaternion.identity
        );

        obj.GetComponent<PowerUp>().type = powerUps[powerUpIndex].type;
        switch (powerUpIndex)
        {
            case 0:
                GameObject.Find("powerUpOrb").GetComponent<MeshRenderer>().sharedMaterial = m_powerUpOrb;
                GameObject.Find("powerUpSymbol").GetComponent<MeshRenderer>().sharedMaterial = m_addTimeSymbol;
                GameObject.Find("powerUpLight").SetActive(true);
                GameObject.Find("powerDownLight").SetActive(false);
                obj.GetComponent<MeshRenderer>().sharedMaterial = m_powerUpOutline;
                break;

            case 1:
                GameObject.Find("powerUpOrb").GetComponent<MeshRenderer>().sharedMaterial = m_powerUpOrb;
                GameObject.Find("powerUpSymbol").GetComponent<MeshRenderer>().sharedMaterial = m_speedBoostSymbol;
                GameObject.Find("powerUpLight").SetActive(true);
                GameObject.Find("powerDownLight").SetActive(false);
                obj.GetComponent<MeshRenderer>().sharedMaterial = m_powerUpOutline;
                break;

            case 2:
                GameObject.Find("powerUpOrb").GetComponent<MeshRenderer>().sharedMaterial = m_powerUpOrb;
                GameObject.Find("powerUpSymbol").GetComponent<MeshRenderer>().sharedMaterial = m_doubleScoreSymbol;
                GameObject.Find("powerUpLight").SetActive(true);
                GameObject.Find("powerDownLight").SetActive(false);
                obj.GetComponent<MeshRenderer>().sharedMaterial = m_powerUpOutline;
                break;

            case 3:
                GameObject.Find("powerUpOrb").GetComponent<MeshRenderer>().sharedMaterial = m_powerDownOrb;
                GameObject.Find("powerUpSymbol").GetComponent<MeshRenderer>().sharedMaterial = m_decreaseTimeSymbol;
                GameObject.Find("powerUpLight").SetActive(false);
                GameObject.Find("powerDownLight").SetActive(true);
                obj.GetComponent<MeshRenderer>().sharedMaterial = m_powerDownOutline;
                break;

            case 4:
                GameObject.Find("powerUpOrb").GetComponent<MeshRenderer>().sharedMaterial = m_powerDownOrb;
                GameObject.Find("powerUpSymbol").GetComponent<MeshRenderer>().sharedMaterial = m_slowDownSymbol;
                GameObject.Find("powerUpLight").SetActive(false);
                GameObject.Find("powerDownLight").SetActive(true);
                obj.GetComponent<MeshRenderer>().sharedMaterial = m_powerDownOutline;
                break;

            case 5:
                GameObject.Find("powerUpOrb").GetComponent<MeshRenderer>().sharedMaterial = m_powerDownOrb;
                GameObject.Find("powerUpSymbol").GetComponent<MeshRenderer>().sharedMaterial = m_disableSymbol;
                GameObject.Find("powerUpLight").SetActive(false);
                GameObject.Find("powerDownLight").SetActive(true);
                obj.GetComponent<MeshRenderer>().sharedMaterial = m_powerDownOutline;
                break;
            default:
                break;
        }
        PowerUpOnField = true;
        currentPowerUp = obj;

        StartCoroutine(DestroyPowerUpAfterTime(obj));
    }

    private IEnumerator DestroyPowerUpAfterTime(GameObject powerUp)
    {
        float timer = 10f;

        while (timer > 0f)
        {
            if (!pauseManager.NotfallOptionenActive)
            {
                timer -= Time.deltaTime;
            }

            yield return null;
        }

        if (powerUp != null)
        {
            Destroy(powerUp);
            ClearCurrentPowerUp();
        }
    }

    public void ClearCurrentPowerUp()
    {
        PowerUpOnField = false;
        currentPowerUp = null;
    }

    public void PauseSpawner()
    {
        CancelInvoke(nameof(SpawnPowerUp));
    }

    public void ResumeSpawner()
    {
        InvokeRepeating(nameof(SpawnPowerUp), spawnInterval, spawnInterval);
    }
}
