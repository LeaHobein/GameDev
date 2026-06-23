using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Notfalloptionen_Manager : MonoBehaviour
{
    private InputAction escapeAction;
    public bool NotfallOptionenActive = false;

    public TMP_Text esc_schliessen_text;
    public TMP_Text notfall_title_text;
    public Button MenueButton;
    public Button UnstuckButton;

    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        NotfallOptionenActive = false;

        esc_schliessen_text.gameObject.SetActive(false);
        notfall_title_text.gameObject.SetActive(false);
        MenueButton.gameObject.SetActive(false);
        UnstuckButton.gameObject.SetActive(false);
    }

    void Update()
    {
        CheckForEscape();
    }
    void Awake()
    {
        escapeAction = gameObject.GetComponent<PlayerInput>().actions["Escape"];
    }
    
    void CheckForEscape()
    {
        if (escapeAction.WasPerformedThisFrame() && !NotfallOptionenActive)
        {
            Debug.Log("was geht");
            esc_schliessen_text.gameObject.SetActive(true);
            notfall_title_text.gameObject.SetActive(true);
            MenueButton.gameObject.SetActive(true);
            UnstuckButton.gameObject.SetActive(true);

            NotfallOptionenActive = true;

        } else if (escapeAction.WasPerformedThisFrame() && NotfallOptionenActive)
        {
            Debug.Log("hiya");
            esc_schliessen_text.gameObject.SetActive(false);
            notfall_title_text.gameObject.SetActive(false);
            MenueButton.gameObject.SetActive(false);
            UnstuckButton.gameObject.SetActive(false);

            NotfallOptionenActive = false;
        }
    }
    public void ZumMenue()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.ButtonClick);
        SceneManager.LoadScene(1);
    }

    public void resetBots()
    {
        //player1.gameObject.transform.position = new Vector3(-8, 1, 3);
        //player2.gameObject.transform.position = new Vector3(8, 1, 3);
    }
}
