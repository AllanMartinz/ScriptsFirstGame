using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int score;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // ao collidir com a tag Player 
        if (collider.gameObject.tag == "Player")
        {
            // ira desativar o sprite da Apple
            sr.enabled = false;
            // desativar a hitbox 
            circle.enabled = false;
            // ativar o collected
            collected.SetActive(true);


            // ao colidir na apple vai adicionar mais score e vai ficar na GameController
            GameController.instance.totalScore += score;
            // chamar o metodo public de GameController
            GameController.instance.UpdateScoreText();

            // destruir o gameObject / Apple apos 0.4 segundos
            Destroy(gameObject, 0.4f);
        }
    }
}
