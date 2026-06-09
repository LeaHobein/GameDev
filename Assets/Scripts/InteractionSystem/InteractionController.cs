using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    // variables
    Vector3 point1;
    Vector3 point2;
    [SerializeField]
    float capsuleRadius = 1f;
    [SerializeField]
    float interactionDistance = 0.5f;
    RaycastHit hit;
    IInteractable currentTargetInteractable;
    public bool holding = false;
    private InputAction interactAction;
    void Awake()
    {
        interactAction = gameObject.GetComponent<PlayerInput>().actions["Interact"];
    }

    public void Update()
    {
        UpdateCurrentInteractable();
        CheckForInteractionInput();
        if(interactAction.WasPerformedThisFrame() && currentTargetInteractable != null)
            {
                currentTargetInteractable.Interact(gameObject);
            }

        transform.Find("hold1").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("hold2").transform.Rotate(0f, 1f, 0f, Space.World);

        /*
        if(Keyboard.current.hKey.wasPressedThisFrame){
            transform.Find("hold1").GetComponent<MeshRenderer>().enabled = false;
            transform.Find("hold2").GetComponent<MeshRenderer>().enabled = false;
        }
        */
    }

    void UpdateCurrentInteractable()
    {
        currentTargetInteractable = hit.collider?.GetComponent<IInteractable>();
    }
    void CheckForInteractionInput()
    {
        Vector3 point1 = transform.position+Vector3.up;
        Vector3 point2 = transform.position;
        print("in checkforinteractioninput of " + gameObject.name);
        
        if(Physics.CapsuleCast(point1, point2, capsuleRadius, transform.forward, out hit, interactionDistance)){
            print(gameObject.name + "just raycasted" + hit.collider.gameObject);
        }
    }
}

