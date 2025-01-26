using UnityEngine;


 

public class PlayerReset : MonoBehaviour
{
    public Vector3 startPosition; // Posición inicial del jugador

    private void Start()
    {
        // Guarda la posición inicial del jugador al iniciar el juego
        startPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Comprueba si el objeto que tocó tiene la etiqueta "Ground"
        if (collision.gameObject.CompareTag("water"))
        {
            // Reinicia la posición del jugador a la posición inicial
            transform.position = startPosition;
        }
    }
}


