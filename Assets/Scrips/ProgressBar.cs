using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image progressBar;
    public GameObject finalNivel;
    public float maxDistance;
    float progreso2;
    float progreso3;
    // Start is called before the first frame update
    void Start()
    {
        maxDistance = finalNivel.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        progreso2 = Time.deltaTime;
        progressBar.fillAmount = progreso2;

        //progreso2 = 0.01f - Time.deltaTime;
        //progreso2 = progreso2 * -1;
        //progressBar.fillAmount = progreso2 + progressBar.fillAmount;
        //if (PlayerScript.progreso.score == maxDistance)
        //{
        //    Debug.Log("SE HA LLEGADO AL FINAL");
        //}
    }
}
