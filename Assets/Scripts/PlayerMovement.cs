using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.iOS;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float gravity = -9.81f;

    public CharacterController controller;
    private Vector3 playerVelocity;
    private Vector3 playerMovement;
    private bool groundedPlayer;

    [Header("Input Actions")]
    public InputActionReference moveAction;
    public InputActionReference pickUpAction;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        Debug.Log(controller.name);
    }
    public void OnMove(InputAction.CallbackContext mov)
    {
        playerMovement = mov.ReadValue<Vector3>();
    }
    public void OnPickUp(InputAction.CallbackContext pickup)
    {
        Debug.Log("Picked Up");
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
        groundedPlayer = controller.isGrounded;
        if(groundedPlayer && playerVelocity.y <= 0)
        {
            playerVelocity.y=-2f;
        }
        // Read input
        Vector3 move = new Vector3(
            playerMovement.x * speed,
            playerMovement.y * speed,
            playerMovement.z * speed);
        //move = Vector3.ClampMagnitude(move, 1f);

        //if (move != Vector3.zero)
            //transform.forward = move;


        // Apply gravity
        playerVelocity.y += gravity * Time.deltaTime;

        // Move
        Vector3 finalMove = move + Vector3.up * playerVelocity.y - Vector3.up;
        controller.Move(finalMove * Time.deltaTime);
    }
}
