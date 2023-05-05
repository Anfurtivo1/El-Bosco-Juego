using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Siguiente()
    {
        SceneManager.LoadScene("Tutorial 2");
    }

    public void Atras()
    {
        SceneManager.LoadScene("Menu Principal");
    }

    public void Atras2()
    {
        SceneManager.LoadScene("Tutorial");
    }

}
