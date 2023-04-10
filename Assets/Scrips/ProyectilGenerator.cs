using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilGenerator : MonoBehaviour
{
    public GameObject proyectil;
    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = minSpeed;
        generateProyectil();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void generateWave()
    {
        GameObject newProyectil = Instantiate(proyectil, transform.position, transform.rotation);
        newProyectil.GetComponent<ProyectilScript>().proyectilGenerator = this;
        newProyectil.GetComponent<ProyectilScript>().proyectil = newProyectil;
        newProyectil.layer = 3;
    }

    public void generateProyectil()
    {
        generateWave();
    }

}
