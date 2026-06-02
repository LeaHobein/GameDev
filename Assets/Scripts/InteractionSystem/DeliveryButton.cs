using UnityEngine;

public class DeliveryButton : MonoBehaviour
{
    [SerializeField]
    private GameObject spotOne;
    [SerializeField]
    private GameObject spotTwo;
    [SerializeField]
    private GameObject spotThree;
    public void Press()
    {
        emptySpot(spotOne);
        emptySpot(spotTwo);
        emptySpot(spotThree);
        Debug.Log("Button Pressed");
    }
    private void emptySpot(GameObject spot)
    {
        Renderer[] materialMeshes = spot.GetComponentsInChildren<Renderer>();
        foreach(Renderer m in materialMeshes)
        {
            m.enabled = false;
        }
    }
}
