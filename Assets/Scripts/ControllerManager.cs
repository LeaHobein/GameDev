using UnityEngine;
using UnityEngine.UI;
public class ControllerManager : MonoBehaviour
{
    public static bool playersOnKeyboard;
    void Update()
    {
        playersOnKeyboard = GameObject.Find("player_keyboard_toggle").GetComponent<Toggle>().isOn;
    }
}
