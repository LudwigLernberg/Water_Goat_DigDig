using UnityEngine;

public class HitboxColliderForwarder : MonoBehaviour
{
    private PlayerAttackTrigger player;

    void Start()
    {
        player = GetComponentInParent<PlayerAttackTrigger>();
        if (player == null)
            Debug.LogError("Hitbox could not find PlayerAttackTrigger in parent!");
    }

    void OnTriggerEnter(Collider other)
    {
        player?.TryDamage(other);
    }
}

