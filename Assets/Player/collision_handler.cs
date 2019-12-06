using System.Collections;
using UnityEngine;

public class collision_handler : MonoBehaviour
{
    public ParticleSystem ExplosionHandle;
    public Rigidbody2D BodyHandle;
    public SpriteRenderer SpriteHandle;

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        * Disable the Box Collider 2D component so that no more collisions are registered
        * If the object was destroyed instead, then the coroutine below wouldn't run
        */
        GetComponent<BoxCollider2D>().enabled = false;

        BodyHandle.constraints = RigidbodyConstraints2D.FreezeAll;
        ExplosionHandle.Play();

        StartCoroutine(FlashShip());
    }

    IEnumerator FlashShip()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.2f);
            SpriteHandle.enabled = !SpriteHandle.enabled;
        }

        SpriteHandle.enabled = false;
    }
}
