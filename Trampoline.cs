using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    //arrumar a animacao de pulo - ok

    public float jumpForce;

    Animator Ani;
    private void Start()
    {
        Ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // !nota: a collisao vai retornar ao player
        if (collision.gameObject.tag == "Player") 
        {
            //ao colidir vai pegar o Rigidbody2D e add forca do tipo impulso | e a forca sera atribuida no vetor y
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Ani.SetTrigger("isjump");
        }
    }
}
