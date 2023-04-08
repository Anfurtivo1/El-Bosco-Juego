using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [HideInInspector]
    public BulletGenerator bulletGenerator;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        //Length of the ray
        float laserLength = 1f;
        //Obtain the layerMask of the layer
        int layerMask = LayerMask.GetMask("Default");

        //Get the first object hit by the ray
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.up, laserLength, layerMask);

        transform.Translate(Vector2.up * bulletGenerator.currentSpeed * Time.deltaTime);

        if (bulletGenerator != null)
        {

            ////If the collider of the object hit is not NUll
            //if (hit.collider != null)
            //{
            //    //Hit something, print the tag of the object
            //    //Debug.Log("detected: " + hit.collider.tag);
            //    //this.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
            //    //spike.GetComponent<Rigidbody2D>().AddForce(Vector2.up*10000000);
            //}
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Roof"))
                {
                    //hit.collider.gameObject
                    //Hit something, print the tag of the object
                    //Debug.Log("Hitting: " + hit.collider.tag);
                    bulletGenerator.generateRandomWave();
                    Destroy(this.gameObject);
                }
            }

            if (bulletGenerator == null)
            {
                Destroy(this.gameObject, 4f);
            }

            //Method to draw the ray in scene for debug purpose
            Debug.DrawRay(transform.position, Vector2.up * laserLength, Color.green);
        }

        if (bulletGenerator == null)
        {
            Destroy(this.gameObject, 4f);
        }

    }

    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.CompareTag("finishLine"))
    //    {
    //        bulletGenerator.generateRandomWave();
    //    }

    //    if (col.gameObject.CompareTag("finishLine"))
    //    {
    //        Destroy(this.gameObject);
    //    }

    //}
}
