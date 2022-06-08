using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 //Varivel nomeando o arquivo
    public class Personagem : MonoBehaviour
{
    //Variaveis que estao sendo usadas na classe 
    public float Speed;
    public float jumpForce;
    private Rigidbody2D body;

    public bool isJumping, doubleJump;


    // Variavel que inicia a classe
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Variavel que se inicia a todo momento quando se inicia o inicia o jogo
    void Update()
    {
        Move();
        Jump();
    }

    // Variavel do movimento do andar
    void Move()
    {
        //O Input serve para detectar teclas e definir valores para elas
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
    }
    //Variavel do movimento de pulo
    void Jump()
    {
        //Para pular, colocaremos forca de impulso no personagem, ele e jogado para cima e cai com a gravidade aplicada nele, o RigidBody
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
               
                body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else
            {
                if (doubleJump)
                {
                    //Impede o personagem de pular mais de duas vezes, enquanto ele nao colide com o chao ele nao pode pular novamente
                    body.AddForce(new Vector2(0f, jumpForce * 1f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            isJumping = true;
        }
    }
}