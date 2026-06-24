using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonPressController : MonoBehaviour
{
    [SerializeField]
    float pressDistance = 1.5f;

    DeliveryButton deliveryButton;
    Collider buttonCollider;

    [SerializeField]
    Material m_default;

    [SerializeField]
    Material m_outline;

    void Awake()
    {
        deliveryButton = FindAnyObjectByType<DeliveryButton>();
        if (deliveryButton != null)
            buttonCollider = deliveryButton.GetComponent<Collider>();
    }

    void Update()
    {
        if(IsNearButton())
        {
            GameObject.Find("button").GetComponent<MeshRenderer>().sharedMaterial = m_outline;
            //print("am Button nahe");
        }
        else
        {
            GameObject.Find("button").GetComponent<MeshRenderer>().sharedMaterial = m_default;
        }
    }

    public void OnButtonPress(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        if (deliveryButton == null || buttonCollider == null)
            return;

        if (!IsNearButton())
            return;

        deliveryButton.Press();
    }

    bool IsNearButton()
    {
        var closestPoint = buttonCollider.ClosestPoint(transform.position);
        return (closestPoint - transform.position).sqrMagnitude <= pressDistance * pressDistance;
    }
}
