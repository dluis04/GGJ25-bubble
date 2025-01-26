using UnityEngine;


 

public class PlayerReset : MonoBehaviour
{
    public Vector3 startPosition; // Posici�n inicial del jugador

    private void Start()
    {
        // Guarda la posici�n inicial del jugador al iniciar el juego
        startPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Comprueba si el objeto que toc� tiene la etiqueta "Ground"
        if (collision.gameObject.CompareTag("water"))
        {
            // Reinicia la posici�n del jugador a la posici�n inicial
            transform.position = startPosition;
        }
    }
}


