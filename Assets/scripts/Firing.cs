using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{

    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform fireballSpawnPoint;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            CastFireBall();
        }
    }

    void CastFireBall()
    {
        GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);

        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.AddForce(fireballSpawnPoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
