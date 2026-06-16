using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void ZumMenue()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.ButtonClick);
        StartCoroutine(LoadLevel(1));
    }
    public void SpielStarten()
    {
        //SceneManager.LoadSceneAsync("MiniGame"); Spiel starten ohne Fade Animation
        AudioManager.Instance.Play(AudioManager.SoundType.ButtonClick);
        StartCoroutine(LoadLevel(2));
    }

    public void Einstellungen()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.ButtonClick);
        StartCoroutine(LoadLevel(3));
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
