using UnityEngine;

public class collision_handler : MonoBehaviour
{
    public ParticleSystem ExplosionHandle;

    void OnCollisionEnter2D(Collision2D collision)
    {
        ExplosionHandle.Play();
        // Destroy the Box Collider 2D object so that no more collisions are registered
        Destroy(gameObject);
    }
}
