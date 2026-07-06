using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Notfalloptionen_Manager : MonoBehaviour
{
    public InputAction escapeAction;
    public InputAction restartAction;
    public InputAction returnAction;
    public bool NotfallOptionenActive = false;

    public TMP_Text esc_schliessen_text;
    public TMP_Text notfall_title_text;
    public Button MenueButton;
    public Button resetButton;
    public RawImage pause_background;
    public RawImage X_icon;
    public RawImage Y_icon;
    public RawImage settings_icon;

    public GameObject player1;
    public GameObject player2;
    public Transform[] spawnPoints;

    void Start()
    {
        NotfallOptionenActive = false;

        esc_schliessen_text.gameObject.SetActive(false);
        notfall_title_text.gameObject.SetActive(false);
        MenueButton.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);
        pause_background.gameObject.SetActive(false);
        X_icon.gameObject.SetActive(false);
        Y_icon.gameObject.SetActive(false);
        settings_icon.gameObject.SetActive(false);
    }

    void Update()
    {
        CheckForEscape();
        checkForRestart();
        checkForReturn();
    }
    void Awake()
    {
        escapeAction = gameObject.GetComponent<PlayerInput>().actions["Escape"];
        restartAction = gameObject.GetComponent<PlayerInput>().actions["restartGame"];
        returnAction = gameObject.GetComponent<PlayerInput>().actions["toMainMenu"];
    }
    void checkForRestart()
    {
        if (restartAction.WasPerformedThisFrame() && NotfallOptionenActive) ResetGame();
    }
    void checkForReturn()
    {
        if (returnAction.WasPerformedThisFrame() && NotfallOptionenActive) ZumMenue();
    }
    void CheckForEscape()
    {
        if (escapeAction.WasPerformedThisFrame() && !NotfallOptionenActive)
        {
            Debug.Log("was geht");
            AudioManager.Instance.Play(AudioManager.SoundType.UiAppear);
            esc_schliessen_text.gameObject.SetActive(true);
            notfall_title_text.gameObject.SetActive(true);
            MenueButton.gameObject.SetActive(true);
            resetButton.gameObject.SetActive(true);
            pause_background.gameObject.SetActive(true);
            X_icon.gameObject.SetActive(true);
            Y_icon.gameObject.SetActive(true);
            settings_icon.gameObject.SetActive(true);
            GameObject.Find("Forklift").GetComponent<AtoB>().speed = 0f;

            NotfallOptionenActive = true;

        } else if (escapeAction.WasPerformedThisFrame() && NotfallOptionenActive)
        {
            Debug.Log("hiya");
            AudioManager.Instance.Play(AudioManager.SoundType.UiDissappear);
            esc_schliessen_text.gameObject.SetActive(false);
            notfall_title_text.gameObject.SetActive(false);
            MenueButton.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(false);
            pause_background.gameObject.SetActive(false);
            X_icon.gameObject.SetActive(false);
            Y_icon.gameObject.SetActive(false);
            settings_icon.gameObject.SetActive(false);

            if (GameObject.Find("Forklift").GetComponent<AtoB>().isOnAB)
            {
                GameObject.Find("Forklift").GetComponent<AtoB>().speed = 0f;
            }
            else
            {
                GameObject.Find("Forklift").GetComponent<AtoB>().speed = GameObject.Find("Forklift").GetComponent<AtoB>().defaultSpeed;
            }
            NotfallOptionenActive = false;
        }
    }
    public void ZumMenue()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.ButtonClick);
        SceneManager.LoadScene(0);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(1);
        /*
        Debug.Log(GameObject.Find("Player1").transform.position);
        Debug.Log(GameObject.Find("spawnPoint_1").transform.position);
        GameObject.Find("Player1").transform.position = GameObject.Find("spawnPoint_1").transform.position;
        GameObject.Find("Player2").transform.position = GameObject.Find("spawnPoint_2").transform.position;
        */
    }


}
