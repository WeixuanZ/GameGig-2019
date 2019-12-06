using UnityEngine;

public class collision_handler : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("You died");
    }
}
