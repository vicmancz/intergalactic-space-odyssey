using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float intervalShoot;
    private float timerShoot = 0.0f;

    [SerializeField] private GameObject target;
    [SerializeField] private float targetDistanceToShoot = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        timerShoot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timerShoot += Time.deltaTime;
        Vector3 distanceTarget = transform.position - target.transform.position;
        if (distanceTarget.magnitude <= targetDistanceToShoot )
        {
            if (timerShoot >= intervalShoot)
            {
                Shoot();
                timerShoot = 0;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
    }
}