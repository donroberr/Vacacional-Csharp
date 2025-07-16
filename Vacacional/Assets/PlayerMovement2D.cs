using TMPro;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    //si primimos la tecla d me muevo a la derecha
    // si oprimimos la tecla a me muevo a la izquierda
    //si oprimimos la techa espacio salto
    [SerializeField]
    private float _velocidadMovimiento = 5f; // Velocidad de movimiento del jugador  
    [SerializeField]
    private float _fuerzaSalto = 5f; // Fuerza del salto del jugador
    [SerializeField]
    private Rigidbody2D _rb; // Componente Rigidbody2D del jugador
    [SerializeField] private TMP_Text _textoPuntaje;
    private int _puntaje = 0;

    private string[] _tipos = { "Moneda", "Trampa", "PowerUp" };
    private int[] _puntos = { 10, -20, 30 };  // Lo que suma o resta cada tipo


    // moverme lateralmente con el rigidbody2D
    private void Start()
    {

    }

    void Update()
    {
        MovimientoLateral();
        Salto();
    }

    private void MovimientoLateral()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _rb.linearVelocity = new Vector2(_velocidadMovimiento, _rb.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.linearVelocity = new Vector2(-_velocidadMovimiento, _rb.linearVelocity.y);
        }
        else
        {
            _rb.linearVelocity = new Vector2(0f, _rb.linearVelocity.y);
        }
    }

    private void Salto()
    {
        // Si presionamos la tecla espacio, saltamos
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rb.linearVelocity.y) < 0.01f)
        {
            _rb.AddForce(Vector2.up * _fuerzaSalto, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tipo = collision.tag;

        for (int i = 0; i < _tipos.Length; i++)
        {
            if (tipo == _tipos[i])
            {
                _puntaje += _puntos[i];
                _textoPuntaje.text = "Puntaje: " + _puntaje;

                Destroy(collision.gameObject); // elimina el objeto tocado
                break;
            }
        }
    }

    

}
