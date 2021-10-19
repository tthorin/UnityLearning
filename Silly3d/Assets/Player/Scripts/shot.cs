using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    public int damage = 40;
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impact;
    float decayTime;
    // Start is called before the first frame update
    private void Awake()
    {
        decayTime = Time.time;
    }
    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }
    private void FixedUpdate()
    {
        if (Time.time-decayTime>5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        Debug.Log(collision.gameObject);
        if (enemy != null)
        {
            Debug.Log(enemy);
            enemy.TakeDamage(damage);
        }
        Instantiate(impact, transform.position, transform.rotation);
        Destroy(gameObject);

    }


}
