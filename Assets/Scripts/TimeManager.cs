using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public int countdownTime = 3;
    public float time = 10;
    public float transitionTime = 1f;
    public bool done = false;
    public bool gamePlaying = false;

    public TMP_Text timerText;
    public TMP_Text countdownText;
    public TMP_Text skipText;
    public TMP_Text tutorial;
    public TMP_Text AddDecreaseTimeText;
    public RawImage X_icon2;
    private Coroutine timeTextCoroutine;

    public Animator transition;
    public ScoreManager scoreManager;
    private void Start()
    {
        countdownText.gameObject.SetActive(false);
        AddDecreaseTimeText.text = "";
    }

    public void StartRound()
    {
        StartCoroutine(CountdownToStart());
        resetPlayers();
        //blende alle Tutorial Texte aus
        skipText.gameObject.SetActive(false);
        tutorial.gameObject.SetActive(false);
        X_icon2.gameObject.SetActive(false);

    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0) //3...2...1...
        {
            countdownText.gameObject.SetActive(true);

            countdownText.text = countdownTime.ToString();

            AudioManager.Instance.Play(AudioManager.SoundType.CountdownClick);

            GameObject.Find("Player1").GetComponent<PlayerMovement>().speed = 0f;
            GameObject.Find("Player2").GetComponent<PlayerMovement>().speed = 0f;

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownText.text = "GO!";

        AudioManager.Instance.Play(AudioManager.SoundType.CountdownGo);

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);

        gamePlaying = true; //startet die Runde

        GameObject.Find("Player1").GetComponent<PlayerMovement>().speed = 5.0f;
        GameObject.Find("Player2").GetComponent<PlayerMovement>().speed = 5.0f;
    }

    void Update()
    {
        //Debug.Log("TIME UPDATE: " + time + " | ID: " + GetInstanceID());
        
        if (GameObject.Find("Player1").GetComponent<UI_Notfalloptionen_Manager>().NotfallOptionenActive) return;
        if (gamePlaying == true)
        {
            time -= Time.deltaTime;

            if (time > 0)
            {
                timerText.text = Mathf.Floor(time).ToString();

                //timer text wird geupdatet wenn die Runde l�uft und time > 0
            }

            if (time < 11)
            {
                timerText.color = Color.indianRed;

                //ab 10 sekunden wird der timer text rot
            }

            if (time > 10)
            {
                timerText.color = Color.white;

                //über 10 sekunden ist timer text weiss
            }

            if (time <= 1) //wenn Zeit abgelaufen, alles stopp, �bergang zur n�chsten Szene
            {
                if (done == false) //done bool damit ich nicht tausend coroutinen starte
                {
                    gamePlaying = false;
                    countdownText.gameObject.SetActive(true);
                    countdownText.text = "ENDE!";
                    GameObject.Find("Player1").GetComponent<PlayerMovement>().speed = 0f;
                    GameObject.Find("Player2").GetComponent<PlayerMovement>().speed = 0f;
                    GameObject.Find("Forklift").GetComponent<AtoB>().speed = 0f;
                    //ScoreBoardManager.AddScore(ScoreManager.score); //Score speichern
                    ScoreBoardManager.AddScore(ScoreBoardManager.playerCount + 1, ScoreManager.score);
                    ScoreBoardManager.playerCount++;
                    done = true;
                    StartCoroutine(LoadLevel());

                }
            }
        }
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(3f);

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(3);

    }
    public void resetPlayers()
    {
        GameObject.Find("Player1").GetComponent<CharacterController>().enabled = false;
        GameObject.Find("Player2").GetComponent<CharacterController>().enabled = false;
        GameObject.Find("Player1").transform.position = GameObject.Find("spawnPoint_1").transform.position;
        GameObject.Find("Player1").transform.forward = Vector3.forward*-1f;
        GameObject.Find("Player2").transform.position = GameObject.Find("spawnPoint_2").transform.position;
        GameObject.Find("Player2").transform.forward = Vector3.forward*-1f;
        GameObject.Find("Player1").GetComponent<CharacterController>().enabled = true;
        GameObject.Find("Player2").GetComponent<CharacterController>().enabled = true;
    }
    public void AddTime(float seconds)
    {
        time += seconds;
        ShowTimeChange(seconds, Color.green);
        //Debug.Log($"ADD TIME {seconds} -> NEW TIME: {time}");
    }

    public void DecreaseTime(float seconds)
    {
        time -= seconds;
        ShowTimeChange(-seconds, Color.red);
        //Debug.Log($"DEC TIME {seconds} -> NEW TIME: {time}");
    }

    private void ShowTimeChange(float seconds, Color color)
    {
        // Falls gerade noch alte Anzeige läuft -> abbrechen
        if (timeTextCoroutine != null)
        {
            StopCoroutine(timeTextCoroutine);
        }

        timeTextCoroutine = StartCoroutine(ShowTimeChangeCoroutine(seconds, color));
    }

    private IEnumerator ShowTimeChangeCoroutine(float seconds, Color color)
    {
        AddDecreaseTimeText.color = color;

        if (seconds > 0)
            AddDecreaseTimeText.text = "+" + seconds;
        else
            AddDecreaseTimeText.text = seconds.ToString();

        yield return new WaitForSeconds(3f);

        AddDecreaseTimeText.text = "";
    }


}
