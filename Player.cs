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

    Animator Ani;
    Rigidbody2D Rig;

    void Start() // deu o start no game vai rodar essa linha uma vez
    {
        Rig = GetComponent<Rigidbody2D>(); // ao inicir ira pegar o componente Rigidbody2D e atribuir ao Rig
        Ani = GetComponent<Animator>();
    }


    void Update() // vai rodar essa linha a cada frame do game
    {
        Move();
        Jump();
    }

    void Move()
    {
        //!Vector3 = funcao que mexe no vetor em 3 dimensoes x,y,z
        // ira mexer apenas na movimentacao horizontal logo vai mudar apenas o x | por ser mov. hori. nao vai mexer nos vetores y e z
        //uso do Input para chmar a GetAxis ela usara as teclas ao ("atribuir") ela | nesse caso o ("Horinzontal") ira mexer nas teclas hori. a,d,->,<-
        /// para saber no que vai atruibuir nas Axis, usar na unity Edit -> Project Settings -> Input Maneger -> Axis
        Vector3 movement = new Vector3(/*x=*/Input.GetAxis("Horizontal"), /*y=*/ 0f, /*z=*/ 0f);
        transform.position /*adicionar*/+= movement * Time.deltaTime * Speed; // usando  * Time.deltaTime * Speed para com o tempo aumentar a velocidade; se nao serias o mov em 1 em 1

        if (Input.GetAxis("Horizontal") > 0f)
        {
            Ani.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }   
        
        if (Input.GetAxis("Horizontal") < 0f)
        {
            Ani.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        } 
        
        if (Input.GetAxis("Horizontal") == 0f)
        {
            Ani.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump")) // se a tecla espaco for apertada
        { 
            if (!IsJumping)
            {
                Rig.AddForce(new Vector2(/*x=*/0f, /*y=*/JumpForce), ForceMode2D.Impulse); // ira adicionar forca ao vetor y com o tipo de forca Impulso
                DoubleJump = true;
                Ani.SetBool("jump", true);
            }
            else
            {
                if (DoubleJump)
                {
                    
                Ani.SetBool("double", true);
                    Rig.AddForce(new Vector2(/*x=*/0f, /*y=*/JumpForce * DoubleJumpForce), ForceMode2D.Impulse);
                    DoubleJump = false;
                    
                }
            }
        }
    }

    //esse metodo detecta toda a vez que o "Player" tocar alguma coisa
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) //se ouver colisao no gameObject.layer, ele sera atribuida a layer 6: ground na unity
        {
            IsJumping = false;//ele nao ta pulando é false
            Ani.SetBool("jump", false);
            Ani.SetBool("double", false);
        }
        if (collision.gameObject.tag == "spike")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

    //esse metodo quando o "Player" parar de tocar alguma coisa
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) //atribuir a layer
        {
            IsJumping = true;//ele ta pulando é true
            
            
        }
    }
}
