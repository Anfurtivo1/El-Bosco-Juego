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

        //Length of the ray
        float laserLength = 5f;
        //Obtain the layerMask of the layer
        int layerMask = LayerMask.GetMask("Default");

        //Get the first object hit by the ray
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.left, laserLength, layerMask);

        //If the collider of the object hit is not NUll
        if (hit.collider != null)
        {
            //Hit something, print the tag of the object
            Debug.Log("Hitting: " + hit.collider.tag);
        }

        //if (hit.collider.tag.Equals("Enemigo 5"))
        //{
        //    //hit.collider.gameObject
        //    //Hit something, print the tag of the object
        //    Debug.Log("Hitting: " + hit.collider.tag);
        //}

        //Method to draw the ray in scene for debug purpose
        Debug.DrawRay(transform.position, Vector2.left * laserLength, Color.red);


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
