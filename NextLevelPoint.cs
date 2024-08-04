using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPoint : MonoBehaviour
{
    //!nota: fazer uma transicao para as cenas | pegar todas as macas liberar a nextlevel - ok
    

    public string LvlName;
    Animator Ani;
    BoxCollider2D BoxCollider;

    private void Start()
    {
        Ani = GetComponent<Animator>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        ActNextLvl();
    }



    void ActNextLvl()
    {
        if(GameController.instance.totalScore == 600)
        {
            BoxCollider.enabled = true;
            Ani.SetBool("act", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") 
        {
        GameController.instance.EndTranssition.SetActive(true);
        Invoke("LoadLvl", 1.5f);
            
        }

    }
    private void LoadLvl()
    {
        SceneManager.LoadScene(LvlName);
    }
}
