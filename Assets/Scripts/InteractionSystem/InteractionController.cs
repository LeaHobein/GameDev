using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    
    Vector3 point1;
    Vector3 point2;
    [SerializeField]
    float capsuleRadius = 1f;
    [SerializeField]
    float interactionDistance = 1f;
    RaycastHit hit;
    IInteractable currentTargetInteractable;

    void Awake()
    {

    }

    public void Update()
    {
        UpdateCurrentInteractable();
        CheckForInteractionInput();

        transform.Find("hold1").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("hold2").transform.Rotate(0f, 1f, 0f, Space.World);

        if(Keyboard.current.hKey.wasPressedThisFrame){
            transform.Find("hold1").GetComponent<MeshRenderer>().enabled = false;
            transform.Find("hold2").GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void UpdateCurrentInteractable()
    {
        currentTargetInteractable = hit.collider?.GetComponent<IInteractable>();
    }
    void CheckForInteractionInput()
    {
        Vector3 point1 = transform.position+Vector3.up;
        Vector3 point2 = transform.position;
        
        if(Physics.CapsuleCast(point1, point2, capsuleRadius, transform.forward, out hit, interactionDistance)){
            //Debug.Log(hit.collider.gameObject);
            if(Keyboard.current.gKey.wasPressedThisFrame && currentTargetInteractable != null)
            {
                currentTargetInteractable.Interact(gameObject);
            }
        }
    }
}

