using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamicCanvaMainMenu : MonoBehaviour
{
    public GameObject ObjCanvaDesactive;//Referencia a que canvas desactivar
    public GameObject ObjCanvasActive;//Referencia a que canvas activas
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void desactivarCanva() {
        // Verificar si el objeto no es nulo antes de desactivarlo
        if (ObjCanvaDesactive != null)
        {
            // Desactivar el objeto
            ObjCanvaDesactive.SetActive(false);
        }
        else
        {
            Debug.LogWarning("El objeto a desactivar es nulo.");
        }
    }

    public void activarCanvas() {
        // Verificar si el objeto no es nulo antes de desactivarlo
        if (ObjCanvasActive != null)
        {
            // Desactivar el objeto
            ObjCanvasActive.SetActive(true);
        }
        else
        {
            Debug.LogWarning("El objeto a activar es nulo.");
        }
    }
}
