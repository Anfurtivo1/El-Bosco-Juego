using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public int tipo;
    [HideInInspector]
    public EnemigoManager enemigoManager;
    public GameObject enemigo;
    public Rigidbody2D cuerpo;

    // Update is called once per frame
    void Update()
    {
        switch (tipo)
        {
            case 1:
                Enemigo1();
                break;
            case 2:
                Enemigo2();
                break;
            case 3:
                Enemigo3();
                break;
            case 4:
                Enemigo4();
                break;
            case 5:
                Enemigo5();
                break;
            default:
                break;
        }


    }

    public void Enemigo1()
    {

    }

    public void Enemigo2()
    {

    }

    public void Enemigo3()
    {
        if (enemigoManager != null)
        {
            transform.Translate(Vector2.left * enemigoManager.currentSpeed * Time.deltaTime);
        }


        //Length of the ray
        float laserLength = 10f;
        //Obtain the layerMask of the layer
        int layerMask = LayerMask.GetMask("Default");

        //Get the first object hit by the ray
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.left, laserLength, layerMask);

        //If the collider of the object hit is not NUll
        if (hit.collider != null)
        {
            //Hit something, print the tag of the object
            //Debug.Log("detected: " + hit.collider.tag);
            //this.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
            //spike.GetComponent<Rigidbody2D>().AddForce(Vector2.up*10000000);

            if (hit.collider.CompareTag("proyectil"))
            {
                //hit.collider.gameObject
                //Hit something, print the tag of the object
                //Debug.Log("Hitting: " + hit.collider.tag);
                //proyectilGenerator.generateWave();
                Destroy(this.gameObject);
            }

        }

        //if (hit.collider.tag.Equals("Enemigo 5"))
        //{
        //    //hit.collider.gameObject
        //    //Hit something, print the tag of the object
        //    Debug.Log("Hitting: " + hit.collider.tag);
        //}

        //Method to draw the ray in scene for debug purpose
        Debug.DrawRay(transform.position, Vector2.left * laserLength, Color.blue);
    }

    public void Enemigo4()
    {

    }

    public void Enemigo5()
    {
        transform.Translate(Vector2.left * enemigoManager.currentSpeed * Time.deltaTime);

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
            //Debug.Log("detected: " + hit.collider.tag);
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 15, ForceMode2D.Impulse);

            if (hit.collider.CompareTag("proyectil"))
            {
                //hit.collider.gameObject
                //Hit something, print the tag of the object
                //Debug.Log("Hitting: " + hit.collider.tag);
                //proyectilGenerator.generateWave();
                Destroy(this.gameObject);
            }

        }

        //if (hit.collider.tag.Equals("Enemigo 5"))
        //{
        //    //hit.collider.gameObject
        //    //Hit something, print the tag of the object
        //    Debug.Log("Hitting: " + hit.collider.tag);
        //}

        //Method to draw the ray in scene for debug purpose
        Debug.DrawRay(transform.position, Vector2.left * laserLength, Color.red);

        Destroy(this.gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("nextLine"))
        {
            enemigoManager.generateRandomWave();
        }

        if (col.gameObject.CompareTag("finishLine"))
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.CompareTag("proyectil"))
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("roof"))
        {
            Destroy(this.gameObject);
        }

    }
}
