using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour
{
    bool paused = false;
    public Button resumen;
    public Button Mprncipal;
    public Button salir;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Time.timeScale = 1f;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void pause()
    {
        if (!paused)
        {
            Time.timeScale = 0f;
            paused = true;
            resumen.gameObject.SetActive(true);
            Mprncipal.gameObject.SetActive(true);
            salir.gameObject.SetActive(true);
        }
    }

    public void resume()
    {
        if (paused)
        {
            Time.timeScale = 1f;
            paused = false;
            resumen.gameObject.SetActive(false);
            Mprncipal.gameObject.SetActive(false);
            salir.gameObject.SetActive(false);
        }
    }

    public void CargarMenuPrincipal()
    {
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

    public void Salir()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif
    }

}