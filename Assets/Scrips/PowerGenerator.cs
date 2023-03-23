using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGenerator : MonoBehaviour
{
    public GameObject pDown;
    public GameObject pUp;
    public float maxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    System.Random rnd = new System.Random();

    private void Start()
    {
        GenerarPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }

    }

    public void GenerarPowerUp()
    {
        GameObject powerUp = Instantiate(pUp, transform.position, transform.rotation);
        powerUp.GetComponent<PowerScript>().powerGenerator = this;
        powerUp.layer = 3;
    }

    public void GenerarPowerDown()
    {
        GameObject powerDown = Instantiate(pDown, transform.position, transform.rotation);
        powerDown.GetComponent<PowerScript>().powerGenerator = this;
        powerDown.layer = 3;
    }

    public void GenerateRandomWave()
    {
        float timeBetween = UnityEngine.Random.Range(5.2f, 8.2f);
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
