using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
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
    bool onController = !ControllerManager.playersOnKeyboard;
    private void Start()
    {
        timeManager = GameObject.Find("timerText").GetComponent<TimeManager>();
        Debug.Log(Gamepad.all);
        switch (gameObject.name)
        {
            case "Player1":
                if (onController && Gamepad.all.Count > 1) gameObject.GetComponent<PlayerInput>().SwitchCurrentControlScheme("Controller", Gamepad.all[0]);
                else gameObject.GetComponent<PlayerInput>().SwitchCurrentControlScheme("WASD", Keyboard.current);
                break;
            case "Player2":
                if (onController && Gamepad.all.Count > 1) gameObject.GetComponent<PlayerInput>().SwitchCurrentControlScheme("Controller", Gamepad.all[1]);
                else gameObject.GetComponent<PlayerInput>().SwitchCurrentControlScheme("IJKL", Keyboard.current);
                break;
            default:
                break;
        }
        normalSpeed = speed;
    }
    public void OnMove(InputAction.CallbackContext mov)
    {
        playerMovement = mov.ReadValue<Vector3>();
    }
    public void Stun(float duration)
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Punch);
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
        if(gameObject.GetComponent<UI_Notfalloptionen_Manager>().NotfallOptionenActive) return;
        bool timeout = timeManager.time <= 1;
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

        if (move != Vector3.zero && !timeout)
            transform.forward = move;

        playerVelocity.y += gravity * Time.deltaTime;

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

    public void ActivateSlowDown(float duration)
    {
        StopCoroutine(nameof(SlowDown));
        StartCoroutine(SlowDown(duration));
    }

    private IEnumerator SlowDown (float duration)
    {
        speed = normalSpeed * 0.5f;
        yield return new WaitForSeconds(duration);
        speed = normalSpeed;
    }
}
