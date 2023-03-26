using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    System.Random rnd = new System.Random();

    [HideInInspector]
    public PowerGenerator powerGenerator;
    public GameObject player;
    [HideInInspector]
    public bool tipoPower; //True es Up, false es Down

    // Update is called once per frame
    void Update()
    {
        if (powerGenerator != null)
        {
            transform.Translate(Vector2.left * powerGenerator.currentSpeed * Time.deltaTime);

            //Length of the ray
            float laserLength = 1f;
            //Obtain the layerMask of the layer
            int layerMask = LayerMask.GetMask("Default");

            //Get the first object hit by the ray
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.left, laserLength, layerMask);

            Debug.DrawRay(transform.position, Vector2.left * laserLength, Color.grey);

            if (hit.collider.tag.Equals("Player"))
            {
                //hit.collider.gameObject
                //Hit something, print the tag of the object
                Debug.Log("Hitting: " + hit.collider.tag);

                if (tipoPower == true)
                {
                    ElegirPowerup();
                }

                if (tipoPower == false)
                {
                    ElegirPowerDown();
                }

                powerGenerator.GenerateRandomWave();
                Destroy(this.gameObject);
            }

            if (hit.collider.tag.Equals("finishLine"))
            {
                //hit.collider.gameObject
                //Hit something, print the tag of the object
                Debug.Log("Hitting: " + hit.collider.tag);
                powerGenerator.GenerateRandomWave();
                Destroy(this.gameObject);
            }


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
                player.GetComponent<PlayerScript>().potenciaSalto = player.GetComponent<PlayerScript>().potenciaSalto + 20;

                break;
            case 3:
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
                player.GetComponent<PlayerScript>().potenciaSalto = player.GetComponent<PlayerScript>().potenciaSalto - 5;

                break;
            case 3:
                break;
            default:
                break;
        }
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
