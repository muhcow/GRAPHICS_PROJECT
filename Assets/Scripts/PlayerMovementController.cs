using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 6f;

    private Vector3 movement;
    //private Animator anim;
    private Rigidbody playerRb;
    private int groundMask;
    private float camRayLength = 200f;

    // Awake is called after all objects are initialized so you can safely speak to other objects or query them using
    // Awake is always called before any Start functions
    void Awake()
    {
        groundMask = LayerMask.GetMask("Ground");
        //anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
    }

    // fixed update updates with physics engine, normal update does renderer ++
    void FixedUpdate()
    {
        // GetAxisRaw handles movement for both keyboard and joystick
        // default keyboard wasd keys for movement, returns values -1, 0, 1
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
        Turning();
        //Animating(h, v);
    }

    void Move(float horizontal, float vertical)
    {
        movement.Set(horizontal, 0f, vertical);
        movement = speed * movement.normalized * Time.deltaTime;

        playerRb.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        // turn to direction of mouse i.e where raycast hits ground
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, groundMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRb.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        // h & v 
        //bool walking = h != 0f || v != 0f;

        //anim.SetBool("IsWalking", walking);
    }
}

