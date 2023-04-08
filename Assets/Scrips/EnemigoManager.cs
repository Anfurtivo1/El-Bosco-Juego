using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoManager : MonoBehaviour
{

    public GameObject enemigo;
    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = minSpeed;
        generateEnemigo();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }

    }

    public void generateEnemigo()
    {
        GameObject newEnemigo = Instantiate(enemigo, transform.position, transform.rotation);
        newEnemigo.GetComponent<Enemigos>().enemigoManager = this;
        newEnemigo.GetComponent<Enemigos>().enemigo = newEnemigo;
        newEnemigo.layer = 3;
    }

    public void generateRandomWave()
    {
        float timeBetween = Random.Range(0.01f, 4.2f);
        Invoke("generateEnemigo", timeBetween);
    }

}
