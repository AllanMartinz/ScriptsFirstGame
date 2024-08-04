using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    public float FallingTime;

    TargetJoint2D Joint;
    BoxCollider2D Collider;
    Animator Ani;

    void Start()
    {
        Joint = GetComponent<TargetJoint2D>();
        Collider = GetComponent<BoxCollider2D>();
        Ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Falling", FallingTime);
            Ani.SetBool("falling", true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }

    }

    void Falling()
    {
        Joint.enabled = false;
        Collider.isTrigger = true;
        //Ani.SetBool("falling", false);
        
    }
}
