using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    //vars
    public float FallingTime;

    private TargetJoint2D Joint;
    private BoxCollider2D Collider;
    private Animator Ani;

    void Start()
    {
        Joint = GetComponent<TargetJoint2D>();
        Collider = GetComponent<BoxCollider2D>();
        Ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // se o Player colidir com a FallinPlat
        if (collision.gameObject.tag == "Player")
        {
            //invocar Falling() apos FallingTime segundos
            Invoke("Falling", FallingTime);
            // ativar a animacao falling
            Ani.SetBool("falling", true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // se tiver collisao na layer 7. !nota: arrumar nome da layer seu animal
        if (collision.gameObject.layer == 7)
        {
            //destuir o gameObject logo destuir a FallinPlat
            Destroy(gameObject);
        }

    }

    void Falling()
    {
        // desativar o Joint / gravidade
        Joint.enabled = false;
        // ativar como Trigger para atravesar os Bricks
        Collider.isTrigger = true;
        //Ani.SetBool("falling", false); - test

    }
}
