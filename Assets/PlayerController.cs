using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerVisuals;
    public GameObject playerObj;
    public Rigidbody rb;
    public Animator animator;

    [Header("GROUND CHECK")]
    public float moveSpeed;
    public bool isGrounded;
    public float groundCheckDistance;
    public LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
      
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
                rb.AddRelativeForce(new Vector3(0, 180));  
        }


        if (isGrounded || rb.linearVelocity.y<0.25)
        {
         
            rb.AddRelativeForce(transform.right * xInput * Time.deltaTime * moveSpeed);

        }

        if (xInput!=0)
        {
            playerVisuals.localRotation = Quaternion.Euler(0, xInput < 0 ? -90 : 90, 0);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("verticalSpeed", rb.linearVelocity.y);




        //if (Input.GetButtonDown("Jump") == true)
        //{
        //Debug.Log("hi");
        //}





        // if (Input.GetButtonUp("Jump") == true)
        //{
        //Debug.Log("hi");
        //}   
    }
    private void FixedUpdate()
    {
        IsGrounded();
    }


    bool IsGrounded() 
    {
        float dist = GetComponent<Collider>().bounds.extents.y;

        RaycastHit groundRay;
        Vector3 center = GetComponent<Collider>().bounds.center;

        Debug.DrawRay(center, Vector3.down * groundCheckDistance, Color.red);

        bool hit = Physics.Raycast(center, Vector3.down, out groundRay, groundCheckDistance, groundLayer);

        if (hit)
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
        else
        {
            isGrounded = false;
            Debug.Log("AIR");
        }

        return true;

    }
   
 
    //void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        isGrounded = true;
    //    }
    //}
    //void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        isGrounded = false;
    //    }
    //}
}
