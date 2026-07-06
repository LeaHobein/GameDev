using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class MenuManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    private InputAction startGame;
    private InputAction endGame;
    private InputAction toMainMenu;
    private InputAction credits;

    public VideoManager videoManager;

    public void Awake()
    {
        startGame = gameObject.GetComponent<PlayerInput>().actions["A"];
        endGame = gameObject.GetComponent<PlayerInput>().actions["B"];
        toMainMenu = gameObject.GetComponent<PlayerInput>().actions["X"];
        credits = gameObject.GetComponent<PlayerInput>().actions["Y"];
    }
    public void Update()
    {
            if (!inCreditScene() && videoManager.videoPlaying == false)
            {
                if (startGame.WasPerformedThisFrame()) SpielStarten();
                if (endGame.WasPerformedThisFrame()) Beenden();
                if (!inScoreScene() && credits.WasPerformedThisFrame()) Credits();
            }
            if (toMainMenu.WasPerformedThisFrame()) ZumMenue();
    }
    bool inCreditScene()
    {
        return SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2);
    }
    bool inScoreScene()
    {
        return SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3);
    }
    public void ZumMenue()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.ButtonClick);
        StartCoroutine(LoadLevel(0));
    }
    public void SpielStarten()
    {
        //SceneManager.LoadSceneAsync("MiniGame"); Spiel starten ohne Fade Animation
        AudioManager.Instance.Play(AudioManager.SoundType.ButtonClick);
        StartCoroutine(LoadLevel(1));
    }

    public void Credits()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.ButtonClick);
        StartCoroutine(LoadLevel(2));
    }

   

    IEnumerator LoadLevel(int scene)
    {

        transition.SetTrigger("Start");

        AudioManager.Instance.Play(AudioManager.SoundType.FadeIn);

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }

    public void Beenden()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.ButtonClick);
        Application.Quit();
    }
}
