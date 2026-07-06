using UnityEngine;
using UnityEngine.InputSystem;

public class Colorchange : MonoBehaviour, Materializer
{
    public GameObject objectus;
    public Material m_default;
    public Material m_outline;
    void Update()
    {
        if(GameObject.Find("Player1").GetComponent<InteractionController>().looking == false && GameObject.Find("Player2").GetComponent<InteractionController>().looking == false)
        {
            deline();
        }
    }
    void change_color()
    {
        if(GameObject.Find("Player1").GetComponent<InteractionController>().looking == true || GameObject.Find("Player2").GetComponent<InteractionController>().looking == true)
        {
            outline();
        }
    }
    public void materialize()
    {
        change_color();
    }

    public void outline()
    {
        objectus.GetComponent<MeshRenderer>().sharedMaterial = m_outline;
    }
    public void deline()
    {
        objectus.GetComponent<MeshRenderer>().sharedMaterial = m_default;
    }
}