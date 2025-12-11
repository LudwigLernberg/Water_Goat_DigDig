using UnityEngine;
using static PlayerAttackTrigger;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log(gameObject.name + " took damage: " + amount);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " died.");
        Destroy(gameObject);
    }
}
