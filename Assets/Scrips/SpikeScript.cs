using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [HideInInspector]
    public SpikeGenerator spikeGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * spikeGenerator.currentSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("nextLine"))
        {
            spikeGenerator.generateRandomWave();
        }

        if (col.gameObject.CompareTag("finishLine"))
        {
            Destroy(this.gameObject);
        }

    }

}
