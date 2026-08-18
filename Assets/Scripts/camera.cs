using System;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform Alvo;

    public void Start()
    {

        Alvo = GameObject.FindWithTag("Player").GetComponent<Transform>();

    }

    public void Update()
    {

        if (Alvo != null)
        {

            transform.position = new Vector3(Alvo.position.x, Alvo.position.y, -10.0f);

        }

    }




}