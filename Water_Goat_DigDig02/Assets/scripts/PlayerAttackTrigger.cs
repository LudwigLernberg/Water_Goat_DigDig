using System.Collections.Generic;
using UnityEngine;

/*public class PlayerAttackTrigger : MonoBehaviour
{
    [Header("Attack settings")]
    public GameObject hitboxObject; // child with BoxCollider(isTrigger)
    public float attackDuration = 0.15f; // how long the hitbox is active
    public float attackCooldown = 0.3f;  // time between attacks
    public int damage = 25;
    public KeyCode attackKey = KeyCode.Mouse0; // left click by default

    float lastAttackTime = -999f;
    float attackEndTime = 0f;
    HashSet<Collider> alreadyHit;

    void Start()
    {
        if (hitboxObject == null)
        {
            Debug.LogError("Assign hitboxObject (child with trigger collider).");
            enabled = false;
            return;
        }

        hitboxObject.SetActive(false);
        alreadyHit = new HashSet<Collider>();
    }

    void Update()
    {
        if (Input.GetKeyDown(attackKey) && Time.time >= lastAttackTime + attackCooldown)
        {
            StartAttack();
        }

        // auto-disable hitbox after duration
        if (hitboxObject.activeSelf && Time.time >= attackEndTime)
        {
            EndAttack();
        }
    }

    void StartAttack()
    {
        lastAttackTime = Time.time;
        attackEndTime = Time.time + attackDuration;
        alreadyHit.Clear();             // reset who we've damaged this attack
        hitboxObject.SetActive(true);
        // optionally play animation/sfx here
    }

    void EndAttack()
    {
        hitboxObject.SetActive(false);
    }

    // This is called by the hitbox object's collider script (or you can put this on the same object if the hitbox object uses the same script)
    public void TryDamage(Collider other)
    {
        if (alreadyHit.Contains(other)) return;
        alreadyHit.Add(other);

        // Look for IDamageable (preferred) or EnemyHealth
        var dmgable = other.GetComponentInParent<IDamageable>();
        if (dmgable != null)
        {
            dmgable.TakeDamage(damage);
            return;
        }

        var enemy = other.GetComponentInParent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            return;
        }
    }
}*/

