using UnityEngine;

public class collision_handler : MonoBehaviour
{
    public ParticleSystem ExplosionHandle;
    public Rigidbody2D BodyHandle;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Freeze the ship
        BodyHandle.constraints = RigidbodyConstraints2D.FreezeAll;
        // Explode
        ExplosionHandle.Play();
        // Destroy the Box Collider 2D object so that no more collisions are registered
        Destroy(gameObject);
    }
}
