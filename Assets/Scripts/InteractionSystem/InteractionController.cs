using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    // variables
    Vector3 point1;
    Vector3 point2;
    [SerializeField]
    Vector3 boxHalfWidth = new Vector3(0.5f,0.5f,0.5f);
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
        Gizmos.DrawWireCube(transform.position-transform.forward*0.5f, boxHalfWidth);
        Gizmos.DrawWireCube(transform.position+transform.forward*interactionDistance, boxHalfWidth);
    }
    void CheckForInteractionInput()
    {
        
        Vector3 boxCenter = transform.position-transform.forward*0.5f;
        Vector3 lineStart = new Vector3(boxCenter.x - boxHalfWidth.x, boxCenter.y, boxCenter.z);
        Vector3 lineEnd = new Vector3(boxCenter.x + boxHalfWidth.x, boxCenter.y, boxCenter.z);
        Debug.DrawLine(lineStart, lineEnd);
        Debug.DrawLine(Vector3.zero, transform.forward);
        
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
            Debug.Log("du Birne");
            timeManager.StartRound();
            recipeGen.RoundRecipe();
            deliveryButton.Renew();
            TutorialActive = false;
        }
    }
}

