using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITiendaAccesorios : MonoBehaviour
{
    [Header("UI Accesorios")]
    [SerializeField] private AccessoryCard[] cards;
    [SerializeField] private GameObject buttonComprar;
    [SerializeField] private GameObject buttonSeleccionar;
    [SerializeField] private GameObject textoSeleccionado;
    [SerializeField] private TextMeshProUGUI costoAccesorioTMP;
    [SerializeField] private string menuCorrespondiente;

    [Header("Config")]
    [SerializeField] private GameObject[] accesorios;
    [SerializeField] private TextMeshProUGUI textoDiamantesTotales;
    [SerializeField] private RawImage fondoImagen;
    [SerializeField] private float xValor;
    [SerializeField] private float yValor;

    private AccessoryCard cardClickeado;
    private AccessoryCard cardCargado;

    private void Start()
    {
        cardCargado = cards[AccessoryManager.Instancia.AccesorioSeleccionadoIndex];
        ActualizarInfo(cardCargado);
    }

    private void Update()
    {
        textoDiamantesTotales.text = MonedaManager.Instancia.MonedasTotales.ToString();
        fondoImagen.uvRect = new Rect(fondoImagen.uvRect.position
                                      + new Vector2(xValor, yValor) * Time.deltaTime, fondoImagen.uvRect.size);
    }

    public void ComprarAccesorio()
    {
        if (MonedaManager.Instancia.MonedasTotales >= cardClickeado.Costo)
        {
            SoundManager.Instancia.ReproducirSonidoFX(SoundManager.Instancia.uiClip);
            cardClickeado.ComprarAccesorio();
            ActualizarInfo(cardClickeado);
            MonedaManager.Instancia.GastarMonedas(cardClickeado.Costo);
        }
    }

    public void SeleccionarAccesorio()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].DeseleccionarAccesorio();
        }

        SoundManager.Instancia.ReproducirSonidoFX(SoundManager.Instancia.uiClip);
        AccessoryManager.Instancia.SeleccionarAccesorio(cardClickeado);
        cardClickeado.SeleccionarAccesorio();
        ActualizarInfo(cardClickeado);
    }

    public void RegresarAlMenu()
    {
        SoundManager.Instancia.ReproducirSonidoFX(SoundManager.Instancia.uiClip);
        SceneManager.LoadScene("MainMenu");
    }

    private void ActualizarInfo(AccessoryCard card)
    {
        MostrarUISegunCondicion(card);
        MostrarAccesorioSeleccionado(card);
    }

    private void MostrarUISegunCondicion(AccessoryCard card)
    {
        if (card.Comprado)
        {
            if (card.Seleccionado)
            {
                buttonComprar.SetActive(false);
                buttonSeleccionar.SetActive(false);
                textoSeleccionado.SetActive(true);
            }
            else
            {
                buttonComprar.SetActive(false);
                buttonSeleccionar.SetActive(true);
                textoSeleccionado.SetActive(false);
            }
        }
        else
        {
            costoAccesorioTMP.text = card.Costo.ToString();
            buttonComprar.SetActive(true);
            buttonSeleccionar.SetActive(false);
            textoSeleccionado.SetActive(false);
        }
    }

    private void MostrarAccesorioSeleccionado(AccessoryCard card)
    {

        /*for (int i = 0; i < accesorios.Length; i++)
        {
            accesorios[i].SetActive(false);
        }*/
        switch (menuCorrespondiente)
        {
            case "menuLentes":
                foreach (GameObject padre in accesorios)
                {
                    // Obtener el hijo específico del objeto padre mediante card.Index
                    Transform hijoEspecifico = padre.transform.GetChild(card.Index);

                    // Verificar si el hijo específico está activo
                    if (!hijoEspecifico.gameObject.activeSelf)
                    {
                        // Iterar sobre los hijos del objeto padre actual
                        for (int i = 0; i < padre.transform.childCount; i++)
                        {
                            // Obtener el hijo actual
                            Transform hijo = padre.transform.GetChild(i);

                            // Desactivar el hijo actual
                            hijo.gameObject.SetActive(false);

                            // Imprimir el nombre del hijo desactivado
                            // Debug.Log("Hijo desactivado: " + hijo.gameObject.name);
                        }

                        // Activar el hijo específico
                        hijoEspecifico.gameObject.SetActive(true);
                        PlayerPrefs.SetString("LenteActivado", hijoEspecifico.gameObject.name);
                        // Verificar si el hijo específico está activo
                        if (hijoEspecifico.gameObject.activeSelf)
                        {
                            // Utiliza concatenación para construir el mensaje
                            Debug.Log("Padre: " + padre.name + ", Hijo Activado correctamente: " + hijoEspecifico.gameObject.name);
                        }
                        else
                        {
                            Debug.Log("Hijo no se activó: " + hijoEspecifico.gameObject.name);
                        }
                    }
                    else
                    {
                        Debug.Log("El hijo ya está activo");
                    }
                }
                break;

            case "menuSombreros":
                foreach (GameObject padre in accesorios)
                {
                    // Obtener el hijo específico del objeto padre mediante card.Index
                    Transform hijoEspecifico = padre.transform.GetChild(card.Index);

                    // Verificar si el hijo específico está activo
                    if (!hijoEspecifico.gameObject.activeSelf)
                    {
                        // Iterar sobre los hijos del objeto padre actual
                        for (int i = 0; i < padre.transform.childCount; i++)
                        {
                            // Obtener el hijo actual
                            Transform hijo = padre.transform.GetChild(i);

                            // Desactivar el hijo actual
                            hijo.gameObject.SetActive(false);

                            // Imprimir el nombre del hijo desactivado
                            // Debug.Log("Hijo desactivado: " + hijo.gameObject.name);
                        }


                        // Activar el hijo específico
                        hijoEspecifico.gameObject.SetActive(true);
                        PlayerPrefs.SetString("SombreroActivado", hijoEspecifico.gameObject.name);
                        // Verificar si el hijo específico está activo
                        if (hijoEspecifico.gameObject.activeSelf)
                        {
                            // Utiliza concatenación para construir el mensaje
                            Debug.Log("Padre: " + padre.name + ", Hijo Activado correctamente: " + hijoEspecifico.gameObject.name);
                        }
                        else
                        {
                            Debug.Log("Hijo no se activó: " + hijoEspecifico.gameObject.name);
                        }
                    }
                    else
                    {
                        Debug.Log("El hijo ya está activo");
                    }
                }
                break;
        }
        



        // Aquí puedes implementar la lógica para mostrar el accesorio seleccionado en el personaje
        // Por ejemplo:
        // accesorios[PersonajeManager.Instancia.accesorioseleccionadoIndex].SetActive(true);
        //accesorios[card.Index].SetActive(true);
    }

    private void RespuestaEventoClickCard(AccessoryCard card)
    {
        cardClickeado = card;
        ActualizarInfo(card);
    }

    private void OnEnable()
    {
        AccessoryCard.EventoClickCard += RespuestaEventoClickCard;
    }

    private void OnDisable()
    {
        AccessoryCard.EventoClickCard -= RespuestaEventoClickCard;
    }
}

