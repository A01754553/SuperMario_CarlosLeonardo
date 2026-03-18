using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoverConInputAction : MonoBehaviour
{
    [SerializeField]
    private InputAction accionMover;

    [SerializeField]
    private InputAction accionSalto;

    private Rigidbody2D rb; 
    private EstadoPersonaje estado;

    private float velocidadX = 7f;

    private float velocidadY = 7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        accionMover.Enable();
        rb = GetComponent<Rigidbody2D>();
        estado = GetComponentInChildren<EstadoPersonaje>();
    }

    void OnEnable()
    {
        accionSalto.Enable();
        accionSalto.performed += saltar;
    }

    void OnDisable()
    {
        accionSalto.Disable(); //se puede quitar
        accionSalto.performed -= saltar;
    }

    public void saltar(InputAction.CallbackContext context) // esto se ocupa hacer public pq es una funcion que se va a llamar desde fuera
    {
        if (estado.estaEnPiso) {
            rb.linearVelocityY = velocidadY;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector2 movimiento = accionMover.ReadValue<UnityEngine.Vector2>();
        //transform.position = (UnityEngine.Vector2)transform.position + movimiento * velocidadX * Time.deltaTime;
        rb.linearVelocityX = velocidadX * movimiento.x;
    }
}
