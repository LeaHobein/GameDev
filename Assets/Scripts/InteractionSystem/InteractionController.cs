using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    [SerializeField]
    Camera playerCamera;

    [SerializeField]
    float interactionDistance = 5f;

    IInteractable currentTargetInteractable;

    void Awake()
    {
        if (playerCamera == null)
            playerCamera = GetComponentInChildren<Camera>(true);

        if (playerCamera == null)
            playerCamera = Camera.main;
    }

    public void Update()
    {
        UpdateCurrentInteractable();

        CheckForInteractionInput();
    }

    void UpdateCurrentInteractable()
    {
        if (playerCamera == null)
            return;

        var ray = playerCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));

        Physics.Raycast(ray, out var hit, interactionDistance);

        currentTargetInteractable = hit.collider?.GetComponent<IInteractable>();
    }

    void CheckForInteractionInput()
    {
        if(Keyboard.current.fKey.wasPressedThisFrame && currentTargetInteractable != null)
        {
            currentTargetInteractable.Interact();
        }
    }
}

