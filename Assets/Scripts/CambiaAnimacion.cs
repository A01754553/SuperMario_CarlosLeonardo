using System;
using UnityEngine;
// Carlos Leonardo Gonzalez Vilchis
public class CambiaAnimacion : MonoBehaviour
{

private Rigidbody2D rb;
private Animator animator;
private SpriteRenderer sr; 
private EstadoPersonaje estado;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        estado = GetComponentInChildren<EstadoPersonaje>(); 
    }

    
    void Update()
    {
        animator.SetFloat("Velocidad", Math.Abs (rb.linearVelocityX));
        sr.flipX = rb.linearVelocityX < -0.1;


        animator.SetBool("enPiso", estado.estaEnPiso);
    }
}
