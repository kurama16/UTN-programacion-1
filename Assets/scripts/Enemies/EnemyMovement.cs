using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
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

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }
}
