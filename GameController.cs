using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // pode usar as var de UI da unity
using UnityEngine.SceneManagement;
using System.Threading;

public class GameController : MonoBehaviour
{
    //!nota: animacao do hit | transicao do game over 

    public int totalScore;
    public Text scoreText;

    public static GameController instance;

    public GameObject GameOver;

    public GameObject StartTranssition;
    public GameObject EndTranssition;


    

    void Start()
    {
        instance = this; // permite usar o script inteiro pelo instance e posso acesar o q eu quiser dele que nao seja priv
        StartTranssition.SetActive(true);
        
    }

    void DisStartTrans()
    {
        StartTranssition.SetActive(false);

    }

    public void UpdateScoreText() // emcapsulamnto public para o Apple poder acessar
    {
        scoreText.text = totalScore.ToString(); // transforma o valor int para string
    }

    public void ShowGameOver() 
    {
        GameOver.SetActive(true);
    } 

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
}
