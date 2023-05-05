using System.Collections;
using UnityEngine;
public class BackgroundScroller : MonoBehaviour
{
    [Range(-5f, 5f)]
    public float Speed;

    private float offset;
    private Material mat;



    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }


    void Update()
    {
        offset += (Time.deltaTime * Speed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        StartCoroutine(aumentarVel());
    }

    private IEnumerator aumentarVel()
    {
        yield return new WaitForSeconds(1f);
        Speed = Speed + 0.001f;
        if (Speed > 5f)
        {
            Speed = 5f;
        }
    }

}