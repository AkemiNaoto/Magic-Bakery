using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Machine : MonoBehaviour
{

    [SerializeField] private GameObject Caixa;
    [SerializeField] private float Doce, Cooldown;
    private bool PodeProduzir, Usou = false;

    void Start()
    {

        Doce = 0.0f;
        Cooldown = 0.0f;

    }


    void Update()
    {

        Produzindo();

    }

    public void OnTriggerEnter2D(Collider2D Col)
    {


        if (Col.gameObject.tag == "Player")
        {

            PodeProduzir = true;

        }

    }

    public void Produzindo()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            if (PodeProduzir == true)
            {

                if (Doce != 10.0f && Usou == false)
                {

                    Doce++;
                    Usou = true;
                    Cooldown = 0.0f;

                }

                else if (Doce == 10.0f)
                {

                    Instantiate(Caixa);
                    Caixa.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                    Doce = 0.0f;

                }


            }

        }

        if (Usou == true)
        {

            Cooldown += Time.deltaTime;

            if (Cooldown >= 8.0f)
            {

                Usou = false;

            }

        }

    }
}
