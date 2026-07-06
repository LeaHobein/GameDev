using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{
    private float inputTimer;
    public TMP_Text videoTest;
    public Button skipVideoButton;
    private InputAction startGame;

    public bool videoPlaying = false;
    public bool coroutineDone = false;

    void Start()
    {
        inputTimer = 0;
        videoTest.gameObject.SetActive(false);
        skipVideoButton.gameObject.SetActive(false);
    }

    public void Awake()
    {
        startGame = gameObject.GetComponent<PlayerInput>().actions["A"];
    }

        void Update()
    {
        inputTimer += Time.deltaTime;

        if (startGame.WasPerformedThisFrame())
        {
            skipVideo();
        }
        
        if (inputTimer >= 5f)
        {
            Debug.Log("sehr professionell");

            inputTimer = 0;
            videoTest.gameObject.SetActive(true);
            skipVideoButton.gameObject.SetActive(true);
            videoPlaying = true;
        }
    }

    public void skipVideo()
    {
        Debug.Log("boah hallo");
        //Reset the timer
        inputTimer = 0;
        videoTest.gameObject.SetActive(false);
        skipVideoButton.gameObject.SetActive(false);

        if (!coroutineDone)
        {
            StartCoroutine(ButtonCooldown());
        }
    }

    IEnumerator ButtonCooldown()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Krokette");
        videoPlaying = false;
        coroutineDone = true;
    }
}
