using Unity.VisualScripting;
using UnityEngine;

public class Box : MonoBehaviour
{

    [SerializeField] private Player P;
    private bool PodeClicar = false;
    void Start()
    {

        P = GameObject.FindWithTag("Player").GetComponent<Player>();

    }


    void Update()
    {

        PegarCaixa();

    }

    public void OnTriggerEnter2D(Collider2D Col)
    {


        if (Col.gameObject.tag == "Player")
        {

            PodeClicar = true;

        }


    }

    public void PegarCaixa()
    {

        if (PodeClicar == true)
        {

            if (Input.GetButtonDown("Fire1"))
            {

                P.Caixas += 1;
                Destroy(gameObject);

            }

        }

    }
}
