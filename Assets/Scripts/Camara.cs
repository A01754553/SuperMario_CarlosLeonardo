using UnityEngine;
// Carlos Leonardo Gonzalez Vilchis
public class Camara : MonoBehaviour
{
    public Transform jugador;
    public float limiteIzq = 0f;
    public float limiteDer = 18f;

    void LateUpdate()
    {
        if (jugador != null)
        {
            float nuevaX = Mathf.Clamp(jugador.position.x, limiteIzq, limiteDer);
            transform.position = new Vector3(nuevaX, transform.position.y, -10);
        }
    }
}
