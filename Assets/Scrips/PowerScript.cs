using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    [HideInInspector]
    public PowerGenerator powerGenerator;

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

}
