using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    [Min(1)]
    [SerializeField] private int health = 10;

    [Min(0)]
    [SerializeField] private int damage = 1;

    public int Health => health;               
    public int Damage => damage;
    public event System.Action<Enemy> Died;

    public virtual void GetDamage(int amount)
    {
        if (amount <= 0) {
            return;
        }
        health = Mathf.Max(0, health - amount);
        if (health == 0){
            Death();
        } 
    }

    public void TakeDamage(int amount) => GetDamage(amount);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        var damageable = other.GetComponentInParent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
    }
    protected virtual void Death()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}
