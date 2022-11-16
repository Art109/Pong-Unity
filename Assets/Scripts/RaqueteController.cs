using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaqueteController : MonoBehaviour
{
    private Vector3 minhaPosicao;
    private float meuY;
    private float speed = 5f;
    private float moveLimit = 3.5f;

    //Controlador Player 1
    public bool player;

    //Controlardor IA
    public bool automatico = false;

    //Posição da bola 
    public Transform transformBola;
      

    // Start is called before the first frame update
    void Start()
    {
        //Pegando a posição inicial da raquete
        minhaPosicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaSpeed = speed * Time.deltaTime;
        //Atualizando o valor de Y da posição
        minhaPosicao.y = meuY;

        //Alterando a posição com a atualização do Y
        transform.position = minhaPosicao;


        //Diferenciando IA do controle
        if (!automatico)
        {

            //Pegando os valores das teclas e atualizando valor de Y
            if (player)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    meuY += deltaSpeed;

                }
                else if (Input.GetKey(KeyCode.S))
                {
                    meuY -= deltaSpeed;
                }
            }
            else
            {

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    meuY += deltaSpeed;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    meuY -= deltaSpeed;
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    automatico = true;
                }
            }

            if (meuY < -moveLimit)
            {
                meuY = -moveLimit;
            }
            else if (meuY > moveLimit)
            {
                meuY = moveLimit;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
                automatico = false;

            if (minhaPosicao.y < transformBola.position.y)
            {
                meuY += deltaSpeed;
            }
            else if (minhaPosicao.y > transformBola.position.y)
            {
                meuY -= deltaSpeed;
            }

            if (meuY < -moveLimit)
            {
                meuY = -moveLimit;
            }
            else if (meuY > moveLimit)
            {
                meuY = moveLimit;
            }
        }
    }


}
