using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    System.Random rnd = new System.Random();

    [HideInInspector]
    public PowerGenerator powerGenerator;
    [HideInInspector]
    public float timerMuerte = 8;
    public GameObject player;
    public bool tipoPower; //True es Up, false es Down

    [HideInInspector]
    Collider2D collider;


    [HideInInspector]
    SpriteRenderer imagen;

    // Update is called once per frame
    void Update()
    {

        timerMuerte -= Time.deltaTime;

        if (timerMuerte <= 0f)
        {
            timerMuerte = 8f;
            powerGenerator.GenerateRandomWave();
            Destroy(this.gameObject);
        }

        if (powerGenerator != null)
        {
            transform.Translate(Vector2.left * powerGenerator.currentSpeed * Time.deltaTime);

            //Length of the ray
            float laserLength = 1f;
            //Obtain the layerMask of the layer
            int layerMask = LayerMask.GetMask("Default");

            //Get the first object hit by the ray
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.left, laserLength, layerMask);

            //Get the first object hit by the ray
            RaycastHit2D hit2 = Physics2D.Raycast(this.transform.position, Vector2.up, laserLength, layerMask);

            //Get the first object hit by the ray
            RaycastHit2D hit3 = Physics2D.Raycast(this.transform.position, Vector2.down, laserLength, layerMask);

            Debug.DrawRay(transform.position, Vector2.left * laserLength, Color.grey);
            Debug.DrawRay(transform.position, Vector2.up * laserLength, Color.grey);
            Debug.DrawRay(transform.position, Vector2.down * laserLength, Color.grey);

            //if (hit.collider.tag.Equals("Player") || hit2.collider.tag.Equals("Player") || hit3.collider.tag.Equals("Player"))
            //{
            //    //hit.collider.gameObject
            //    //Hit something, print the tag of the object
            //    //Debug.Log("Hitting: " + hit.collider.tag);

            //    if (tipoPower == true)
            //    {
            //        ElegirPowerup();
            //    }

            //    if (tipoPower == false)
            //    {
            //        ElegirPowerDown();
            //    }

            //    powerGenerator.GenerateRandomWave();
            //    Destroy(this.gameObject);
            //}

            //if (hit.collider.tag.Equals("finishLine") || hit2.collider.tag.Equals("finishLine") || hit3.collider.tag.Equals("finishLine"))
            //{
            //    //hit.collider.gameObject
            //    //Hit something, print the tag of the object
            //    Debug.Log("Hitting: " + hit.collider.tag);
            //    powerGenerator.GenerateRandomWave();
            //    Destroy(this.gameObject);
            //}


        }

    }

    public void ElegirPowerup()
    {
        int power = rnd.Next(1, 2);

        power = 2;

        switch (power)
        {
            case 1:
                //Ir mas rapido

                break;
            case 2:
                //Saltar mas
                StartCoroutine(TiempoUsoPowerSalto());
                
                //StartCoroutine("PowerUp1");


                break;
            default:
                break;
        }
    }

    public void ElegirPowerDown()
    {
        int power = rnd.Next(1, 2);

        power = 2;

        switch (power)
        {
            case 1:
                //Ir mas lento

                break;
            case 2:

                //Saltar menos
                StartCoroutine(TiempoUsoPowerSaltoDown());
                //StartCoroutine("PowerDown1");


                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            if (tipoPower == true)
            {
                ElegirPowerup();
                powerGenerator.GenerateRandomWave();
                //powerGenerator.TiempoUsoPower();
                
                
            }

            if (tipoPower == false)
            {
                ElegirPowerDown();
                powerGenerator.GenerateRandomWave();
                //powerGenerator.TiempoUsoPower();
                //Destroy(this.gameObject);
            }
        }

        if (col.gameObject.CompareTag("finishLine"))
        {
            powerGenerator.GenerateRandomWave();
            Destroy(this.gameObject,5f);
        }

    }

    public IEnumerator TiempoUsoPowerSalto()
    {
        collider = this.GetComponent<Collider2D>();

        imagen = this.GetComponent<SpriteRenderer>();

        collider.enabled = false;

        imagen.enabled = false;

        player.GetComponent<PlayerScript>().potenciaSalto = player.GetComponent<PlayerScript>().potenciaSalto + 20;

        yield return new WaitForSeconds(3f);
        player.GetComponent<PlayerScript>().potenciaSalto = 15;
    }

    public IEnumerator TiempoUsoPowerSaltoDown()
    {
        collider = this.GetComponent<Collider2D>();

        imagen = this.GetComponent<SpriteRenderer>();

        collider.enabled = false;

        imagen.enabled = false;

        player.GetComponent<PlayerScript>().potenciaSalto = player.GetComponent<PlayerScript>().potenciaSalto - 20;

        yield return new WaitForSeconds(3f);
        player.GetComponent<PlayerScript>().potenciaSalto = 15;
    }

    public void PowerUp1()
    {
        
    }

    public void PowerUp2()
    {

    }

    public void PowerDown1()
    {
        
    }

    public void PowerDown2()
    {

    }


}
