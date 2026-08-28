using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using System;


public class Player : MonoBehaviour
{
    private float speed = 8f;
    public int Caixas = 0;
    public List<GameObject> caixas = new List<GameObject>(); 
    private Rigidbody2D rb;
    private Box C;
    private GameObject caixaPerto;

    public bool Soltar = false;
    [SerializeField] private GameObject Caixa;
    private Animator Anima;
    private SpriteRenderer Sr;
    private Prateleira Prat;
    private bool EncostouPrateleira = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Sr = GetComponent<SpriteRenderer>();
        Anima = GetComponent<Animator>();
        Prat = GameObject.FindWithTag("Prateleira").GetComponent<Prateleira>();

    }

    void Update()
    {

        Mover();
        SoltarCaixa();
        PegarCaixa();
        ColocarItem();

    }

        public void Mover()
        {


            float Horizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            float Vertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

            transform.Translate(Horizontal, Vertical, 0.0f);

            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                
                Sr.flipX = true;
                Anima.SetBool("Up", false);
                Anima.SetBool("Down", false);
                Anima.SetBool("IdleUp", false);
                Anima.SetBool("IdleDown", false);

            }

            else if(Input.GetAxisRaw("Horizontal") < 0)
            {
                
                Sr.flipX = false;
                Anima.SetBool("Up", false);
                Anima.SetBool("Down", false);
                Anima.SetBool("IdleUp", false);
                Anima.SetBool("IdleDown", false);

            }

            else if(Input.GetAxis("Vertical") > 0)
            {
                
                Anima.SetBool("Up", true);
                Anima.SetBool("Down", false);
                Anima.SetBool("IdleUp", false);
                Anima.SetBool("IdleDown", false);

            }

            else if(Input.GetAxis("Vertical") < 0)
            {
                
                Anima.SetBool("Up", false);
                Anima.SetBool("Down", true);
                Anima.SetBool("IdleUp", false);
                Anima.SetBool("IdleDown", false);

            }

            else if(Input.GetAxis("Vertical") == 0)
            {

                Anima.SetBool("Up", false);
                Anima.SetBool("Down", false);
                Anima.SetBool("IdleUp", true);
                Anima.SetBool("IdleDown", true);

            }

            Anima.SetFloat("Run", Math.Abs(Input.GetAxisRaw("Horizontal")));

        }


    void PegarCaixa()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (caixaPerto != null)
            {

                caixas.Add(caixaPerto);
                caixaPerto.SetActive(false);
                caixaPerto = null;

            }

        }

    }

    void SoltarCaixa()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (caixas.Count == 0)
            {

                return;

            }

            GameObject caixa = caixas[caixas.Count - 1];
            caixa.SetActive(true);
            caixa.transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y + 0.2f);
            caixas.RemoveAt(caixas.Count - 1);

        }

    }

    void ColocarItem()
    {
        
        if(EncostouPrateleira == true)
        {

           if(Input.GetKeyDown(KeyCode.E))
            {
                
                GameObject caixa = caixas[caixas.Count - 1];

                Box ScriptCaixa = caixa.GetComponent<Box>();
                if (ScriptCaixa.QutItem >= 1 )
                {
                    
                    Prat.Itens += 1;
                    ScriptCaixa.QutItem -= 1;

                }

                else if(ScriptCaixa.QutItem <= 0)
                {
                    
                    caixas.Remove(caixa);
                    Destroy(caixa);

                }

            }
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Caixa"))
        {

            caixaPerto = col.gameObject;

        }

        else if(col.gameObject.CompareTag("Prateleira"))
        {
            
            EncostouPrateleira = true;

        }
    }

    void OnCollisionExit2D(Collision2D col)
    {

        if (col.gameObject == caixaPerto)
        {

            caixaPerto = null;

        }

         else if(col.gameObject.CompareTag("Prateleira"))
        {
            
            EncostouPrateleira = false;

        }

    }



}