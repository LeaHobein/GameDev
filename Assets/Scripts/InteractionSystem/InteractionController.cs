using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    public Vector3 boxHalfWidth = new Vector3(0.5f,0.5f,0.5f);
    public float interactionDistance = 0.5f;
    RaycastHit hit;
    IInteractable currentTargetInteractable;
    Materializer currentTargetMaterializer;
    public bool holding = false;
    public bool looking = false;
    public bool TutorialActive = true;
    private InputAction interactAction;
    private InputAction enter_skip;
    public TimeManager timeManager;
    public RecipeGen recipeGen;
    public DeliveryButton deliveryButton;
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
    public void OnDrawGizmos()
    {
        //editor view of start and end of boxcast
        Gizmos.DrawWireCube(transform.position-transform.forward*0.5f, boxHalfWidth);
        Gizmos.DrawWireCube(transform.position+transform.forward*interactionDistance, boxHalfWidth);
    }
    void CheckForInteractionInput()
    {
        //boxcast: box is sent at an interaction distance
        //if interactable is hit and interact button pressed, object is interacted with
        Vector3 boxCenter = transform.position-transform.forward*0.5f;
        if(Physics.BoxCast(boxCenter, boxHalfWidth, transform.forward, out hit, Quaternion.identity, interactionDistance)){
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
            timeManager.StartRound();
            recipeGen.RoundRecipe();
            deliveryButton.Renew();
            TutorialActive = false;
        }
    }
}

