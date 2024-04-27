using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesoriosEnJuego : MonoBehaviour
{
    private string nombreAccesorioLente;
    private string nombreAccesorioSombrero;
    [SerializeField] GameObject[] AccesoriosSombreros; 
    [SerializeField] GameObject[] AccesoriosLentes; 
    // Start is called before the first frame update
    void Start()
    {
        ActivarLentes();
        ActivarSombreros();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivarSombreros()
    {

        nombreAccesorioSombrero = PlayerPrefs.GetString("SombreroActivado");
        Debug.Log(nombreAccesorioSombrero);

        foreach (GameObject sombrero in AccesoriosSombreros)
        {
            for (int i = 0; i < sombrero.transform.childCount; i++) // Corrección aquí
            {
                Transform sombreroHijo = sombrero.transform.GetChild(i);
                sombreroHijo.gameObject.SetActive(false);
                if (sombreroHijo.name == nombreAccesorioSombrero)
                {
                    Debug.Log("El sombrero activado es: " + sombreroHijo.name);
                    // Aquí puedes hacer cualquier otra acción que necesites con el sombrero encontrado
                    sombreroHijo.gameObject.SetActive(true);
                }
            }
        }

    }
    private void ActivarLentes()
    {
        nombreAccesorioLente = PlayerPrefs.GetString("LenteActivado");
        Debug.Log(AccesoriosLentes);
        foreach (GameObject lente in AccesoriosLentes)
        {
            for (int i = 0; i < lente.transform.childCount; i++) // Corrección aquí
            {
                Transform lenteHijo = lente.transform.GetChild(i);
                lenteHijo.gameObject.SetActive(false);
                if (lenteHijo.name == nombreAccesorioLente)
                {
                    Debug.Log("El sombrero activado es: " + lenteHijo.name);
                    // Aquí puedes hacer cualquier otra acción que necesites con el sombrero encontrado
                    lenteHijo.gameObject.SetActive(true);
                }
            }
        }
    }
}
