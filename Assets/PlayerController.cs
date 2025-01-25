using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public GameObject playerObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     float xInput = Input.GetAxisRaw("Horizontal");
     float yInput = Input.GetAxisRaw("Vertical");
      
     playerObj.transform.Translate(Vector3.up * yInput * Time.deltaTime);

     
     
     
     
     // if (Input.GetButtonUp("Jump") == true)
      //{
        //Debug.Log("hi");
      //}   
    }
}
