using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

// Carlos Leonardo Gonzalez Vilchis

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
        accionSalto.Disable(); 
        accionSalto.performed -= saltar;
    }

    public void saltar(InputAction.CallbackContext context) 
    {
        if (estado.estaEnPiso) {
            rb.linearVelocityY = velocidadY;
        }
    }

    void Update()
    {
        UnityEngine.Vector2 movimiento = accionMover.ReadValue<UnityEngine.Vector2>();
        
        rb.linearVelocityX = velocidadX * movimiento.x;
    }
}
