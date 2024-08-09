using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    //[SerializeField]// caso se nao aparecer o campo para atruibuir
    public float Speed;// contolar o speed na unity
    public float JumpForce;// controlar a forca do pulo
    public float DoubleJumpForce;

    public bool IsJumping;// bool do pulo --> true / false
    public bool DoubleJump;// bool do pulo duplo --> true / false

    private Animator Ani;
    private Rigidbody2D Rig;

    // deu o start no game vai rodar essa linha uma vez
    void Start()
    {
        // ao inicir ira pegar o componente Rigidbody2D e atribuir ao Rig
        Rig = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
    }


    // vai rodar essa linha a cada frame do game
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        //!Vector3 = funcao que mexe no vetor em 3 dimensoes x,y,z


        /// para saber no que vai atruibuir nas Axis, usar na unity Edit -> Project Settings -> Input Maneger -> Axis
        Vector3 movement = new Vector3(/*x=*/Input.GetAxis("Horizontal"), /*y=*/ 0f, /*z=*/ 0f);
        // usando  * Time.deltaTime * Speed para com o tempo aumentar a velocidade; se nao serias o mov em 1 em 1
        transform.position /*adicionar*/+= movement * Time.deltaTime * Speed;

        // ira mexer apenas na movimentacao horizontal logo vai mudar apenas o x | por ser mov. hori. nao vai mexer nos vetores y e z
        //uso do Input para chmar a GetAxis ela usara as teclas ao ("atribuir") ela | nesse caso o ("Horinzontal") ira mexer nas teclas hori. a,d,->,<-
        if (Input.GetAxis("Horizontal") > 0f /*+1*/)
        {
            //ativar animacao de andar
            Ani.SetBool("walk", true);
            //transformar o angulo 
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f /*-1*/)
        {
            Ani.SetBool("walk", true);
            // far o player olhar para tras
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f /*parado / 0*/)
        {
            //!nota: muita lore no animator
            Ani.SetBool("walk", false);
        }
    }

    void Jump()
    {
        // se a tecla espaco for apertada
        if (Input.GetButtonDown("Jump"))
        {
            // !nota:se o player nao estiver pulando ao clicar na tecla space ira pular ¨\_(OuO)_/¨ eu acho 
            if (!IsJumping)
            {
                // ira adicionar forca ao vetor y com o tipo de forca Impulso
                Rig.AddForce(new Vector2(/*x=*/0f, /*y=*/JumpForce), ForceMode2D.Impulse);
                // podera dar DoubleJump
                DoubleJump = true;
                // animacao pulo
                Ani.SetBool("jump", true);
            }
            else
            {
                //no entando se poder dar DoubleJump
                if (DoubleJump)
                {

                    //animacao DoubleJump
                    Ani.SetBool("double", true);
                    // !nota: mesmo codigo na de impresionante
                    Rig.AddForce(new Vector2(/*x=*/0f, /*y=*/JumpForce * DoubleJumpForce), ForceMode2D.Impulse);
                    // depois de tudo isso nao vai poder dar um TripleJump
                    DoubleJump = false;

                }
            }
        }
    }

    //esse metodo detecta toda a vez que o "Player" tocar alguma coisa
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //se ouver colisao no gameObject.layer, ele sera atribuida a layer 6: ground na unity
        if (collision.gameObject.layer == 6)
        {
            //ele nao ta pulando é false
            IsJumping = false;
            // animacao
            Ani.SetBool("jump", false);
            Ani.SetBool("double", false);
        }

        // ao colidir com a spike
        if (collision.gameObject.tag == "spike")
        {
            // aparecera o Game Over do GameController
            GameController.instance.ShowGameOver();
            // desturi o player
            Destroy(gameObject);
        }
    }

    //esse metodo quando o "Player" parar de tocar alguma coisa
    private void OnCollisionExit2D(Collision2D collision)
    {
        //atribuir a layer
        if (collision.gameObject.layer == 6)
        {
            //ele ta pulando é true
            IsJumping = true;
        }
    }
}
