using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour
{
    bool paused = false;
    public Button resumen;
    public Button Mprncipal;
    public Button opciones;

    public Button salto;
    [SerializeField]
    public TextMeshProUGUI btnTexto;

    public Button atras;
    public Button salir;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Mapear();
    }

    public void pause()
    {
        if (!paused)
        {
            Time.timeScale = 0f;
            paused = true;
            resumen.gameObject.SetActive(true);
            Mprncipal.gameObject.SetActive(true);
            opciones.gameObject.SetActive(true);
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
            opciones.gameObject.SetActive(false);
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

    public void Opciones()
    {
        resumen.gameObject.SetActive(false);
        Mprncipal.gameObject.SetActive(false);
        salir.gameObject.SetActive(false);

        opciones.gameObject.SetActive(true);
        salto.gameObject.SetActive(true);
        atras.gameObject.SetActive(true);

    }

    public void Salto()
    {
        Debug.Log("Nombre actual del boton: "+ btnTexto.text);

        btnTexto.text = "pulsa una tecla...";

        Debug.Log("Nombre nuevo del boton: " + btnTexto.text);

    }

    public void Atras()
    {
        atras.gameObject.SetActive(false);
        salto.gameObject.SetActive(false);

        resumen.gameObject.SetActive(true);
        Mprncipal.gameObject.SetActive(true);
        salir.gameObject.SetActive(true);
    }

    public void Mapear()
    {
        if (btnTexto.text == "pulsa una tecla...")
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keyCode))
                {
                    Debug.Log("Pulsado la tecla: "+ keyCode.ToString());
                    btnTexto.text = keyCode.ToString();
                    PlayerPrefs.SetString("salto", btnTexto.text);
                    Debug.Log("El antiguo mapeado era: "+ player.GetComponent<PlayerScript>().botonSalto);
                    player.GetComponent<PlayerScript>().botonSalto = PlayerPrefs.GetString("salto");
                    PlayerPrefs.Save();
                    Debug.Log("El nuevo mapeado es " + player.GetComponent<PlayerScript>().botonSalto);
                }
            }
        }
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