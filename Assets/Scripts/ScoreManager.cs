using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public static int score = 0;
    public static int scoreMultiplier = 1;
    public TMP_Text doubleScoreText;

    private InputActionAsset InputActions;
    private InputAction p_addpoints;
    private InputAction o_decreasePoints;
    private void Start()
    {
        score = 0;
        doubleScoreText.text = "";
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
        score += scoreMultiplier;
        scoreText.text = score.ToString();


    }

    public void addScore(bool doubleScore)
    {
        if (doubleScore)
            score += 2;
        else
            score += 1;

        scoreText.text = score.ToString();
    }

    public void decreaseScore()
    {
        score--;
        scoreText.text = score.ToString();
    }

    public void ActivateDoubleScore(float duration)
    {
        StopCoroutine(nameof(DoubleScore));
        StartCoroutine(DoubleScore(duration));
    }

    private IEnumerator DoubleScore(float duration)
    {
        scoreMultiplier = 2;
        doubleScoreText.text = "×2";
        doubleScoreText.color = Color.yellow;

        yield return new WaitForSeconds(duration);

        scoreMultiplier = 1;
        doubleScoreText.text = "";
    }

}
