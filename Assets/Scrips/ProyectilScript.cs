using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilScript : MonoBehaviour
{
    [HideInInspector]
    public ProyectilGenerator proyectilGenerator;
    public GameObject proyectil;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Length of the ray
        float laserLength = 1f;
        //Obtain the layerMask of the layer
        int layerMask = LayerMask.GetMask("Default");

        //Get the first object hit by the ray
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right, laserLength, layerMask);

        transform.Translate(Vector2.right * proyectilGenerator.currentSpeed * Time.deltaTime);

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
                if (hit.collider.CompareTag("Spike"))
                {
                    //hit.collider.gameObject
                    //Hit something, print the tag of the object
                    //Debug.Log("Hitting: " + hit.collider.tag);
                    //proyectilGenerator.generateWave();
                    Destroy(this.gameObject);
                }
            }

            //Method to draw the ray in scene for debug purpose
            Debug.DrawRay(transform.position, Vector2.right * laserLength, Color.yellow);

        Destroy(this.gameObject, 4f);
    }
}
