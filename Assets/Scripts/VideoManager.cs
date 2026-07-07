using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private float inputTimer;
    public TMP_Text title_2;
    public Button skipVideoButton;
    public RawImage demo_video;
    private InputAction startGame;

    public bool videoPlaying = false;
    public bool coroutineDone = false;
    public bool coroutineDone2 = false;

    void Start()
    {
        inputTimer = 0;
        skipVideoButton.gameObject.SetActive(false);
        demo_video.gameObject.SetActive(false);
        title_2.gameObject.SetActive(false);
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
        
        if (inputTimer >= 5f && !videoPlaying)
        {
            if (!coroutineDone2)
            {
                StartCoroutine(playVideo());
            }
        }
    }

    public void skipVideo()
    {
        inputTimer = 0;

        if (!coroutineDone)
        {
            StartCoroutine(ButtonCooldown());
        }
    }

    IEnumerator ButtonCooldown()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        transition.SetTrigger("Fade");

        skipVideoButton.gameObject.SetActive(false);
        demo_video.gameObject.SetActive(false);
        title_2.gameObject.SetActive(false);

        videoPlaying = false;
        coroutineDone = true;
    }

    IEnumerator playVideo()
    {
        coroutineDone2 = true;

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        transition.SetTrigger("Fade");

        inputTimer = 0;

        skipVideoButton.gameObject.SetActive(true);
        demo_video.gameObject.SetActive(true);
        title_2.gameObject.SetActive(true);

        videoPlaying = true;
    }
}
