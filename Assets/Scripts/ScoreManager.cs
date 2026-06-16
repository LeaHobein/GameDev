using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public static int score = 0;

    private InputActionAsset InputActions;
    private InputAction p_addpoints;
    private InputAction o_decreasePoints;

    /* private void OnEnable()
     {
         InputActions.FindActionMap("Player").Enable();
     }

     private void OnDisable()
     {
         InputActions.FindActionMap("Player").Disable();
     }
    */
    private void Start()
    {
        score = 0;
    }

    private void Awake()
    {
        p_addpoints = InputSystem.actions.FindAction("Test_addPoints");
        o_decreasePoints = InputSystem.actions.FindAction("Test_decreasePoints");
    }

    private void Update()
    {
        if (p_addpoints.WasPressedThisFrame())
        {
            addScore();
        }

        if (o_decreasePoints.WasPressedThisFrame())
        {
            decreaseScore();
        }   
    }
    public void addScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void decreaseScore()
    {
        score--;
        scoreText.text = score.ToString();
    }

}
