using System.Collections;
using UnityEngine;

public class BubbleHandler : MonoBehaviour
{
    [SerializeField] private float bubbleLifetime = 5f;
    [SerializeField] private float raiseSpeed = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
    
            if (other.TryGetComponent(out Rigidbody playerPhysics))
            {
                StartCoroutine(RaiseBubble(playerPhysics));

            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (other.TryGetComponent(out Rigidbody playerPhysics))
            {
                playerPhysics.transform.SetParent(null);
                playerPhysics.useGravity = true;
                StopAllCoroutines();
                Destroy(gameObject);

            }
        }

    }
    private IEnumerator RaiseBubble(Rigidbody playerRb)
    {


        float progress = 0;
        playerRb.useGravity = false;
        playerRb.transform.SetParent(transform);

        while (progress < bubbleLifetime)
        {
            progress += Time.deltaTime;
            transform.position =new Vector3(transform.position.x, transform.position.y+ raiseSpeed * Time.deltaTime, transform.position.z);
            yield return null;
        }

        playerRb.transform.SetParent(null);
        playerRb.useGravity = true;
        Destroy(gameObject);

    }


}
