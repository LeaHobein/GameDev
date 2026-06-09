using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public void SpielStarten()
    {
        //SceneManager.LoadSceneAsync("MiniGame"); Spiel starten ohne Fade Animation
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("MiniGame");
    }

    public void Beenden()
    {
        Application.Quit();
    }
}
