using UnityEngine;

public class EstadoPersonaje : MonoBehaviour
{
    public bool estaEnPiso {get; private set;}= false;

    void OnTriggerEnter2D(Collider2D colision)
    {
        estaEnPiso = true;
    }

    void OnTriggerExit2D(Collider2D colision)
    {
        estaEnPiso = false;
    }


}
