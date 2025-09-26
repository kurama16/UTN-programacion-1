using UnityEngine;
using System;
public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHearts = 3;
    [SerializeField] private float invulnerableTime = 1.0f;
    public static event Action OnPlayerDamaged;

    private int units;        
    private float iTimer = 0;

    void Awake() => units = maxHearts * 2;

    void Update()
    {
        if (iTimer > 0f) iTimer -= Time.deltaTime;
    }

    public void TakeDamage(int amount)
    {

        if (amount <= 0 || iTimer > 0f) return;   

        units = Mathf.Max(0, units - amount);     
        iTimer = invulnerableTime;                

        if (units == 0) Die();
        OnPlayerDamaged?.Invoke();
    }
 

    private void Die()
    {
        GlobalStats.gameOver = true;
    }

    public int CurrentHearts => units / 2;
    public int MaxHearts => maxHearts/2;
    public bool HasHalfHeart => (units % 2) == 1;
}