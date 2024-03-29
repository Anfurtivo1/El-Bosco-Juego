using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerGenerator : MonoBehaviour
{

    public float tiempoNormalidad = 0;

    public GameObject pDown;
    public GameObject pUp;
    public float maxSpeed;
    public float currentSpeed;
    public GameObject player;

    public float SpeedMultiplier;

    System.Random rnd = new System.Random();

    public GameObject pauseManager;

    public TextMeshProUGUI txtMasSalto;
    public TextMeshProUGUI txtMenosVelocidad;
    public TextMeshProUGUI txtRecargaRapida;
    public TextMeshProUGUI txtMenosSalto;
    public TextMeshProUGUI txtMasVelocidad;
    public TextMeshProUGUI txtRecargaLenta;

    private void Start()
    {
        GenerarPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseManager.GetComponent<PauseManager>().paused)
        {
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += SpeedMultiplier;
            }
        }
        

        


    }

    public void GenerarPowerUp()
    {
        
        GameObject powerUp = Instantiate(pUp, transform.position, transform.rotation);
        powerUp.GetComponent<PowerScript>().powerGenerator = this;
        powerUp.GetComponent<PowerScript>().player = player;
        powerUp.GetComponent<PowerScript>().tipoPower = true;
        powerUp.layer = 0;

        

    }

    public void GenerarPowerDown()
    {
        GameObject powerDown = Instantiate(pDown, transform.position, transform.rotation);
        powerDown.GetComponent<PowerScript>().powerGenerator = this;
        powerDown.GetComponent<PowerScript>().player = player;
        powerDown.GetComponent<PowerScript>().tipoPower = false;
        powerDown.layer = 0;
    }

    public void GenerateRandomWave()
    {
        float timeBetween = UnityEngine.Random.Range(10.2f, 15.2f);
        //Debug.Log("Tiempo de espera Power: "+timeBetween);
        int power = rnd.Next(1, 6);

        if (power <= 3)
        {
            Invoke("GenerarPowerUp", timeBetween);
        }

        if (power > 3)
        {
            Invoke("GenerarPowerDown", timeBetween);
        }
    }

    

}
