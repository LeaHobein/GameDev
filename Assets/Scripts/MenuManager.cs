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
    private InputAction gameOptions;
    private InputAction credits;

    public void Awake()
    {
        startGame = gameObject.GetComponent<PlayerInput>().actions["Confirm"];
        endGame = gameObject.GetComponent<PlayerInput>().actions["Cancel"];
        gameOptions = gameObject.GetComponent<PlayerInput>().actions["Option_1"];
        credits = gameObject.GetComponent<PlayerInput>().actions["Option_2"];
    }
    public void Update()
    {
        if(startGame.WasPerformedThisFrame()) SpielStarten();
        if(endGame.WasPerformedThisFrame()) Beenden();
        if(gameOptions.WasPerformedThisFrame()) Credits();
        if(credits.WasPerformedThisFrame()) ZumMenue();
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
