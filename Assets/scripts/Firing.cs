using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{

    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform fireballSpawnPoint;

    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float fireRate = 1f;
    private float shotCooldown;

    void Update()
    {
        shotCooldown  -= Time.deltaTime;

        if (Input.GetButton("Fire1") && shotCooldown <= 0f)
        {        
            shotCooldown = 1 /fireRate;
            CastFireBall();
        }
    }

    void CastFireBall()
    {

        GameObject fireball = Instantiate(
            fireballPrefab,
            fireballSpawnPoint.position,
            fireballSpawnPoint.rotation
        );
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.velocity = (Vector2)fireballSpawnPoint.up * bulletSpeed;
    }
}