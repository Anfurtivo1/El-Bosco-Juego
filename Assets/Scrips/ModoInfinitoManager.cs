using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModoInfinitoManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Cargar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Cargar()
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1;
    }

}
