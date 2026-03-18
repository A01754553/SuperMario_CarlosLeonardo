using System;
using UnityEngine;

public class CambiaAnimacion : MonoBehaviour
{

private Rigidbody2D rb;
private Animator animator;
private SpriteRenderer sr; 
private EstadoPersonaje estado;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        estado = GetComponentInChildren<EstadoPersonaje>(); //el getcomponent in children existe pq el getcomponent solo busca elementos dentro de los hijos directos dle objeto
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocidad", Math.Abs (rb.linearVelocityX));
        sr.flipX = rb.linearVelocityX < -0.1;


        //manejo de la animacion de salto
        animator.SetBool("enPiso", estado.estaEnPiso);
    }
}
