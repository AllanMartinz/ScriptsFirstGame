using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPoint : MonoBehaviour
{
    //!nota: fazer uma transicao para as cenas | pegar todas as macas liberar a nextlevel - ok

    // Atribuir o lvl
    public string LvlName;

    private Animator Ani;
    private BoxCollider2D BoxCollider;

    private void Start()
    {
        //Atribuir os objs ao inicir o game
        Ani = GetComponent<Animator>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //usar o Update() para rodar o codigo 
        ActNextLvl();
    }



    void ActNextLvl()
    {
        //se o totalScore de GameController chegar a 600 pontos
        if (GameController.instance.totalScore == 600) // !nota: é uma bosta mas funciona
        {
            //a box do NextLevel ira ativar
            BoxCollider.enabled = true;
            //e a animacao de NextLvl_act ira rodar
            Ani.SetBool("act", true);
        }
    }

    // quando tiver collisao na box da NextLevel
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //se o NextLvel collidir com o "Player"
        if (collider.gameObject.tag == "Player")
        {
            // ira ativar a EndTransition direto do GameController
            GameController.instance.EndTranssition.SetActive(true);
            //ira ivocar a LoadLvl() apos 1.5 seundos
            Invoke("LoadLvl", 1.5f);

        }

    }

    //atribuir a string na unity para a proxima fase
    private void LoadLvl()
    {
        //ira carregar a cena (LvlName)
        SceneManager.LoadScene(LvlName);
    }
}
