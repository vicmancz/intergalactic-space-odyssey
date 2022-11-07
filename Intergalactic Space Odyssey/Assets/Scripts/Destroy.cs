using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private float timer = 0f;
    private float countdown = 0f;
    [SerializeField] private GameObject explotionEffect = null;

    // Start is called before the first frame update
    void Start()
    {
        countdown = timer;
        if (timer == 0f)
        {
            if (explotionEffect != null)
            {
                Instantiate(explotionEffect, transform.position, transform.rotation);
                DestroyImmediate(gameObject);
            }
        }
        else
        {
            Destroy(gameObject, timer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            if (explotionEffect != null) 
            {
                Instantiate(explotionEffect, transform.position, transform.rotation);
            }
        }
    }
}