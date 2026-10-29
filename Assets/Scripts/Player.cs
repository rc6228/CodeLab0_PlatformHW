using UnityEngine;
using UnityEngine.InputSystem;


public class
    Player : MonoBehaviour
{
    private InputAction moveInput;
    //public float force;
    public float speed;
    public float jumpPower;


    public Rigidbody2D myBody;
    private Vector2 inputForce;

    public Transform groundChecker;
    public float checkSize;
    public LayerMask groundLayer;

    private bool onGround;

    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
    }


    void Update()
    {
        inputForce = moveInput.ReadValue<Vector2>();
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
        }

    }
}