using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    // variables
    Vector3 point1;
    Vector3 point2;
    [SerializeField]
    float capsuleRadius = 1f;
    [SerializeField]
    float interactionDistance = 0.5f;
    RaycastHit hit;
    IInteractable currentTargetInteractable;
    Materializer currentTargetMaterializer;
    public bool holding = false;
    public bool looking = false;
    public bool TutorialActive = true;
    private InputAction interactAction;
    private InputAction enter_skip;

    [SerializeField] TimeManager timeManager;
    [SerializeField] RecipeGen recipeGen;
    [SerializeField] DeliveryButton deliveryButton;

    private void Start()
    {
        //Zu Beginn kommt immer das Tutorial
        TutorialActive = true;

        timeManager = GameObject.Find("timerText").GetComponent<TimeManager>();
        recipeGen = GameObject.Find("RecipeGen").GetComponent<RecipeGen>();
        deliveryButton = GameObject.Find("delivery_button").GetComponent<DeliveryButton>();
    }

    void Awake()
    {
        interactAction = gameObject.GetComponent<PlayerInput>().actions["Interact"];
        enter_skip = gameObject.GetComponent<PlayerInput>().actions["SkipTutorial"];
    }

    public void Update()
    {
        UpdateCurrent();

        CheckForInteractionInput();
        CheckforTutorialSkip();

        transform.Find("hold1").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("hold2").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("hold3").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("hold4").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("hold5").transform.Rotate(0f, 1f, 0f, Space.World);
        transform.Find("hold6").transform.Rotate(0f, 1f, 0f, Space.World);

        /*
        if (Keyboard.current.hKey.wasPressedThisFrame){
            transform.Find("hold1").GetComponent<MeshRenderer>().enabled = false;
            transform.Find("hold2").GetComponent<MeshRenderer>().enabled = false;
            transform.Find("hold3").GetComponent<MeshRenderer>().enabled = false;
            transform.Find("hold4").GetComponent<MeshRenderer>().enabled = false;
            transform.Find("hold5").GetComponent<MeshRenderer>().enabled = false;
            transform.Find("hold6").GetComponent<MeshRenderer>().enabled = false;
        }
        */
    }

    void UpdateCurrent()
    {
        currentTargetInteractable = hit.collider?.GetComponent<IInteractable>();

        currentTargetMaterializer = hit.collider?.GetComponent<Materializer>();

        if(currentTargetMaterializer != null)
        {
            looking = true;
            currentTargetMaterializer.materialize();
        }else
        {
            looking = false;
        }
    }
    void CheckForInteractionInput()
    {
        Vector3 point1 = transform.position+Vector3.up;
        Vector3 point2 = transform.position;
        //print("in checkforinteractioninput of " + gameObject.name);
        
        if(Physics.CapsuleCast(point1, point2, capsuleRadius, transform.forward, out hit, interactionDistance)){ //visualisierung irgendwie? oder triggerbased den boxen nen trigger geben
            print(gameObject.name + "just raycasted" + hit.collider.gameObject);
            if(interactAction.WasPerformedThisFrame() && currentTargetInteractable != null)
            {
                currentTargetInteractable.Interact(gameObject);
                AudioManager.Instance.Play(AudioManager.SoundType.PlayerInteract);
            }
        }
    }

    void CheckforTutorialSkip()
    {
        if (enter_skip.WasPerformedThisFrame() && TutorialActive)
        {
            Debug.Log("du Birne");
            timeManager.StartRound();
            recipeGen.RoundRecipe();
            deliveryButton.Renew();
            TutorialActive = false;
        }
    }
}

