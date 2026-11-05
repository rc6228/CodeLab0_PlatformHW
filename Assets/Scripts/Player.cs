using UnityEngine;
using UnityEngine.InputSystem;


public class
    Player : MonoBehaviour
{
    private InputAction moveInput;
    //public float force;
    public float speed;
    public float jumpPower;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public Rigidbody2D myBody;
    private Vector2 inputForce;

    public Transform groundChecker;
    public float checkSize;
    public LayerMask groundLayer;

    private bool onGround;

    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        inputForce = moveInput.ReadValue<Vector2>();
        animator.SetFloat("speed", myBody.linearVelocity.magnitude); //for walking animation
        
        
        //flipping not working because i  am trying to us enew input system?
      //  inputForce.x = Input.GetAxisRaw("Horizontal");
        //if (inputForce.x > 0)       spriteRenderer.flipX = false; 
       // else if (inputForce.x < 0)  spriteRenderer.flipX = true; //flip that thang!

    }


    private void
        FixedUpdate() //the step where physics engine runs. Any time you are using physics/gravity, put it in fixedupdate
    {
        //myBody.AddForce(inputForce * force);
        myBody.linearVelocityX = inputForce.x * speed;
        if (inputForce.y > 0 && onGround == true) //you do not need the == true. 
        {
            myBody.linearVelocityY = inputForce.y * jumpPower;
            onGround = false;
          
        }
        else
        {
            onGround = Physics2D.OverlapCircle(groundChecker.position, checkSize, groundLayer);
                animator.SetBool("Is Jumping", false);
           
        }

        if (onGround == false)
        {
            animator.SetBool("Is Jumping", true);
        }
       

    }
}