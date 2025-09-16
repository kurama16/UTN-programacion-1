using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int speed = 5;
    private Animator animator;
    private GameObject player;

    private Collider2D collider2d;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        collider2d = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }

    void destroyEnemy()
    {

        Destroy(gameObject);
        GlobalStats.EnemiesLeft--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collider2d.enabled = false;
            animator.SetBool("IsDead", true);

        }

    }
}
