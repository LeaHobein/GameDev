using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.iOS;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    
    private float normalSpeed;
    [SerializeField]
    private float gravity = -9.81f;

    public CharacterController controller;
    private Vector3 playerVelocity;
    private Vector3 playerMovement;
    private bool groundedPlayer;
    private bool isStunned;
    [SerializeField]
    private TimeManager timeManager;

    [Header("Input Actions")]
    public InputActionReference moveAction;
    public InputActionReference pickUpAction;
    private void Start()
    {
        timeManager = GameObject.Find("timerText").GetComponent<TimeManager>();
        switch (gameObject.name)
        {
            case "Player1":
                gameObject.GetComponent<PlayerInput>().SwitchCurrentControlScheme("WASD", Keyboard.current);
                break;
            case "Player2":
                gameObject.GetComponent<PlayerInput>().SwitchCurrentControlScheme("IJKL", Keyboard.current);
                break;
            default:
                break;
        }
        normalSpeed = speed;
        //controller = gameObject.GetComponent<CharacterController>();
    }
    public void OnMove(InputAction.CallbackContext mov)
    {
        playerMovement = mov.ReadValue<Vector3>();
    }
    public void OnPickUp(InputAction.CallbackContext pickup)
    {
        Debug.Log("Picked Up");
    }
    public void Stun(float duration)
    {
        StopCoroutine(nameof(StunCoroutine));
        StartCoroutine(StunCoroutine(duration));
    }

    IEnumerator StunCoroutine(float duration)
    {
        isStunned = true;
        yield return new WaitForSeconds(duration);
        isStunned = false;
    }
    private void OnEnable()
    {
        moveAction.action.Enable();
        pickUpAction
.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        pickUpAction
.action.Disable();
    }

    void Update()
    {
        bool timeout = timeManager.time <= 1;
        //print("time: " + timeManager.time);
        groundedPlayer = controller.isGrounded;
        if(groundedPlayer && playerVelocity.y <= 0)
        {
            playerVelocity.y=-2f;
        }
        float moveSpeed = isStunned ? 0f : speed;

        Vector3 move = new Vector3(
            playerMovement.x * moveSpeed,
            playerMovement.y * moveSpeed,
            playerMovement.z * moveSpeed);
        //move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero && !timeout)
            transform.forward = move;


        // Apply gravity
        playerVelocity.y += gravity * Time.deltaTime;

        // Move
        Vector3 finalMove = move + Vector3.up * playerVelocity.y - Vector3.up;

        if(!timeout)controller.Move(finalMove * Time.deltaTime);
    }

    public void ActivateSpeedBoost(float duration)
    {
        StopCoroutine(nameof(SpeedBoost));
        StartCoroutine(SpeedBoost(duration));
    }

    private IEnumerator SpeedBoost (float duration)
    {
        speed = normalSpeed * 1.5f;
        yield return new WaitForSeconds(duration);
        speed = normalSpeed;
        
    }
}
