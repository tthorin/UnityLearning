using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    Animator animator;
    bool IsDead = false;
    float decayTime = 10f;
    float timeToVanish = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (IsDead)
        {
            if (Time.time > timeToVanish)
                Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hurt");
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        IsDead = true;
        animator.SetBool("IsDead",IsDead);
        gameObject.layer = LayerMask.NameToLayer("Dead");
        timeToVanish = Time.time + decayTime;
    }
}
