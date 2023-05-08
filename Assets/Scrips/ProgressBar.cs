using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image progressBar;
    public GameObject finalNivel;
    public float maxDistance;
    float progreso2;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        maxDistance = finalNivel.transform.position.x;
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        progreso2 = PlayerScript.progreso.score;
        progreso2 = progreso2 / 250;
        progressBar.fillAmount = progreso2;

        if (progressBar.fillAmount == 1)
        {
            switch (scene.name)
            {
                case "Modo historia nivel 1":
                    SceneManager.LoadScene("Modo historia nivel 2");
                    break;

                case "Modo historia nivel 2":
                    SceneManager.LoadScene("Modo historia nivel 3");
                    break;

                case "Modo historia nivel 3":
                    SceneManager.LoadScene("Creditos");
                    break;

                default:
                    break;
            }
            Debug.Log("Te has pasado el nivel");
        }

        //progreso2 = 0.01f - Time.deltaTime;
        //progreso2 = progreso2 * -1;
        //progressBar.fillAmount = progreso2 + progressBar.fillAmount;
        //if (PlayerScript.progreso.score == maxDistance)
        //{
        //    Debug.Log("SE HA LLEGADO AL FINAL");
        //}
    }
}
