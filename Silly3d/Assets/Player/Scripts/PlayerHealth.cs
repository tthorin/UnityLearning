using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    public bool IsDead = false;
    Animator animator;
    PlayerMovement mover;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        mover = GetComponent<PlayerMovement>();
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Player got hit! current health is: {currentHealth} out of {maxHealth}!");
        if (currentHealth < 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("IsDead", true);
        mover.enabled = false;
        IsDead = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
