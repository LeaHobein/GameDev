using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private Transform[] spawnPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var p1 = PlayerInput.Instantiate(
            playerPrefab,
            controlScheme: "WASD",
            pairWithDevice: Keyboard.current);

        var p2 = PlayerInput.Instantiate(
            playerPrefab,
            controlScheme: "Arrows",
            pairWithDevice: Keyboard.current);
            Debug.Log(p2.currentControlScheme);
        p1.transform.position = spawnPoints[0].position;
        p2.transform.position = spawnPoints[1].position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
