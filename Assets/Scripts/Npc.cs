using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Npc : MonoBehaviour
{
    

    [SerializeField] private int Etapa = 0, Itens = 0, QuantItens = 0;

    private float Velocidade = 5;
    [SerializeField] private bool ChegouPrateleira;
    private Prateleira Prat;
    private Registradora Reg;
    private Tempo Temp;

    void Start()
    {
        
        Prat = GameObject.FindWithTag("Prateleira").GetComponent<Prateleira>();
        QuantItens = Random.Range(1, 4);
        Reg = GameObject.FindWithTag("Registradora").GetComponent<Registradora>();
        Temp = GameObject.FindWithTag("Tempo").GetComponent<Tempo>();

    }

    void Update()
    {
        
        Andar();

    }

    void Andar()
    {
        
        if(Etapa == 0)
        {
            
            if(transform.position.y > 0.71f)
            {
                
                transform.Translate(0.0f, -1.0f * Velocidade * Time.deltaTime, 0.0f);

            }

            else if(transform.position.y <= 0.71f)
            {
                
                Etapa++;

            }

        }

        else if(Etapa == 1)
        {
            
            if(transform.position.x < 26.58f)
            {
                
                transform.Translate(1.0f * Velocidade * Time.deltaTime, 0.0f, 0.0f);

            }

            else if(transform.position.x >= 26.58f)
            {
                
                Etapa++;

            }
            
        }

        else if(Etapa == 2)
        {
            
            if(transform.position.y < 1.46f)
            {
                
                transform.Translate(0.0f, 1.0f * Velocidade * Time.deltaTime, 0.0f);

            }

            else if(transform.position.y >= 1.46f)
            {
                
                Etapa++;

            }

        }

        else if(Etapa == 3)
        {
            
            if(ChegouPrateleira == true && Itens < QuantItens)
            {
                
                Prat.Itens -= QuantItens;
                Itens += QuantItens;

            }

            else if(ChegouPrateleira == true && Itens == QuantItens)
            {
                
                Etapa++;

            }

        }

        else if(Etapa == 4)
        {
            
            if(transform.position.y > -0.59f)
            {
                
                transform.Translate(0.0f, -1.0f * Velocidade * Time.deltaTime, 0.0f);

            }

            else if(transform.position.y <= -0.59f)
            {
                
                Etapa++;

            }

        }

        else if (Etapa == 5)
        {
            
            if(Reg.EncostouRegistradora == true && Itens == QuantItens)
            {
                
                Temp.Moedas = Itens * Random.Range(5,10);
                Itens = 0;

            }

            else if (Reg.EncostouRegistradora == true && Itens != QuantItens)
            {
                
                Etapa++;

            }

        }

       else if(Etapa == 6)
        {
            
            if(transform.position.y < 0.71f)
            {
                
                transform.Translate(0.0f, 1.0f * Velocidade * Time.deltaTime, 0.0f);

            }

            else if(transform.position.y >= 0.71f)
            {
                
                Etapa++;

            }

        }

        else if(Etapa == 7)
        {
            
            if(transform.position.x > 6.51f)
            {
                
                transform.Translate(1.0f * Velocidade * Time.deltaTime, 0.0f, 0.0f);

            }

            else if(transform.position.x <= 6.51f)
            {
                
                Etapa++;

            }

        }

        else if(Etapa == 8)
        {
            
            if(transform.position.y < -28f)
            {
                
                transform.Translate(0.0f, -1.0f * Velocidade * Time.deltaTime, 0.0f);

            }

            else if(transform.position.y >= -28f)
            {
                
                Destroy(gameObject);

            }

        }

    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        
        if(Col.gameObject.CompareTag("Prateleira"))
        {
            
            ChegouPrateleira = true;

        }

    }

}
