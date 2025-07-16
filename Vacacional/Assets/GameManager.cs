using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Elementos UI")]
    [SerializeField]
    private TMP_Text _tmpText;
    [SerializeField]
    private TMP_InputField _inputField;
    [SerializeField]
    private Button _botonSeguir;

    [Header("Jugador")]
    [SerializeField]
    private GameObject _jugador;

    [Header("Prefabs de objetos")]
    [SerializeField] private GameObject[] _prefabsObjetos;
    [SerializeField] private int _cantidadObjetos = 10;

    [Header("Temporizador")]
    [SerializeField]
    private TMP_Text _textoTemporizador;
    [SerializeField]
    private int _tiempoInicial = 60;


    private void Start()
    {
        _jugador.SetActive(false);
        _tmpText.text = "Hola, Como te llamas?";
        //_botonSeguir.onClick.AddListener(IniciarJuego);

        StartCoroutine(TemporizadorWhile());
    }
    private void Update()
    {

    }


    public void IniciarJuego()
    {
        string nombreJugador = _inputField.text;
        if (string.IsNullOrEmpty(nombreJugador))
        {
            _tmpText.text = "Por favor, ingresa un nombre.";
            return;
        }

        switch (nombreJugador.ToLower())
        {
            case "roberto":
                _tmpText.text = "Hola Roberto, bienvenido otra vez :/";
                break;
            case "maria":
                _tmpText.text = "Hola Maria, que bueno verte!";
                break;
            case "juan":
                _tmpText.text = "Hola Juan, listo para jugar?";
                break;
            case "lucia":
                _tmpText.text = "Hola Lucia, vamos a divertirnos!";
                break;
            default:
                _tmpText.text = $"Hola {nombreJugador}, bienvenido al juego!";
                break;
        }


        _inputField.gameObject.SetActive(false);
        _botonSeguir.gameObject.SetActive(false);
        _jugador.SetActive(true);

        CrearObjetos();
    }


    private void CrearObjetos()
    {
        float posicionX = 0f;

        for (int i = 0; i < _cantidadObjetos; i++)
        {
            // Elegir aleatoriamente uno de los objetos del arreglo
            int indiceAleatorio = Random.Range(0, _prefabsObjetos.Length);
            GameObject prefabElegido = _prefabsObjetos[indiceAleatorio];

            // Crear el objeto en la posición actual
            Vector3 posicion = new Vector3(posicionX, -1.5f, 0f);
            Instantiate(prefabElegido, posicion, Quaternion.identity);

            // Generar una distancia aleatoria entre 2 y 5 para separar
            float separacion = Random.Range(2f, 5f);
            posicionX += separacion;
        }
}


    private IEnumerator TemporizadorWhile()
    {
        int cuenta = _tiempoInicial;

        while (cuenta > 0)
        {
            _textoTemporizador.text = "Tiempo: " + cuenta;
            yield return new WaitForSeconds(1f); // espera 1 segundo
            cuenta--;
        }

        _textoTemporizador.text = "¡Tiempo agotado!";
        _jugador.SetActive(false); // opcional: detener al jugador
    }


    
}
