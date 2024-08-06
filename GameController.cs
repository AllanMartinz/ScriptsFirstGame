using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // pode usar as var de UI da unity
using UnityEngine.SceneManagement;
using System.Threading;

public class GameController : MonoBehaviour
{
    //!nota: animacao do hit | transicao do game over 

    //vars
    public int totalScore;
    public Text scoreText;

    public static GameController instance;

    // atribuir os GameObject
    public GameObject GameOver;
    public GameObject StartTranssition;
    public GameObject EndTranssition;




    void Start()
    {
        // permite usar o script inteiro pelo instance e posso acesar o q eu quiser dele que nao seja priv
        instance = this;
        // ativar a StartTransition ao jogo Iniciar 
        StartTranssition.SetActive(true);

    }

    void DisStartTrans()
    {
        //apos o Start() desativar a StartTransition
        StartTranssition.SetActive(false);

    }

    // encapsulamnto public para o Apple poder acessar
    public void UpdateScoreText()
    {
        // transforma o valor int para string
        scoreText.text = totalScore.ToString();
    }

    // public para o Player| Ativar GameOverPanel
    public void ShowGameOver()
    {
        GameOver.SetActive(true);
    }

    // public para o button do game over| dar o restart no game
    public void RestartGame(string lvlName)
    {
        //carregar lvlName atribuida
        SceneManager.LoadScene(lvlName);
    }
}
