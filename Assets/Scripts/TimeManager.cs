using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    public int countdownTime = 3;
    public float time = 10;
    public TMP_Text timerText;
    public TMP_Text countdownText;

    public TMP_Text skipText;
    public TMP_Text tutorial;

    public Animator transition;
    public float transitionTime = 1f;

    public bool done = false;

    public bool gamePlaying = false;

    private void Start()
    {
        countdownText.gameObject.SetActive(false);
    }

    public void StartRound()
    {
        StartCoroutine(CountdownToStart());

        //blende alle Tutorial Texte aus
        skipText.gameObject.SetActive(false);
        tutorial.gameObject.SetActive(false);

    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0) //3...2...1...
        {
            countdownText.gameObject.SetActive(true);

            countdownText.text = countdownTime.ToString();

            AudioManager.Instance.Play(AudioManager.SoundType.CountdownClick);

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownText.text = "GO!";

        AudioManager.Instance.Play(AudioManager.SoundType.CountdownGo);

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);

        gamePlaying = true; //startet die Runde
    }

    void Update()
    {
        if(GameObject.Find("Player1").GetComponent<UI_Notfalloptionen_Manager>().NotfallOptionenActive) return;
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
                    Debug.Log("game over");
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
    
    public void Pause()
    {
        
    }

    public void Resume()
    {
        
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(3f);

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(4);

    }

    public void AddTime(float seconds)
    {
        time += seconds;
        Debug.Log("+" + seconds + " Sekunden");
    }


}
