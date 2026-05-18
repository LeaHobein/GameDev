using UnityEngine;
using UnityEngine.InputSystem;

public class PutDownController : MonoBehaviour
{
    [SerializeField]
    float putDownDistance = 1.5f;

    DeliveryPoint deliveryPoint;
    Collider deliveryCollider;

    void Awake()
    {
        deliveryPoint = FindAnyObjectByType<DeliveryPoint>();
        if (deliveryPoint != null)
            deliveryCollider = deliveryPoint.GetComponent<Collider>();
    }

    public void OnPutDown(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        if (deliveryPoint == null || deliveryCollider == null)
            return;

        if (!IsNearDelivery())
            return;

        deliveryPoint.PutDown();
    }

    bool IsNearDelivery()
    {
        var closestPoint = deliveryCollider.ClosestPoint(transform.position);
        return (closestPoint - transform.position).sqrMagnitude <= putDownDistance * putDownDistance;
    }
}
