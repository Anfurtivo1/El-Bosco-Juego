using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void CargarModoInfinito()
    {
        SceneManager.LoadScene("Modo infinito");
    }

    public void CargarTutorial()
    {
        SceneManager.LoadScene("Tutorial");

    }

    public void CargarModoHistoria()
    {
        SceneManager.LoadScene("Selector Nivel");
        
    }

}
