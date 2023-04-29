using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{//Aquí empieza el PlayerScript
    public static PlayerScript progreso;
    public Rigidbody2D jugador;
    bool tocandoTierra = true;
    int cuentaSaltos = 0;
    public bool saltoDoble;
    public int potenciaSalto;
    public float score;
    bool vivo = true;
    public Text texto;
    public int vidas;
    private bool isInvincible = false;
    [SerializeField]
    private float invincibilityDurationSeconds;
    [SerializeField]
    private float delayBetweenInvincibilityFlashes;
    [SerializeField]
    private GameObject model;
    public int damage;
    public Text textoVidas;
    RaycastHit hit;
    public GameObject proyectil;

    [SerializeField]
    public ProyectilGenerator proyectilGenerator;

    public string botonSalto;
    public string botonDisparo;
    public bool cdDisparo;

    public float coolDownDisparo;

    public Image progressBar;
    float progreso2;

    private IEnumerator BecomeTemporarilyInvincible()
    {
        //Debug.Log("Player turned invincible!");
        isInvincible = true;

        // Flash on and off for roughly invincibilityDurationSeconds seconds
        for (float i = 0; i < invincibilityDurationSeconds; i += delayBetweenInvincibilityFlashes)
        {
            // Alternate between 0 and 1 scale to simulate flashing
            if (model.transform.localScale == Vector3.one)
            {
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ScaleModelTo(Vector3.one);
            }
            yield return new WaitForSeconds(delayBetweenInvincibilityFlashes);
        }

        Debug.Log("Player is no longer invincible!");
        ScaleModelTo(Vector3.one);
        isInvincible = false;

    }

    private void Awake()
    {
        progreso = this;
    }

    private void Start()
    {

        

        //PlayerPrefs.DeleteKey("salto");
        PlayerPrefs.Save();
        if (PlayerPrefs.GetString("salto") == "")
        {
            PlayerPrefs.SetString("salto", KeyCode.Space.ToString());
            PlayerPrefs.Save();
            
        }

        textoVidas.text = "" + vidas;
        botonSalto = PlayerPrefs.GetString("salto");
        //Debug.Log("El boton para saltar es: " + PlayerPrefs.GetString("salto"));

    }
    // Update is called once per frame
    void Update()
    {
        
        if (vidas >0)
        {
            score += Time.deltaTime * 4;
            
            texto.text = "Score : " + score.ToString("F");

            //Disparando();

            ////Length of the ray
            //float laserLength = 5f;
            ////Obtain the layerMask of the layer
            //int layerMask = LayerMask.GetMask("Enemigo");

            ////Get the first object hit by the ray
            //RaycastHit2D hit = Physics2D.Raycast(jugador.transform.position, Vector2.left, laserLength, layerMask);

            ////If the collider of the object hit is not NUll
            //if (hit.collider != null)
            //{
            //    //Hit something, print the tag of the object
            //    Debug.Log("Hitting: " + hit.collider.tag);
            //}

            ////if (hit.collider.tag.Equals("Enemigo 5"))
            ////{
            ////    //hit.collider.gameObject
            ////    //Hit something, print the tag of the object
            ////    Debug.Log("Hitting: " + hit.collider.tag);
            ////}

            ////Method to draw the ray in scene for debug purpose
            //Debug.DrawRay(transform.position, Vector2.left * laserLength, Color.red);




        }

        if (vidas == 0)
        {
            Time.timeScale = 0;
        }

        //comprobarBloque();
        
    }

    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent(botonSalto)))
        {
            cuentaSaltos++;
            if (tocandoTierra && saltoDoble)
            {
                if (cuentaSaltos == 3)
                {
                    tocandoTierra = false;
                }

            }

            if (cuentaSaltos < 3 && tocandoTierra)
            {
                //jugador.drag = 4;
                //tocandoTierra = true;
                jugador.AddForce(Vector2.up * potenciaSalto, ForceMode2D.Impulse);
                //jugador.AddForce(Vector2.up * potenciaSalto);
            }

            if (!saltoDoble)
            {
                tocandoTierra = false;
            }
        }

        Disparar();

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Suelo")
        {
            tocandoTierra = true;
            cuentaSaltos = 0;
            //jugador.drag = 20;
        }

        if (col.contactCount != 0)
        {
            foreach (var objeto in col.contacts)
            {
                if (objeto.collider.gameObject.tag == "Spike")
                {
                    Destroy(objeto.collider.gameObject);
                    perderVida(damage);

                }

                if (objeto.collider.gameObject.tag == "Bullet")
                {
                    Destroy(objeto.collider.gameObject);
                    perderVida(damage);

                }

            }
        }

    }

    private void ScaleModelTo(Vector3 scale)
    {
        model.transform.localScale = scale;
    }

    private void perderVida(int cantidad)
    {
        if (isInvincible) return;
        //Debug.Log("*Colision�: Vida fuera");
        vidas = vidas - cantidad;
        textoVidas.text = ""+vidas;

        if (vidas < 0)
        {
            vidas = 0;
            textoVidas.text = "" + vidas;
        }

        if (vidas <= 0)
        {
            Time.timeScale = 0;

        }

        //StartCoroutine(BecomeTemporarilyInvincible());
    }

    private void Disparar()
    {
        if (PlayerPrefs.GetString("disparar") == "")
        {
            PlayerPrefs.DeleteKey("disparar");
            PlayerPrefs.Save();

            PlayerPrefs.SetString("disparar", KeyCode.D.ToString());
            PlayerPrefs.Save();
        }

        //PlayerPrefs.DeleteKey("disparar");
        //PlayerPrefs.Save();

        //PlayerPrefs.SetString("disparar", KeyCode.D.ToString());
        //PlayerPrefs.Save();

        botonDisparo = PlayerPrefs.GetString("disparar");
        if (Time.timeScale == 1f)
        {
            progressBar.fillAmount += 1f / coolDownDisparo * Time.deltaTime;
            if (Event.current.Equals(Event.KeyboardEvent(botonDisparo)))
            {
                cdDisparo = true;
                
                if (cdDisparo)
                {
                    if (progressBar.fillAmount >=1)
                    {
                        cdDisparo = false;
                        progressBar.fillAmount = 0;
                        proyectilGenerator.generateProyectil();
                    }
                    //StartCoroutine(BarraDisparo());


                }
            }
        }
        

        //Debug.Log("El boton para disparar es: " + PlayerPrefs.GetString("disparar"));

    }

    private void Disparando()
    {

        if (PlayerPrefs.GetString("disparar") == "")
        {
            PlayerPrefs.DeleteKey("disparar");
            PlayerPrefs.Save();

            PlayerPrefs.SetString("disparar", KeyCode.D.ToString());
            PlayerPrefs.Save();
        }
        progressBar.fillAmount += 1 / coolDownDisparo * Time.deltaTime;

        if (Input.GetKey(KeyCode.F))
        {
            cdDisparo = true;

            if (cdDisparo)
            {
                if (progressBar.fillAmount >= 1)
                {
                    cdDisparo = false;
                    progressBar.fillAmount = 0;
                    proyectilGenerator.generateProyectil();
                }
                //StartCoroutine(BarraDisparo());


            }
        }
    }

    //private IEnumerator CoolDownDisparo()
    //{
        

    //    yield return new WaitForSeconds(1.5f);
    //    cdDisparo = true;
    //}

    //private IEnumerator BarraDisparo()
    //{

    //    yield return new WaitForSeconds(1.5f);

    //    progreso2 = Time.deltaTime;
    //    progreso2 = progreso2 / 2;
    //    progressBar.fillAmount = progreso2 + progressBar.fillAmount;
        
    //}

    //private void comprobarBloque()
    //{
    //    //if (spikeVar != null)
    //    //{
    //    var Jugador= this.GetComponent<Rigidbody2D>();
    //    //Length of the ray
    //    float laserLength = 1;
    //    float x = (float)(Jugador.position.x+0.5);
    //    float x2 = (float)(Jugador.position.x);
    //    float y = (float)(-Jugador.position.y +0.5);
    //    Vector2 vectorJugador = new Vector2(x, Jugador.position.y);
    //    Vector2 vectorJugador2 = new Vector2(x2, -y);
    //    //Get the first object hit by the ray
    //    RaycastHit2D hit = Physics2D.Raycast(vectorJugador, Vector2.left, laserLength);
    //    RaycastHit2D hit2 = Physics2D.Raycast(vectorJugador2, -Vector3.up , laserLength);

    //    //If the collider of the object hit is not NUll
    //    if (hit.collider != null)
    //    {
    //        //Hit something, print the tag of the object
    //        //Debug.Log("Hitting: " + hit.collider.tag);

    //        if (hit.collider.tag.Equals("Spike"))
    //        {
    //            //Debug.Log("*Hitting: " + hit.collider.tag);
    //            Destroy(hit.collider.gameObject);

    //        }
    //    }

    //    if (hit2.collider != null)
    //    {
    //        if (hit2.collider.tag.Equals("Spike"))
    //        {
    //            //Debug.Log("**Hitting: " + hit2.collider.tag);
    //            Destroy(hit2.collider.gameObject);

    //        }
    //    }

    //    //Method to draw the ray in scene for debug purpose
    //    Debug.DrawRay(vectorJugador, Vector3.right * laserLength, Color.red, (float)0.1);
    //    Debug.DrawRay(vectorJugador2, Vector3.down * laserLength, Color.red, (float)0.1);
    //    //}

    //}

}
