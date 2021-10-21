using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int healthBack = 40;

    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider is CircleCollider2D)
        {
            PlayerStatus player = collision.gameObject.GetComponent<PlayerStatus>();
            if (player != null)
            {
                Debug.Log("****In HealthPot*****Something got healed for " + healthBack);
                player.GetHealed(healthBack);
                Destroy(gameObject);
            }

        }
    }
    private void Update()
    {
        
    }


}
