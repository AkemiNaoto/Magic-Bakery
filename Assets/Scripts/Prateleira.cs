using UnityEngine;

public class Prateleira : MonoBehaviour
{

    [SerializeField]private Sprite[] Bancada;
    private Sprite This;
    public int Itens;

    void Start()
    {

        This = GetComponent<Sprite>();

    }


    void Update()
    {

    }

}
