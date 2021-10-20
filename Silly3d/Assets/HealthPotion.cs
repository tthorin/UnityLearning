using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int healthBack = 40;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider is CircleCollider2D)
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                Debug.Log("****In HealthPot*****Something got healed for " + healthBack);
                player.GetHealed(healthBack);
                Destroy(gameObject);
            }

        }
    }


}
