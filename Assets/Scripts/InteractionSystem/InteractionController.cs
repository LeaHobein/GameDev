using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    [SerializeField]
    Camera playerCamera;

    [SerializeField]
    float interactionDistance = 5f;

    IInteractable currentTargetInteractable;

    public void Update()
    {
        UpdateCurrentInteractable();

        CheckForInteractionInput();
    }

    void UpdateCurrentInteractable()
    {
        var ray = playerCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));

        Physics.Raycast(ray, out var hit, interactionDistance);

        currentTargetInteractable = hit.collider?.GetComponent<IInteractable>();
    }

    void CheckForInteractionInput()
    {
        if(Keyboard.current.gKey.wasPressedThisFrame && currentTargetInteractable != null)
        {
            currentTargetInteractable.Interact();
        }
    }
}

