using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bullet;
    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    public AudioSource src;

    public AudioClip disparar;

    public bool pDisparo = true;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = minSpeed;
        generateSpike();
    }

    // Update is called once per frame
    void Update()
    {
        //if (currentSpeed < maxSpeed)
        //{
        //    currentSpeed += SpeedMultiplier;
        //}

    }

    public void generateSpike()
    {
        if (pDisparo)
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<BulletScript>().bulletGenerator = this;
            newBullet.GetComponent<BulletScript>().bullet = newBullet;
            newBullet.layer = 3;

            src.clip = disparar;
            src.Play();
        }
        

    }

    public void generateRandomWave()
    {
        //float timeBetween = Random.Range(0.01f, 1.2f);
        generateSpike();
    }
}
