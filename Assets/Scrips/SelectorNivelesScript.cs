using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorNivelesScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarEscena1()
    {
        Debug.Log("Cargando nivel 1");
        SceneManager.LoadScene("Modo historia nivel 1");
    }

    public void CargarEscena2()
    {
        Debug.Log("Cargando nivel 2");
        SceneManager.LoadScene("Modo historia nivel 2");
    }

    public void CargarEscena3()
    {
        Debug.Log("Cargando nivel 3");
        SceneManager.LoadScene("Modo historia nivel 3");
    }

}
