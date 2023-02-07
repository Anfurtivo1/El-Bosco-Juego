using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;
    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = minSpeed;
        generateSpike();
    }

    public void generateSpike()
    {
        GameObject newSpike = Instantiate(spike, transform.position, transform.rotation);
        newSpike.GetComponent<SpikeScript>().spikeGenerator = this;
    }

    public void generateRandomWave()
    {
        float timeBetween = Random.Range(0.01f,1.2f);
        Invoke("generateSpike", timeBetween);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
    }

    

}