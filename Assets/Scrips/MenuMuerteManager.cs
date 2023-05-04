using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerteManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarMenuPrincipal()
    {
        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;

        string nivelCargar = currentSceneName;

        if (SceneManager.GetActiveScene().ToString() == "Modo infinito")
        {
            SceneManager.UnloadSceneAsync("Modo infinito");
        }

        if (SceneManager.GetActiveScene().ToString() == "Modo historia")
        {
            SceneManager.UnloadSceneAsync("Modo historia");
        }

        SceneManager.LoadScene("Menu principal");
    }

    public void RecargarNivel()
    {
        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;

        string nivelCargar = currentSceneName;

        SceneManager.UnloadSceneAsync(nivelCargar);
        SceneManager.LoadScene(nivelCargar);

    }

}
