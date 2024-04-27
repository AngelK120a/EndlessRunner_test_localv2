using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamicCanvasShop : MonoBehaviour
{
    public GameObject[] listaMenus;
    public GameObject listasPersonajes;
    private string paginaActual;

    private void Start()
    {
        paginaActualPersonaje();
    }

    //Funciones para cambiar pagina Inicio
    public void cambiarPagina(int accion)
    {
        //En onClick del boton en donde se llama la funcion
        //accion = 1 siguiente pagina
        //accion = 2 pagina anterior
        Debug.Log(accion);
        if (accion == 1) 
        {
            siguientePagina();
        }else if (accion == 2)
        {
            anteriorPagina();
        }
    }

    private void menuActual()
    {
        
    }
    
    private void paginaActualPersonaje()
    {
        try
        {
            if (paginaActual != null || paginaActual == "")
            {
                if (listasPersonajes != null)
                {
                    for (int i = 0; i < listasPersonajes.transform.childCount; i++)
                    {
                        // Obtener el hijo en la posición i
                        Transform hijo = listasPersonajes.transform.GetChild(i);

                        // Validar si el hijo está activo
                        if (hijo.gameObject.activeSelf)
                        {

                            paginaActual = hijo.name;
                            break;
                        }
                        else
                        {
                            // El hijo está inactivo, realizar otra acción si es necesario
                        }
                    }
                }
            }
            Debug.Log("Pagina actual: " + paginaActual);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error en PaginaActualPersonaje" + e.Message);
            throw;
        }
        
    }
    private void siguientePagina()
    {
        try
        {
            
            if (listasPersonajes != null)
            {
                for (int i = 0; i < listasPersonajes.transform.childCount; i++)
                {
                    if (i == listasPersonajes.transform.childCount)
                    {
                        Debug.Log("No hay más paginas siguientes");
                        break;
                    }
                    // Obtener el hijo en la posición i
                    Transform hijo = listasPersonajes.transform.GetChild(i);

                    // Validar si el hijo está activo
                    if (!hijo.gameObject.activeSelf)
                    {
                        // Hacer algo con el hijo activo
                        // Por ejemplo, desactivarlo

                        if (!(i < 0))
                        {
                            Transform hijoADesactivar = listasPersonajes.transform.GetChild(i - 1);
                            hijoADesactivar.gameObject.SetActive(false);
                            Debug.Log("Error, " + listasPersonajes.transform.GetChild(i - 1));

                        }
                        paginaActual = hijo.name;
                        hijo.gameObject.SetActive(true);
                        Debug.Log("Se activo: " + hijo.name);
                        break;
                    }
                    else
                    {
                        // El hijo está inactivo, realizar otra acción si es necesario
                    }
                }
            }
            Debug.Log("Pagina actual: " + paginaActual);

        }
        catch (Exception ex)
        {
            // Bloque de código que maneja la excepción
            // Se ejecutará si ocurre una excepción dentro del bloque 'try'
            Debug.LogError("Error en siguientePagina " + ex.Message);
        }
        finally
        {
            // Bloque de código opcional que siempre se ejecuta, independientemente de si se lanzó una excepción o no
            // Se utiliza comúnmente para liberar recursos, como cerrar archivos o conexiones de red
            Debug.Log("Finalizando el proceso");
        }
        

    }

    private void anteriorPagina()
    {
        

        try
        {
            // Bloque de código donde puede ocurrir una excepción
            // Por ejemplo, acceso a una operación que podría arrojar una excepción
            if (listasPersonajes != null)
            {
                for (int i = 0; i < listasPersonajes.transform.childCount; i--)
                {
                    if (i == listasPersonajes.transform.childCount)
                    {
                        Debug.Log("No hay más paginas siguientes");
                        break;
                    }
                    // Obtener el hijo en la posición i
                    Transform hijo = listasPersonajes.transform.GetChild(i);

                    // Validar si el hijo está activo
                    if (!hijo.gameObject.activeSelf)
                    {
                        // Hacer algo con el hijo activo
                        // Por ejemplo, desactivarlo
                        hijo.gameObject.SetActive(true);
                        paginaActual = hijo.name;
                        if (!(i < 0))
                        {
                            Transform hijoADesactivar = listasPersonajes.transform.GetChild(i + 1);
                            hijoADesactivar.gameObject.SetActive(false);
                            Debug.Log("Se desactivo: " + hijoADesactivar.name);

                        }

                        Debug.Log("Se activo: " + hijo.name);
                        break;
                    }
                    else
                    {
                        // El hijo está inactivo, realizar otra acción si es necesario
                    }
                }
            }
            Debug.Log("Pagina actual: " + paginaActual);

        }
        catch (Exception ex)
        {
            // Bloque de código que maneja la excepción
            // Se ejecutará si ocurre una excepción dentro del bloque 'try'
            Debug.LogError("Error en anterior pagina: " + ex.Message);
        }


    }
    //***Funciones para cambiar pagina Fin***
    
    //***Funciones para cambiar Menus Inicio***
    public void cambioMenu(int menu)
    {
        try
        {
            
            switch (menu)
            {
                /*
                 Referencias en object "Menu"
                TiendaPersonaje = 0
                ListaAccesorios = 1
                ListaAnteojos = 2
                ListaBigote = 3
                 */
                case 0:
                    if (listaMenus[menu].gameObject.activeSelf)
                    {
                        Debug.Log("Menu Activado: "+listaMenus[menu].name);
                        return;
                    }

                    activarMenuSeleccionado(menu);
                    break;
                case 1:
                    if (listaMenus[menu].gameObject.activeSelf)
                    {
                        Debug.Log("Menu Activado: "+listaMenus[menu].name);
                        return;
                    }
                    activarMenuSeleccionado(menu);
                    break;
                case 2:
                    if (listaMenus[menu].gameObject.activeSelf)
                    {
                        Debug.Log("Menu Activado: "+listaMenus[menu].name);
                        return;
                    }
                    activarMenuSeleccionado(menu);
                    break;
                case 3:
                    if (listaMenus[menu].gameObject.activeSelf)
                    {
                        Debug.Log("Menu Activado: "+listaMenus[menu].name);
                        return;
                    }
                    activarMenuSeleccionado(menu);
                    break;
                
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void activarMenuSeleccionado(int indiceMenu)
    {
        try
        {
            Debug.Log("Menu: " + indiceMenu);
            for (int i = 0; i < listaMenus.Length; i++)
            {
                if (listaMenus[i].gameObject.activeSelf)
                {
                    listaMenus[i].SetActive(false);
                    break;
                }
            }
            listaMenus[indiceMenu].gameObject.SetActive(true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    //***Funciones para cambiar Menus Fin***

}
