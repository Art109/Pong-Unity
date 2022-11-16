using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D bolaRB;
    private Vector2 ballSpeed;
    private float speed = 5f;
    private int limiteLateral = 10;

    public AudioClip boing;
    public Transform cameraTransform;


    public float delay = 2f;
    bool jogoIniciado = false;



    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        // Diminuindo o delay até zero
        delay = delay - Time.deltaTime;

        //Aplicando o delay ao inicio do jogo
        //coferindo se os 2 segundo foram contados e se variavel de controle permite a execução
        if(delay <= 0 && !jogoIniciado)
        {
            //Definindo a velocidade e direção inicial
            int direcao = Random.Range(0, 4);
            if (direcao == 0)
            {
                ballSpeed.x = speed;
                ballSpeed.y = speed;
            }
            else if (direcao == 1)
            {
                ballSpeed.x = -speed;
                ballSpeed.y = speed;
            }
            else if (direcao == 2)
            {
                ballSpeed.x = speed;
                ballSpeed.y = -speed;
            }
            else if (direcao == 3)
            {
                ballSpeed.x = -speed;
                ballSpeed.y = -speed;
            }


            //Adicionando velocidade a bola
            bolaRB.velocity = ballSpeed;

            //finalizado a condicional para ser executado apenas 1 vez
            jogoIniciado = true;

        }
        //Testa a posição da bola para caso ela ultrapasse o limite da tela
        if(transform.position.x > limiteLateral || transform.position.x < -limiteLateral)
        {
            // Caso a bola saia da tela reseta o jogo
            SceneManager.LoadScene("Jogo");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Ao colidir gera um som
        AudioSource.PlayClipAtPoint(boing, transform.position);
    }
}
