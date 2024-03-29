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
    public bool paused = false;
    public Button resumen;
    public Button Mprncipal;
    public Button opciones;

    public Button salto;
    [SerializeField]
    public TextMeshProUGUI btnTextoSalto;
    public GameObject fondoSalto;

    public Button disparo;
    [SerializeField]
    public TextMeshProUGUI btnTextoDisparo;
    public GameObject fondoDisparo;

    public Button atras;
    public Button salir;

    public GameObject player;

    public Button controlesDefault;

    string textoPausado;

    public AudioSource src;
    public Slider slider;

    public GameObject fondoVolumen;

    float volumenActual;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Time.timeScale = 1f;
        volumenActual = PlayerPrefs.GetFloat("VMusica");
        if (volumenActual != 0.1f)
        {
            src.volume = volumenActual;
        }
        else
        {
            src.volume = 0.1f;
        }
        slider.value = volumenActual;
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
            //textoPausado = player.GetComponent<PlayerScript>().texto.text;
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
            //player.GetComponent<PlayerScript>().texto.text = textoPausado;
        }
    }

    public void CargarMenuPrincipal()
    {

        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;

        string nivelCargar = currentSceneName;

        if (nivelCargar == "Modo infinito")
        {
            SceneManager.UnloadSceneAsync("Modo infinito");
        }

        if (nivelCargar == "Modo historia")
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
        opciones.gameObject.SetActive(false);

        salto.gameObject.SetActive(true);
        disparo.gameObject.SetActive(true);
        controlesDefault.gameObject.SetActive(true);
        fondoSalto.gameObject.SetActive(true);
        fondoDisparo.gameObject.SetActive(true);
        fondoVolumen.gameObject.SetActive(true);
        slider.gameObject.SetActive(true);
        atras.gameObject.SetActive(true);

    }

    public void Salto()
    {
        Debug.Log("Nombre actual del boton: "+ btnTextoSalto.text);

        btnTextoSalto.text = "pulsa una tecla...";
        btnTextoSalto.fontSize = 40;

        Debug.Log("Nombre nuevo del boton: " + btnTextoSalto.text);

    }

    public void Disparo()
    {
        Debug.Log("Nombre actual del boton: " + btnTextoDisparo.text);

        btnTextoDisparo.text = "pulsa una tecla...";
        btnTextoDisparo.fontSize = 40;

        Debug.Log("Nombre nuevo del boton: " + btnTextoDisparo.text);

    }

    public void ControlesDefault()
    {
        PlayerPrefs.DeleteKey("salto");
        PlayerPrefs.DeleteKey("disparar");

        PlayerPrefs.SetString("salto","Space");
        PlayerPrefs.SetString("disparar", "D");

        player.GetComponent<PlayerScript>().botonSalto = PlayerPrefs.GetString("salto");

        player.GetComponent<PlayerScript>().botonDisparo = PlayerPrefs.GetString("disparar");

        PlayerPrefs.Save();

    }

    public void Atras()
    {
        atras.gameObject.SetActive(false);
        salto.gameObject.SetActive(false);
        disparo.gameObject.SetActive(false);
        controlesDefault.gameObject.SetActive(false);
        fondoSalto.gameObject.SetActive(false);
        fondoDisparo.gameObject.SetActive(false);
        fondoVolumen.gameObject.SetActive(false);
        slider.gameObject.SetActive(false);

        opciones.gameObject.SetActive(true);
        resumen.gameObject.SetActive(true);
        Mprncipal.gameObject.SetActive(true);
        salir.gameObject.SetActive(true);
    }

    public void Mapear()
    {
        if (btnTextoSalto.text == "pulsa una tecla...")
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keyCode))
                {
                    Debug.Log("Pulsado la tecla: "+ keyCode.ToString());
                    btnTextoSalto.text = keyCode.ToString();
                    PlayerPrefs.SetString("salto", btnTextoSalto.text);
                    Debug.Log("El antiguo mapeado era: "+ player.GetComponent<PlayerScript>().botonSalto);
                    player.GetComponent<PlayerScript>().botonSalto = PlayerPrefs.GetString("salto");
                    PlayerPrefs.Save();
                    Debug.Log("El nuevo mapeado es " + player.GetComponent<PlayerScript>().botonSalto);
                }
            }
        }

        if (btnTextoDisparo.text == "pulsa una tecla...")
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keyCode))
                {
                    Debug.Log("Pulsado la tecla: " + keyCode.ToString());
                    btnTextoDisparo.text = keyCode.ToString();
                    PlayerPrefs.SetString("disparar", btnTextoDisparo.text);
                    Debug.Log("El antiguo mapeado era: " + player.GetComponent<PlayerScript>().botonDisparo);
                    player.GetComponent<PlayerScript>().botonDisparo = PlayerPrefs.GetString("disparar");
                    PlayerPrefs.Save();
                    Debug.Log("El nuevo mapeado es " + player.GetComponent<PlayerScript>().botonDisparo);
                }
            }
        }

    }

    public void AjustarVolumen()
    {
        src.volume = slider.value;
        volumenActual = slider.value;

        PlayerPrefs.SetFloat("VMusica",slider.value);
        PlayerPrefs.Save();
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