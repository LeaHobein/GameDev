using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class VideoManager : MonoBehaviour
{
    private float inputTimer;
    public TMP_Text videoTest;
    private InputAction startGame;
    private InputAction skip;

    public bool videoPlaying = false;

    void Start()
    {
        inputTimer = 0;
        videoTest.gameObject.SetActive(false);
    }

    public void Awake()
    {
        startGame = gameObject.GetComponent<PlayerInput>().actions["A"];
        skip = gameObject.GetComponent<PlayerInput>().actions["skipVideo"];
    }

        void Update()
    {
        inputTimer += Time.deltaTime;


        if (startGame.WasPerformedThisFrame() || skip.WasPerformedThisFrame())
        {
            Debug.Log("boah hallo");
            //Reset the timer
            inputTimer = 0;
            videoTest.gameObject.SetActive(false);
            videoPlaying = false;
        }
        
        if (inputTimer >= 5f)
        {
            Debug.Log("sehr professionell");

            inputTimer = 0;
            videoTest.gameObject.SetActive(true);
            videoPlaying = true;
        }
    }
}
