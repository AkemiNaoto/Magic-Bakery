using UnityEngine;
using TMPro;

public class Tempo : MonoBehaviour
{
   
    [SerializeField] private TextMeshProUGUI Texto;
    private float Hora, Minuto;
    [SerializeField] private TextMeshProUGUI Moeda;
    public int Moedas;

    void Start()
    {
        
        Hora = 08f;
        Minuto = 00f;
        Texto.text =  "08:00";

    }

    // Update is called once per frame
    void Update()
    {
        
        Temporizador();

    }

    public void Temporizador()
    {
        
         Minuto += Time.deltaTime;

            if (Minuto >= 60f)
            {
                Minuto = 0f;
                Hora += 1f;
            }

            if (Hora >= 18f)
            {
                Hora = 18f;
                Minuto = 0f;
            }

         Texto.text = Hora.ToString("00") + ":" + Minuto.ToString("00");

    }

    public void ManagerMoedas()
    {
        
        Moeda.text = Moedas.ToString("0000,00$");
        
    }

}

