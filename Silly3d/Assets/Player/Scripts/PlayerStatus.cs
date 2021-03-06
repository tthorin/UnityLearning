using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    public bool IsDead = false;
    public HealthBar healthbar;
    public XpBar xpbar;
    
    public int Xp = 0;
    public int XpToNextLevel = 300;
    public int Level = 1;

    Animator animator;
    PlayerMovement mover;


    private void Awake()
    {   
        xpbar.SetMaxXp(XpToNextLevel);
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        mover = GetComponent<PlayerMovement>();
        healthbar.SetMaxHealth(maxHealth);
    }

    public void GetXp(int xp)
    {
        Xp += xp;
        xpbar.SetXp(Xp);
        if (Xp >= XpToNextLevel) LevelUp();
    }

    private void LevelUp()
    {
        Level++;

        maxHealth += 100;
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        healthbar.SetHealth(currentHealth);

        XpToNextLevel *= 2;
        Xp = 0;
        xpbar.SetXp(Xp);
        xpbar.SetMaxXp(XpToNextLevel);
    }

    public void GetHealed(int heal)
    {
        if ((currentHealth + heal) > maxHealth) currentHealth = maxHealth;
        else currentHealth += heal;
        healthbar.SetHealth(currentHealth);
        Debug.Log("****In PlayerHealth*** Player got healed for: " + heal);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
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
