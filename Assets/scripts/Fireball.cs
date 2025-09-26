using UnityEngine;

public class Fireball : MonoBehaviour,IDamageSource
{

    [SerializeField] private int damage = 5;
    public int GetDamage() => damage;
    [SerializeField] private string ownerTag = "Player";

    void Start()
    {
        Destroy(gameObject, 3f);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ownerTag)) return;
        Debug.Log("destroy by" + other);

        var damageable = other.GetComponentInParent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(GetDamage());
            Destroy(gameObject);
            return;
        } 
        Destroy(gameObject);
        
    }
}

