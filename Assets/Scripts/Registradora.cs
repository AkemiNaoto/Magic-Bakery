using System;
using UnityEngine;

public class Registradora : MonoBehaviour
{
    
    public bool EncostouRegistradora = false;

    void OnTriggerEnter2D(Collider2D Col)
    {
        
        if(Col.gameObject.CompareTag("Npc"))
        {
            
            EncostouRegistradora = true;

        }

    }

}

