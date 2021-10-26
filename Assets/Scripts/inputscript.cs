using UnityEngine;

public class inputscript : MonoBehaviour
{
    
    private Animator animator;
    private float turn;
    public float turnSensitivity = 5f;
    private DialogTrigger _dialogTrigger;
    private bool isCatching;

    public bool IsCatching
    {
        get { return isCatching; }

    }

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        //Cursor.lockState = CursorLockMode.Locked;
        _dialogTrigger = GetComponent<DialogTrigger>();
        isCatching = false;
        
        
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
        

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("Catch", true);
        }

    }

    public void startExploring()
    {
        animator.SetBool("Explore", true);
    }


    public void afterExplore ()
    {
        animator.SetBool("Explore", false);
    }

    public void beforeGettingUp ()
    {
        //todo insert UI here
        _dialogTrigger.TriggerDialog();
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
