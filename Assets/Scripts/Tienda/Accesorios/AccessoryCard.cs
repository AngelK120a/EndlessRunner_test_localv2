using System;
using UnityEngine;

public class AccessoryCard : MonoBehaviour
{
    public static event Action<AccessoryCard> EventoClickCard;

    [SerializeField] private bool libre;
    [SerializeField] private int index;
    [SerializeField] private int costo;

    public int Costo => costo;
    public int Index => index;
    public bool Comprado => PlayerPrefs.GetInt(ACCESSORY_COMPRADO_KEY + index) == 1;
    public bool Seleccionado => PlayerPrefs.GetInt(ACCESSORY_SELECCIONADO_KEY + index) == 1;

    private string ACCESSORY_COMPRADO_KEY = "COMPRADO_ACCESORIO";
    private string ACCESSORY_SELECCIONADO_KEY = "SELECCIONADO_ACCESORIO";
    private string ACCESSORY_LIBRE_KEY = "LIBRE_ACCESORIO";

    private void Awake()
    {
        if (libre)
        {
            if (PlayerPrefs.GetInt(ACCESSORY_LIBRE_KEY + index) == 0)
            {
                ComprarAccesorio();
                SeleccionarAccesorio();
                PlayerPrefs.SetInt(ACCESSORY_LIBRE_KEY + index, 1);
            }
        }
    }

    public void ClickCard()
    {
        SoundManager.Instancia.ReproducirSonidoFX(SoundManager.Instancia.uiClip);
        EventoClickCard?.Invoke(this);
    }

    public void ComprarAccesorio()
    {
        PlayerPrefs.SetInt(ACCESSORY_COMPRADO_KEY + index, 1);
    }

    public void SeleccionarAccesorio()
    {
        PlayerPrefs.SetInt(ACCESSORY_SELECCIONADO_KEY + index, 1);
    }

    public void DeseleccionarAccesorio()
    {
        PlayerPrefs.SetInt(ACCESSORY_SELECCIONADO_KEY + index, 0);
    }
}

