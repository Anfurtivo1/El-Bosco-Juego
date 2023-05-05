using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    System.Random rnd = new System.Random();

    [HideInInspector]
    public PowerGenerator powerGenerator;
    public float timerMuerte;
    public GameObject player;
    public bool tipoPower; //True es Up, false es Down

    [HideInInspector]
    Collider2D collider;


    [HideInInspector]
    SpriteRenderer imagen;

    bool PDownPillado = false;

    float PDownCD = 0;

    public AudioSource src;
    public AudioClip powerUp;
    public AudioClip powerDown;

    // Update is called once per frame
    void Update()
    {

        timerMuerte -= Time.deltaTime;
        Debug.Log("Timer muerte de Power " + tipoPower+ " : "+timerMuerte);

        if (timerMuerte <= 0f)
        {
            timerMuerte = 10f;
            powerGenerator.GenerateRandomWave();
            Destroy(this.gameObject);
        }

        if (PDownPillado)
        {
            PDownCD += Time.deltaTime;
            Debug.Log("CD de Power: " + PDownCD);
            if (PDownCD >= 3)
            {
                Debug.Log("Ultimo CD de Power: " + PDownCD);
                PDownPillado = false;
                PDownCD = 0;
                player.GetComponent<PlayerScript>().potenciaSalto = 20;
            }
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


        }

    }

    public void ElegirPowerup()
    {
        int power = rnd.Next(1, 3);

        switch (power)
        {
            case 1:
                //Ir mas lento
                StartCoroutine(TiempoUsoRalentizar());
                break;
            case 2:
                //Saltar mas
                StartCoroutine(TiempoUsoPowerSalto());
                
                //StartCoroutine("PowerUp1");


                break;
            default:
                //StartCoroutine(TiempoUsoPowerSalto());
                break;
        }
    }

    public void ElegirPowerDown()
    {
        int power = rnd.Next(1, 3);

        switch (power)
        {
            case 1:
                //Ir mas rapido
                StartCoroutine(TiempoUsoRalentizarDown());
                break;
            case 2:

                //Saltar menos
                TiempoUsoPowerSaltoDown();
                //StartCoroutine("PowerDown1");


                break;
            default:
                //StartCoroutine(TiempoUsoPowerSalto());
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
            }

            if (tipoPower == false)
            {
                ElegirPowerDown();
                powerGenerator.GenerateRandomWave();
            }
        }

    }

    //mas salto
    public IEnumerator TiempoUsoPowerSalto()
    {
        collider = this.GetComponent<Collider2D>();

        imagen = this.GetComponent<SpriteRenderer>();

        collider.enabled = false;

        imagen.enabled = false;

        player.GetComponent<PlayerScript>().potenciaSalto = player.GetComponent<PlayerScript>().potenciaSalto + 20;

        src.clip = powerUp;
        src.Play();

        yield return new WaitForSeconds(3f);
        player.GetComponent<PlayerScript>().potenciaSalto = 15;
        powerGenerator.GenerateRandomWave();
    }
    //mas lento
    public IEnumerator TiempoUsoRalentizar()
    {
        collider = this.GetComponent<Collider2D>();

        imagen = this.GetComponent<SpriteRenderer>();

        collider.enabled = false;

        imagen.enabled = false;

        Time.timeScale = 0.5f;

        src.clip = powerUp;
        src.Play();

        yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
        powerGenerator.GenerateRandomWave();
    }
    //menos salto
    public IEnumerator TiempoUsoPowerSaltoDown()
    {
        collider = this.GetComponent<Collider2D>();

        imagen = this.GetComponent<SpriteRenderer>();

        collider.enabled = false;

        imagen.enabled = false;

        player.GetComponent<PlayerScript>().potenciaSalto = player.GetComponent<PlayerScript>().potenciaSalto -5;

        src.clip = powerDown;
        src.Play();

        yield return new WaitForSeconds(3f);
        player.GetComponent<PlayerScript>().potenciaSalto = 15;
        powerGenerator.GenerateRandomWave();

    }
    //mas rapido
    public IEnumerator TiempoUsoRalentizarDown()
    {
        collider = this.GetComponent<Collider2D>();

        imagen = this.GetComponent<SpriteRenderer>();

        collider.enabled = false;

        imagen.enabled = false;

        Time.timeScale = 1.5f;

        src.clip = powerDown;
        src.Play();

        yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
        powerGenerator.GenerateRandomWave();
    }


}
