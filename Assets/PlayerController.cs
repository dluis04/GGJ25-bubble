using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public GameObject playerObj;
  public Rigidbody rb;
  public float moveSpeed;
  public bool isGrounded;

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
      if (isGrounded){
        playerObj.transform.Translate(Vector3.up * yInput * Time.deltaTime);
        rb.AddRelativeForce(Vector3.right * xInput * Time.deltaTime * moveSpeed);
      }
     
      
      //if (Input.GetButtonDown("Jump") == true)
      //{
        //Debug.Log("hi");
      //}

     
     
     
     
     // if (Input.GetButtonUp("Jump") == true)
      //{
        //Debug.Log("hi");
      //}   
    }
    void OnCollisionEnter(Collision collision){
      if (collision.gameObject.tag == "Ground"){
        isGrounded = true;
      }
    }
    void OnCollisionExit(Collision collision){
      if (collision.gameObject.tag == "Ground"){
        isGrounded = true;
      }
    }
}
