using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool dirRight = true; // true = comecar na direita
    private float timer;

    void Update()
    {
        if (dirRight) ///> esse aqui vai ser invertido
        {
            // se true = direita
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            // se false = esquerda
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        //o deltaTime vai conometrar a partir que o jogo iniciar
        timer += Time.deltaTime;
        // se o timer for maior ou igual ao moveTime -> vai ser atribuido o move time na unity
        if (timer >= moveTime)
        {
            // ai ele vai executar esse if
            ///> quando passar do tempo atribuido ele vai inverter o bool
            dirRight = !dirRight;
            //e em seguida zerar o timer 
            timer = 0f;
        }
    }
}
