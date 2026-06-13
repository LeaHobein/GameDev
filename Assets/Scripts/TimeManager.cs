using System;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float time = 10;
    public TMP_Text timerText;
    public bool timeUp = false;

    void Update()
    {
        time -= Time.deltaTime;
        timerText.text = Mathf.Floor(time).ToString();

        if (time < 11)
        {
            timerText.color = Color.indianRed;
        }

        if (time <= 1)
        {
            Pause();
            timeUp = true;
            Debug.Log("game over");

            //lege den Gabelstapler lahm
            GameObject.Find("Forklift").GetComponent<AtoB>().tempo = 0f;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
