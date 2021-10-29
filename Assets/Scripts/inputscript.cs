using UnityEngine;

public class inputscript : MonoBehaviour
{
    private bool hasCatFood;
    
    private Animator animator;
    private float turn;
    public float turnSensitivity = 5f;
    private DialogTrigger _dialogTrigger;
    private bool isCatching;
    private bool isExploring;
    private bool inMiddleOfExploring;
    public bool hasKeyToTheDoor;

    public bool IsCatching
    {
        get { return isCatching; }

    }

    public bool HasCatFood
    {
        get { return HasCatFood; }
        set { hasCatFood = value; }

    }

    public bool IsExploring
    {
        get { return isExploring; }
    }

    public bool InMiddleOfExploring
    {
        get { return inMiddleOfExploring; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        //Cursor.lockState = CursorLockMode.Locked;
        _dialogTrigger = GetComponent<DialogTrigger>();
        isCatching = false;
        hasCatFood = false;
        hasKeyToTheDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        float moveV = Input.GetAxis("Vertical");

        bool hasMoveV = !Mathf.Approximately(moveV, 0);

        if (!hasMoveV)
        {
            animator.SetBool("IsForward", false);
            animator.SetBool("IsBackward", false);
        } else if (moveV > 0)
        {
            animator.SetBool("IsForward", true);
            animator.SetBool("IsBackward", false);
        } else
        {
            animator.SetBool("IsForward", false);
            animator.SetBool("IsBackward", true);
        }

        float moveH = Input.GetAxis("Horizontal");
        turn += moveH * turnSensitivity;


        //transform.localRotation = Quaternion.Euler(0, turn, 0);
        GetComponentInParent<Transform>().localRotation = Quaternion.Euler(0, turn, 0);
        

    }

    public void startExploring()
    {
        isExploring = true;
        animator.SetBool("Explore", true);
    }

    public void middleOfExploring()
    {
        inMiddleOfExploring = true;
    }

    public void afterExplore ()
    {
        isExploring = false;
        inMiddleOfExploring = false;
        animator.SetBool("Explore", false);
    }

    public void beforeGettingUp ()
    {
        _dialogTrigger.TriggerDialog();
    }

    public void startCatching ()
    {
        animator.SetBool("Catch", true);
    }

    public void duringCatching ()
    {
        isCatching = true;
        animator.SetBool("Catch", false);
    }

    public void afterCatching ()
    {
        isCatching = false;
    }
}
