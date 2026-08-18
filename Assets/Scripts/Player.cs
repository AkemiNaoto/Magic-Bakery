using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 8f;
    public int Caixas = 0;
    [SerializeField] private GameObject Caixa;

    private Rigidbody2D rb;
    [SerializeField] private Transform PosAtual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PosAtual = GetComponent<Transform>();
    }

    void Update()
    {

        Mover();
        DroparCaixa();

    }

    public void Mover()
    {


        float Horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(Horizontal, Vertical, 0.0f);

    }

    public void DroparCaixa()
    {

        if (Caixas != 0)
        {

            if (Input.GetKeyDown("q"))
            {

                Caixas -= 1;
                Instantiate(Caixa);
                Caixa.transform.position = new Vector3(PosAtual.position.x + 0.4f, PosAtual.position.y + 0.4f, 0.0f);

            }

        }

    }
}