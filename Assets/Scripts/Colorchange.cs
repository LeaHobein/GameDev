using UnityEngine;
using UnityEngine.InputSystem;

public class Colorchange : MonoBehaviour, Materializer
{
    [SerializeField]
    Material m_default;

    [SerializeField]
    Material m_outline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player1").GetComponent<InteractionController>().looking == false || GameObject.Find("Player2").GetComponent<InteractionController>().looking == false)
        {
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = m_default;
        }
    }

    void change_color()
    {
        /*
        print("iz lookylooky");
        print(GameObject.Find("Player1").GetComponent<InteractionController>().looking);
        print(gameObject.GetComponent<MeshRenderer>().sharedMaterial);
        */
        if(GameObject.Find("Player1").GetComponent<InteractionController>().looking == true || GameObject.Find("Player2").GetComponent<InteractionController>().looking == true)
        {
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = m_outline;
        }
    }
    
    public void materialize()
    {
        change_color();
    }
}
