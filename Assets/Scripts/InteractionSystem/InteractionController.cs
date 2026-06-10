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

        transform.Find("hold1").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("hold2").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("hold3").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("hold4").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("hold5").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("hold6").transform.Rotate(0f, 1f, 0f, Space.World);

        /*
        if (Keyboard.current.hKey.wasPressedThisFrame){
            transform.Find("hold1").GetComponent<MeshRenderer>().enabled = false;
            transform.Find("hold2").GetComponent<MeshRenderer>().enabled = false;
            transform.Find("hold3").GetComponent<MeshRenderer>().enabled = false;
            transform.Find("hold4").GetComponent<MeshRenderer>().enabled = false;
            transform.Find("hold5").GetComponent<MeshRenderer>().enabled = false;
            transform.Find("hold6").GetComponent<MeshRenderer>().enabled = false;
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
        
        if(Physics.CapsuleCast(point1, point2, capsuleRadius, transform.forward, out hit, interactionDistance)){ //visualisierung irgendwie? oder triggerbased den boxen nen trigger geben
            print(gameObject.name + "just raycasted" + hit.collider.gameObject);
            if(interactAction.WasPerformedThisFrame() && currentTargetInteractable != null)
            {
                currentTargetInteractable.Interact(gameObject);
            }
        }
    }
}

