using UnityEngine;
using UnityEngine.UI;

public class ControllerManager : MonoBehaviour
{
    public static bool playerOneOnKeyboard;
    public static bool playerTwoOnKeyboard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerOneOnKeyboard = GameObject.Find("p1_keyboard_toggle").GetComponent<Toggle>().isOn;
        playerTwoOnKeyboard = GameObject.Find("p2_keyboard_toggle").GetComponent<Toggle>().isOn;
    }
}
