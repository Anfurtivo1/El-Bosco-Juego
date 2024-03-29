using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    bool vivo;
    public TextMeshProUGUI texto;
    public int vidas;
    //private bool isInvincible = false;
    //[SerializeField]
    //private float invincibilityDurationSeconds;
    //[SerializeField]
    //private float delayBetweenInvincibilityFlashes;
    //[SerializeField]
    //private GameObject model;
    public int damage;
    //public Text textoVidas;
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

    public GameObject textoMenuMuerte;
    public Button recargarNivel;
    public Button cargarMenuPrincipalMenuMuerte;
    public Button btnPausa;

    public AudioClip recibirDaño;
    public AudioClip disparar;
    public AudioClip saltar;

    public AudioSource src;

    //private IEnumerator BecomeTemporarilyInvincible()
    //{
    //    //Debug.Log("Player turned invincible!");
    //    isInvincible = true;

    //    // Flash on and off for roughly invincibilityDurationSeconds seconds
    //    for (float i = 0; i < invincibilityDurationSeconds; i += delayBetweenInvincibilityFlashes)
    //    {
    //        // Alternate between 0 and 1 scale to simulate flashing
    //        if (model.transform.localScale == Vector3.one)
    //        {
    //            ScaleModelTo(Vector3.zero);
    //        }
    //        else
    //        {
    //            ScaleModelTo(Vector3.one);
    //        }
    //        yield return new WaitForSeconds(delayBetweenInvincibilityFlashes);
    //    }

    //    Debug.Log("Player is no longer invincible!");
    //    ScaleModelTo(Vector3.one);
    //    isInvincible = false;

    //}

    private void Awake()
    {
        progreso = this;
    }

    private void Start()
    {
        //PlayerPrefs.DeleteAll();


        //PlayerPrefs.DeleteKey("salto");
        //PlayerPrefs.Save();
        //Debug.LogWarning("Antes del If El boton para saltar es: " + PlayerPrefs.GetString("salto"));
        if (PlayerPrefs.GetString("salto") == "")
        {
            PlayerPrefs.SetString("salto", KeyCode.Space.ToString());
            botonSalto = PlayerPrefs.GetString("salto");
            PlayerPrefs.Save();
            
        }
        botonSalto = PlayerPrefs.GetString("salto");
        //Debug.LogWarning("Despues del If El boton para saltar es: " + PlayerPrefs.GetString("salto"));
        //Debug.Log("El boton para saltar es: " + PlayerPrefs.GetString("salto"));
        //textoVidas.text = "" + vidas;
        

    }
    // Update is called once per frame
    void Update()
    {
        
        if (vidas >0)
        {
            score += Time.deltaTime * 4;
            
            texto.text = "Score : " + score.ToString("F");
        }

        if (vidas == 0)
        {
            textoMenuMuerte.SetActive(true);
            recargarNivel.gameObject.SetActive(true);
            cargarMenuPrincipalMenuMuerte.gameObject.SetActive(true);
            btnPausa.gameObject.SetActive(false);
            Time.timeScale = 0;

            

        }
        
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
                src.clip = saltar;
                src.Play();
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

        if (col.gameObject.tag == "Bullet")
        {
            perderVida(damage);
            Destroy(col.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            perderVida(damage);
            Destroy(collision.gameObject);
        }
    }

    //private void ScaleModelTo(Vector3 scale)
    //{
    //    model.transform.localScale = scale;
    //}

    //public IEnumerator Morirse(Collider2D col, int daño)
    //{
    //    collider = this.GetComponent<Collider2D>();

    //    imagen = this.GetComponent<SpriteRenderer>();

    //    collider.enabled = false;

    //    imagen.enabled = false;

    //    src.clip = morir;
    //    src.Play();

    //    if (tipo == 3)
    //    {
    //        bulletGenerator.GetComponent<BulletGenerator>().pDisparo = false;
    //    }

    //    Destroy(col.gameObject);
    //    yield return new WaitForSeconds(1f);
    //    Destroy(this.gameObject);

    //}

    private void perderVida(int cantidad)
    {
        //if (isInvincible) return;
        //Debug.Log("*Colision�: Vida fuera");
        vidas = vidas - cantidad;
        //textoVidas.text = ""+vidas;

        if (vidas < 0)
        {
            vidas = 0;
            //textoVidas.text = "" + vidas;
        }

        src.clip = recibirDaño;
        src.Play();

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

            botonDisparo = PlayerPrefs.GetString("disparar");
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
                        src.clip = disparar;
                        src.Play();
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

}
