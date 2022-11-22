using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public static int lifes;
    public float life = 100f;
    private float initialLife;
    public GameObject spawnPoint;
    public float speed = 5f;
    float smooth = 10f;
    float time;
    public Rigidbody rb;

    public GameObject explotionEffect;


    void Start()
    {
        lifes = 3;
        initialLife = life;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (life <= 0)
        {
            lifes--;
            StartCoroutine(Spawn());
        }
    }



    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A))
        {
            InclineZ(30);
            transform.Translate(Vector3.left * (speed * Time.deltaTime), Space.World);

        }

        if (Input.GetKey(KeyCode.D))
        {
            InclineZ(angle: 60);
            transform.Translate(Vector3.right * (speed * Time.deltaTime), Space.World);
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Reset posicion");
            Quaternion target = Quaternion.identity;
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }
    }

    private void InclineZ(float angle)
    {
        float tiltAroundZ = Input.GetAxis("Horizontal") * angle * -1;
        Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.gameObject.CompareTag("Obstacle") ||
            collision.collider.transform.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Spawn());
            lifes--;
        }

        if (collision.collider.transform.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.collider.transform.gameObject);
            ReceiveDamage();
        }
    }

    IEnumerator Spawn()
    {
        life = initialLife;
        var efecto = Instantiate(explotionEffect, transform.position, transform.rotation);
        yield return new WaitForSeconds(2f);
        Destroy(efecto);
        transform.position = spawnPoint.transform.position;
    }

    void ReceiveDamage()
    {
        life -= 25;
    }
}