using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryManager : Singleton<AccessoryManager>
{
    public int AccesorioSeleccionadoIndex => PlayerPrefs.GetInt(ULTIMO_ACCESORIO_SELECCIONADO_KEY, 0);
    private string ULTIMO_ACCESORIO_SELECCIONADO_KEY = "ACCESORIO_SELECCIONADO";

    public void SeleccionarAccesorio(AccessoryCard card)
    {
        PlayerPrefs.SetInt(ULTIMO_ACCESORIO_SELECCIONADO_KEY, card.Index);
    }
}

