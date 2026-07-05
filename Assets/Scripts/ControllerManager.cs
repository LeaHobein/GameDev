using UnityEngine;
using UnityEngine.UI;

public class ControllerManager : MonoBehaviour
{
    public static bool playersOnKeyboard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playersOnKeyboard = GameObject.Find("player_keyboard_toggle").GetComponent<Toggle>().isOn;
    }
}
