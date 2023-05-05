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

    [HideInInspector]
    Collider2D collider;


    [HideInInspector]
    SpriteRenderer imagen;

    public BulletGenerator bulletGenerator;

    public AudioSource src;

    public AudioClip morir;

    

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

    public void Enemigo2()
    {
        
        if (enemigoManager != null)
        {
            transform.Translate(Vector2.left * enemigoManager.currentSpeed * Time.deltaTime);
        }


        //Length of the ray
        float laserLength = 1f;
        //Obtain the layerMask of the layer
        int layerMask = LayerMask.GetMask("Default");

        //Get the first object hit by the ray
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.left, laserLength, layerMask);

        //If the collider of the object hit is not NUll
        if (hit.collider != null)
        {

            if (hit.collider.CompareTag("finishLine"))
            {
                enemigoManager.generateRandomWaveEnemigo2();
                Destroy(this.gameObject);
            }

            if (hit.collider.CompareTag("proyectil"))
            {
                Destroy(this.gameObject);
                Destroy(hit.collider.gameObject);
            }

            //if (hit.collider.CompareTag("Player"))
            //{
            //    enemigoManager.generateRandomWave();
            //    Destroy(this.gameObject);
            //}

        }

        //Method to draw the ray in scene for debug purpose
        Debug.DrawRay(transform.position, Vector2.left * laserLength, Color.blue);
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

            if (hit.collider.CompareTag("proyectil"))
            {
                //hit.collider.gameObject
                //Hit something, print the tag of the object
                //Debug.Log("Hitting: " + hit.collider.tag);
                //proyectilGenerator.generateWave();
                Destroy(this.gameObject);
            }

            if (hit.collider.CompareTag("Player"))
            {
                    enemigo.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    enemigo.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                    this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100, ForceMode2D.Force);
                
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

        //Destroy(this.gameObject, 5f);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collider.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Spike"))
        {
            //Physics2D.IgnoreLayerCollision(col.GetComponent<Collider2D>(), this.GetComponent<Collider2D>(),true);
        }

        if (col.gameObject.CompareTag("Suelo"))
        {
            //Physics2D.IgnoreLayerCollision(col.GetComponent<Collider2D>(), this.GetComponent<Collider2D>(),true);
            enemigo.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (col.gameObject.CompareTag("nextLine"))
        {
            if (tipo == 2)
            {
                enemigoManager.generateRandomWaveEnemigo2();
            }

            else
            {
                enemigoManager.generateRandomWave();
            }
        }

        if (col.gameObject.CompareTag("finishLine"))
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.CompareTag("proyectil"))
        {
            //src.clip = morir;
            //src.Play();

            //Destroy(this.gameObject,0.1f);
            //Destroy(col.gameObject);
            StartCoroutine(Morirse(col));
        }

        if (col.gameObject.CompareTag("roof"))
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.CompareTag("Player"))
        {
            //collider = this.gameObject.GetComponent<Collider2D>();

            //imagen = this.gameObject.GetComponent<SpriteRenderer>();

            //collider.enabled = false;

            //imagen.enabled = false;

            Destroy(this.gameObject);
            if (tipo == 2)
            {
                enemigoManager.generateRandomWaveEnemigo2();
            }

            else
            {
                enemigoManager.generateRandomWave();
            }

            
        }

    }

    public IEnumerator Morirse(Collider2D col)
    {
        collider = this.GetComponent<Collider2D>();

        imagen = this.GetComponent<SpriteRenderer>();

        collider.enabled = false;

        imagen.enabled = false;

        src.clip = morir;
        src.Play();

        if (tipo == 3)
        {
            bulletGenerator.GetComponent<BulletGenerator>().pDisparo = false;
        }

        Destroy(col.gameObject);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);

    }

}
