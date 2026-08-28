using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Box : MonoBehaviour
{

    [SerializeField] private Player P;
    [SerializeField] private bool PodeClicar = false;
    public int QutItem = 10;
    private SpriteRenderer Atual;
    public bool PegouCaixa = false;
    public bool SoltouCaixa = false;
   
    void Start()
    {

        P = GameObject.FindWithTag("Player").GetComponent<Player>();
        Atual = GetComponent<SpriteRenderer>();
        transform.position = new Vector2(-18.23f,-0.67f);
        

    }

    void Update()
    {

        //LevarCaixa();

    }

   /* public void OnTriggerEnter2D(Collider2D Col)
    {


        if (Col.gameObject.tag == "Player")
        {

            PodeClicar = true;

        }


    }

    public void LevarCaixa()
    {
        
        if(PegouCaixa == true && PodeClicar == true)
        {
            
            transform.position = new Vector2(P.transform.position.x, P.transform.position.y);

        }

        else if(SoltouCaixa == true)
        {
            
            transform.position = new Vector2(P.transform.position.x, P.transform.position.y);
            SoltouCaixa = false;

        }

    }*/

}
